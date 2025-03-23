using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Interfaces.MesasExamenes;
using InstitutoDesktop.Views.Inscripciones;
using InstitutoDesktop.Views.MesasExamenes;
using InstitutoServices.Models.Inscripciones;
using InstitutoServices.Models.MesasExamenes;

namespace InstitutoDesktop.States.MesasExamenes.TurnosExamenes
{
    public class ActionsState : ITurnosExamenesViewState
    {
        private readonly TurnosExamenesView _form;

        public ActionsState(TurnosExamenesView form)
        {
            _form = form;
        }

        public void OnAgregar()
        {
            _form.turnoExamenCurrent = new TurnoExamen();
            _form.TransitionTo(new EditionState(_form));
        }

        public void OnModificar()
        {
            if (_form.Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un turno de examen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _form.turnoExamenCurrent = (TurnoExamen)_form.Grilla.CurrentRow.DataBoundItem;
            _form.TransitionTo(new EditionState(_form));
        }

        public async Task OnEliminar()
        {
            _form.turnoExamenCurrent = (TurnoExamen)_form.Grilla.CurrentRow.DataBoundItem;
            var result = MessageBox.Show(
                $"¿Está seguro que desea eliminar el período de inscripciones {_form.turnoExamenCurrent.Nombre}?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                await _form._memoryCache.DeleteCacheAsync<PeriodoInscripcion>(_form.turnoExamenCurrent.Id);
            }
            _form.turnoExamenCurrent = null;
            _form.TransitionTo(new InitialDisplayState(_form));
        }


        // Estos métodos no aplican en este estado
        public Task LoadData() => Task.CompletedTask;
        public void LoadGrid(string filterText) {}
        public void OnBuscar() { }
        public void UpdateUI() { }
        public Task OnGuardar() => Task.CompletedTask;
        public void OnCancelar() { }
        public void OnSalir() => _form.Close();
        public Task LoadComboboxCiclosLectivos()=> Task.CompletedTask;



    }
}
