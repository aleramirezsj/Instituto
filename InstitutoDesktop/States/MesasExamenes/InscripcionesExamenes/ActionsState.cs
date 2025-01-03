using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Interfaces.MesasExamenes;
using InstitutoDesktop.Views;
using InstitutoDesktop.Views.Inscripciones;
using InstitutoDesktop.Views.MesasExamenes;
using InstitutoServices.Models.Inscripciones;
using InstitutoServices.Models.MesasExamenes;

namespace InstitutoDesktop.States.MesasExamenes.InscripcionesExamenes
{
    public class ActionsState : IMesasExamenesViewState
    {
        private readonly InscripcionesExamenesView _form;

        public ActionsState(InscripcionesExamenesView form)
        {
            _form = form;
        }

        public void OnAgregar()
        {
            //form.mesaExamenCurrent = new MesaExamen();
            _form.TransitionTo(new EditionState(_form));
        }

        public void OnModificar()
        {
            //if (_form.dataGridMesasExamenes.CurrentRow == null)
            //{
            //    MessageBox.Show("Debe seleccionar una measa de examen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //_form.mesaExamenCurrent = (MesaExamen)_form.dataGridMesasExamenes.CurrentRow.DataBoundItem;
            //_form.TransitionTo(new EditionState(_form));
        }

        public async Task OnEliminar()
        {
            //_form.mesaExamenCurrent = (MesaExamen)_form.dataGridMesasExamenes.CurrentRow.DataBoundItem;
            //var result = MessageBox.Show(
            //    $"¿Está seguro que desea eliminar la mesa de examen de la materia {_form.mesaExamenCurrent.Materia.Nombre}?",
            //    "Eliminar",
            //    MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Question
            //);

            //if (result == DialogResult.Yes)
            //{
            //    await _form._memoryCache.DeleteCacheAsync<MesaExamen>(_form.mesaExamenCurrent.Id);
            //}
            //_form.mesaExamenCurrent = null;
            _form.TransitionTo(new InitialDisplayState(_form));
        }


        // Estos métodos no aplican en este estado
        public Task LoadData() => Task.CompletedTask;
        public void LoadGrid()  { }
        public void LoadGridFilter(string filterText) {}
        public void OnBuscar() { }
        public void UpdateUI() { }
        public Task OnGuardar() => Task.CompletedTask;
        public void OnCancelar() { }
        public void OnSalir() => _form.Close();
        public void LoadComboboxCiclosLectivos() {}
        public void LoadComboboxTurnosExamenes() {}
        public void LoadComboboxCarreras() {}
        public void LoadComboboxAniosCarreras() {}
        public void LoadComboboxMaterias() {}
        public void LoadComboboxDocentes() {}
        public void LoadComboboxTipoIntegrante(){}
        public void OnAgregarDocenteADetalle() {}
        public void OnQuitarDocenteDeDetalle() {}
        public void OnEditarDocenteDeDetalle() {}
    }
}
