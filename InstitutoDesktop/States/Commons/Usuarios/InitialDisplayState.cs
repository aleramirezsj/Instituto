using InstitutoDesktop.ExtensionMethods;
using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Util;
using InstitutoDesktop.Views.Commons;
using InstitutoServices.Enums;
using InstitutoServices.Models.Commons;

namespace InstitutoDesktop.States.Commons.Usuarios
{
    public class InitialDisplayState : IUsuariosViewState
    {
        private readonly UsuariosView _form;

        public InitialDisplayState(UsuariosView form)
        {
            _form = form;
            UpdateUI();
            _form.Grilla.DataBindingComplete += (sender, e) => EnableDisableButtons();
        }

        private void EnableDisableButtons()
        {
            _form.btnModificar.Enabled = _form.Grilla.Rows.Count > 0;
            _form.btnEliminar.Enabled = _form.Grilla.Rows.Count > 0;
        }

        public async Task LoadData()
        {
            ShowInActivity.Show("Cargando alumnos...");
            _form.listaUsuarios = await _form._memoryCache.GetAllCacheAsync<Usuario>();
            ShowInActivity.Hide();
            await LoadComboboxDocentes();
            await LoadComboboxAlumnos();
            LoadComboboxTipoUsuario();
            LoadGrid(_form.txtFiltro.Text);
        }

        public void LoadGrid(string filterText)
        {
            if (_form.listaUsuarios != null && _form.listaUsuarios.Count > 0)
                _form.Grilla.DataSource = _form.listaUsuarios
                    .Where(usuario => usuario.Nombre.ToUpper().Contains(filterText.ToUpper()))
                    .OrderBy(usuario => usuario.Nombre)
                    .ToList();
            _form.Grilla.OcultarColumnas(new string[] { "Id", "Eliminado" });
        }


        public void OnBuscar()
        {
            LoadGrid(_form.txtFiltro.Text);
        }

        public async void UpdateUI()
        {

            LoadGrid(_form.txtFiltro.Text);
            _form.tabPageAgregarEditar.Enabled = false;
            _form.tabPageLista.Enabled = true;
            _form.tabControl.SelectTab(_form.tabPageLista);
        }

        // Estos métodos no aplican en este estado
        public void OnAgregar() {
            _form.TransitionTo(new ActionsState(_form));
            _form._currentState.OnAgregar();
        }
        public void OnModificar() {
            _form.TransitionTo(new ActionsState(_form));
            _form._currentState.OnModificar();
        }
        public Task OnEliminar() {
            _form.TransitionTo(new ActionsState(_form));
            return _form._currentState.OnEliminar();
        }
        public Task OnGuardar() => Task.CompletedTask;
        public void OnCancelar() { }
        public void OnSalir() => _form.Close();

        public async Task LoadComboboxDocentes()
        {
            ShowInActivity.Show("Cargando docentes...");
            _form.comboBoxDocentes.DataSource = await _form._memoryCache.GetAllCacheAsync<Docente>();
            ShowInActivity.Hide();
            _form.comboBoxDocentes.DisplayMember = "Nombre";
            _form.comboBoxDocentes.ValueMember = "Id";
        }

        public async Task LoadComboboxAlumnos()
        {
            ShowInActivity.Show("Cargando alumnos...");
            _form.comboBoxAlumnos.DataSource = await _form._memoryCache.GetAllCacheAsync<Alumno>();
            ShowInActivity.Hide();
            _form.comboBoxAlumnos.DisplayMember = "ApellidoNombre";
            _form.comboBoxAlumnos.ValueMember = "Id";
        }

        public void LoadComboboxTipoUsuario()
        {
            _form.comboBoxTipoUsuario.DataSource = Enum.GetValues(typeof(TipoUsuarioEnum));
        }

    }
}
