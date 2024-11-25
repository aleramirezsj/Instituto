using InstitutoDesktop.ExtensionMethods;
using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Interfaces.MesasExamenes;
using InstitutoDesktop.Util;
using InstitutoDesktop.Views.Inscripciones;
using InstitutoDesktop.Views.MesasExamenes;
using InstitutoServices.Models.Inscripciones;
using InstitutoServices.Models.MesasExamenes;

namespace InstitutoDesktop.States.MesasExamenes.TurnosExamenes
{
    public class InitialDisplayState : ITurnosExamenesViewState
    {
        private readonly TurnosExamenesView _form;

        public InitialDisplayState(TurnosExamenesView form)
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
            ShowInActivity.Show("Cargando turnos de exámenes...");
            _form.listaTurnosExamenes = await _form._memoryCache.GetAllCacheAsync<TurnoExamen>();
            ShowInActivity.Hide();
            await LoadComboboxCiclosLectivos();
            LoadGrid();
        }

        public void LoadGrid()
        {
            if (_form.listaTurnosExamenes != null && _form.listaTurnosExamenes.Count > 0)
                _form.Grilla.DataSource = _form.listaTurnosExamenes.OrderBy(periodo => periodo.CicloLectivoId).ToList();
            _form.Grilla.OcultarColumnas(new string[] { "Id","CicloLectivoId",  "Eliminado" });
        }

        public void LoadGridFilter(string filterText)
        {
            if (_form.listaTurnosExamenes != null && _form.listaTurnosExamenes.Count > 0)
                _form.Grilla.DataSource = _form.listaTurnosExamenes
                    .Where(periodo => periodo.Nombre.ToUpper().Contains(filterText.ToUpper()))
                    .OrderBy(periodo => periodo.CicloLectivoId)
                    .ToList();
            _form.Grilla.OcultarColumnas(new string[] { "Id", "CicloLectivoId", "Es2doCuatrimestre", "Eliminado" });
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
            
            LoadGrid();
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

        public async Task LoadComboboxCiclosLectivos()
        {
            ShowInActivity.Show("Cargando ciclos lectivos...");
            _form.comboBoxCiclosLectivos.DataSource= await _form._memoryCache.GetAllCacheAsync<CicloLectivo>();
            ShowInActivity.Hide();
            _form.comboBoxCiclosLectivos.DisplayMember = "Nombre";
            _form.comboBoxCiclosLectivos.ValueMember = "Id";
        }


    }
}
