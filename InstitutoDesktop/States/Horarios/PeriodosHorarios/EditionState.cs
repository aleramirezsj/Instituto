using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Views.Commons;
using InstitutoDesktop.Views.Horarios;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Horarios;
using InstitutoServices.Models.Inscripciones;

namespace InstitutoDesktop.States.Horarios.PeriodosHorarios
{
    public class EditionState : IPeriodosHorariosViewState
    {
        private readonly PeriodosHorariosView _form;

        public EditionState(PeriodosHorariosView form)
        {
            _form = form;
            UpdateUI();
        }

        public async Task OnGuardar()
        {
            if (string.IsNullOrEmpty(_form.txtNombre.Text))
            {
                MessageBox.Show("Debe definirse un nombre para el período de horarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _form.periodoHorarioCurrent.Nombre = _form.txtNombre.Text;
            _form.periodoHorarioCurrent.CicloLectivoId = (int)_form.comboBoxCiclosLectivos.SelectedValue;
            _form.periodoHorarioCurrent.CicloLectivo = (CicloLectivo)_form.comboBoxCiclosLectivos.SelectedItem;
            _form.periodoHorarioCurrent.Actual = _form.checkActual.Checked;
            _form.periodoHorarioCurrent.Es2doCuatrimestre = _form.checkMaterias2doCuatrimestre.Checked;

            if (_form.periodoHorarioCurrent.Id == 0)
            {
                await _form._memoryCache.AddCacheAsync<PeriodoHorario>(_form.periodoHorarioCurrent);
                _form._memoryCache.ClearCache<PeriodoHorario>();
            }
            else
            {
                await _form._memoryCache.UpdateCacheAsync<PeriodoHorario>(_form.periodoHorarioCurrent);
                _form._memoryCache.ClearCache<PeriodoHorario>();
            }

            _form.TransitionTo(new InitialDisplayState(_form));
            await _form._currentState.LoadData();
        }

        public void OnCancelar()
        {
            _form.periodoHorarioCurrent = null;
            _form.TransitionTo(new InitialDisplayState(_form));
        }

        public void UpdateUI()
        {
            _form.tabPageAgregarEditar.Enabled = true;
            _form.tabPageLista.Enabled = false;
            _form.tabControl.SelectTab(_form.tabPageAgregarEditar);

            _form.txtNombre.Text = _form.periodoHorarioCurrent.Nombre;
            _form.comboBoxCiclosLectivos.SelectedValue = _form.periodoHorarioCurrent.CicloLectivoId;
            _form.checkActual.Checked = _form.periodoHorarioCurrent.Actual;
            _form.checkMaterias2doCuatrimestre.Checked = _form.periodoHorarioCurrent.Es2doCuatrimestre;
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
