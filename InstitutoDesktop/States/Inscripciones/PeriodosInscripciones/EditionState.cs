using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Views.Commons;
using InstitutoDesktop.Views.Horarios;
using InstitutoDesktop.Views.Inscripciones;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Horarios;
using InstitutoServices.Models.Inscripciones;
using InstitutoServices.Models.MesasExamenes;

namespace InstitutoDesktop.States.Inscripciones.PeriodosInscripciones
{
    public class EditionState : IPeriodosInscripcionesViewState
    {
        private readonly PeriodosInscripcionesView _form;

        public EditionState(PeriodosInscripcionesView form)
        {
            _form = form;
            UpdateUI();
        }

        public async Task OnGuardar()
        {
            if (string.IsNullOrEmpty(_form.txtNombre.Text))
            {
                MessageBox.Show("Debe definirse un nombre para el período de inscripciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _form.periodoInscripcionCurrent.Nombre = _form.txtNombre.Text;
            _form.periodoInscripcionCurrent.CicloLectivoId = (int)_form.comboBoxCiclosLectivos.SelectedValue;
            _form.periodoInscripcionCurrent.CicloLectivo = (CicloLectivo)_form.comboBoxCiclosLectivos.SelectedItem;
            _form.periodoInscripcionCurrent.InscripcionHabilitada = _form.checkInscripcionHabilitada.Checked;
            _form.periodoInscripcionCurrent.Es2doCuatrimestre = _form.checkMaterias2doCuatrimestre.Checked;

            if (_form.periodoInscripcionCurrent.Id == 0)
            {
                await _form._memoryCache.AddCacheAsync<PeriodoInscripcion>(_form.periodoInscripcionCurrent);
                _form._memoryCache.ClearCache<PeriodoInscripcion>();

            }
            else
            {
                await _form._memoryCache.UpdateCacheAsync<PeriodoInscripcion>(_form.periodoInscripcionCurrent);
                _form._memoryCache.ClearCache<PeriodoInscripcion>();

            }

            _form.TransitionTo(new InitialDisplayState(_form));
            await _form._currentState.LoadData();
        }

        public void OnCancelar()
        {
            _form.periodoInscripcionCurrent = null;
            _form.TransitionTo(new InitialDisplayState(_form));
        }

        public void UpdateUI()
        {
            _form.tabPageAgregarEditar.Enabled = true;
            _form.tabPageLista.Enabled = false;
            _form.tabControl.SelectTab(_form.tabPageAgregarEditar);

            _form.txtNombre.Text = _form.periodoInscripcionCurrent.Nombre;
            _form.comboBoxCiclosLectivos.SelectedValue = _form.periodoInscripcionCurrent.CicloLectivoId;
            _form.checkInscripcionHabilitada.Checked = _form.periodoInscripcionCurrent.InscripcionHabilitada;
            _form.checkMaterias2doCuatrimestre.Checked = _form.periodoInscripcionCurrent.Es2doCuatrimestre;
        }

        // Estos métodos no aplican en este estado
        public Task LoadData() => Task.CompletedTask;
        public Task LoadGrid() => Task.CompletedTask;
        public Task LoadGridFilter(string filterText) => Task.CompletedTask;
        public void OnAgregar() { }
        public void OnModificar() { }
        public void OnBuscar() { }
        public Task OnEliminar() => Task.CompletedTask;
        public void OnSalir() => _form.Close();

        public Task LoadComboboxCiclosLectivos() => Task.CompletedTask;
    }
}
