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

namespace InstitutoDesktop.States.Commons.Alumnos
{
    public class InitialDisplayState : IAlumnosViewState
    {
        private readonly AlumnosView _form;

        public InitialDisplayState(AlumnosView form)
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
            _form.listaAlumnos = await _form._memoryCache.GetAllCacheAsync<Alumno>();
            ShowInActivity.Hide();
            LoadGrid(_form.txtFiltro.Text);
        }


        public void LoadGrid(string filterText)
        {
            if (_form.listaAlumnos != null && _form.listaAlumnos.Count > 0)
                _form.Grilla.DataSource = _form.listaAlumnos
                    .Where(alumno => alumno.ApellidoNombre.ToUpper().Contains(filterText.ToUpper()))
                    .OrderBy(alumno => alumno.ApellidoNombre)
                    .ToList();
            _form.Grilla.OcultarColumnas(new string[] { "Id", "Eliminado", "InscripcionesACarreras" });
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




    }
}
