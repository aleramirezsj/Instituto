using InstitutoDesktop.ExtensionMethods;
using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Interfaces.MesasExamenes;
using InstitutoDesktop.Util;
using InstitutoDesktop.Views.Commons;
using InstitutoDesktop.Views.Inscripciones;
using InstitutoDesktop.Views.MesasExamenes;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Inscripciones;
using InstitutoServices.Models.MesasExamenes;

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
            await LoadGrid();
        }

        public async Task LoadGrid()
        {
            if (_form.listaUsuarios != null && _form.listaUsuarios.Count > 0)
                _form.Grilla.DataSource = _form.listaUsuarios.OrderBy(usuario => usuario.Nombre).ToList();
            _form.Grilla.OcultarColumnas(new string[] { "Id", "Eliminado" });
        }

        public async Task LoadGridFilter(string filterText)
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
            if (string.IsNullOrEmpty(_form.txtFiltro.Text))
                LoadGrid();
            else
                LoadGridFilter(_form.txtFiltro.Text);
        }

        public async void UpdateUI()
        {
            
            await LoadGrid();
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




    }
}
