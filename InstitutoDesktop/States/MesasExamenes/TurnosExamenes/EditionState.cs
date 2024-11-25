using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Interfaces.MesasExamenes;
using InstitutoDesktop.Views.Inscripciones;
using InstitutoDesktop.Views.MesasExamenes;
using InstitutoServices.Models.Inscripciones;
using InstitutoServices.Models.MesasExamenes;

namespace InstitutoDesktop.States.MesasExamenes.TurnosExamenes
{
    public class EditionState : ITurnosExamenesViewState
    {
        private readonly TurnosExamenesView _form;

        public EditionState(TurnosExamenesView form)
        {
            _form = form;
            UpdateUI();
        }

        public async Task OnGuardar()
        {
            if (string.IsNullOrEmpty(_form.txtNombre.Text))
            {
                MessageBox.Show("Debe definirse un nombre para el turno de examen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _form.turnoExamenCurrent.Nombre = _form.txtNombre.Text;
            _form.turnoExamenCurrent.CicloLectivoId = (int)_form.comboBoxCiclosLectivos.SelectedValue;
            _form.turnoExamenCurrent.CicloLectivo = (CicloLectivo)_form.comboBoxCiclosLectivos.SelectedItem;
            _form.turnoExamenCurrent.InscripcionHabilitada = _form.checkInscripcionHabilitada.Checked;
            _form.turnoExamenCurrent.TieneLLamado2 = _form.checkTiene2doLLamado.Checked;
            _form.turnoExamenCurrent.Actual = _form.checkTurnoActual.Checked;

            if (_form.turnoExamenCurrent.Id == 0)
            {
                await _form._memoryCache.AddCacheAsync<TurnoExamen>(_form.turnoExamenCurrent);
                _form._memoryCache.ClearCache<TurnoExamen>();
            }
            else
            {
                await _form._memoryCache.UpdateCacheAsync<TurnoExamen>(_form.turnoExamenCurrent);
                _form._memoryCache.ClearCache<TurnoExamen>();
            }

            _form.TransitionTo(new InitialDisplayState(_form));
            await _form._currentState.LoadData();
        }

        public void OnCancelar()
        {
            _form.turnoExamenCurrent = null;
            _form.TransitionTo(new InitialDisplayState(_form));
        }

        public void UpdateUI()
        {
            _form.tabPageAgregarEditar.Enabled = true;
            _form.tabPageLista.Enabled = false;
            _form.tabControl.SelectTab(_form.tabPageAgregarEditar);

            _form.txtNombre.Text = _form.turnoExamenCurrent.Nombre;
            _form.comboBoxCiclosLectivos.SelectedValue = _form.turnoExamenCurrent.CicloLectivoId;
            _form.checkInscripcionHabilitada.Checked = _form.turnoExamenCurrent.InscripcionHabilitada;
            _form.checkTiene2doLLamado.Checked = _form.turnoExamenCurrent.TieneLLamado2;
            _form.checkTurnoActual.Checked = _form.turnoExamenCurrent.Actual;
        }

        // Estos métodos no aplican en este estado
        public Task LoadData() => Task.CompletedTask;
        public void LoadGrid() {}
        public void LoadGridFilter(string filterText) {}
        public void OnAgregar() { }
        public void OnModificar() { }
        public void OnBuscar() { }
        public Task OnEliminar() => Task.CompletedTask;
        public void OnSalir() => _form.Close();

        public Task LoadComboboxCiclosLectivos() => Task.CompletedTask;
    }
}
