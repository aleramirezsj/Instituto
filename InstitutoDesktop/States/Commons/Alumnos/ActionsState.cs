using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Views.Commons;
using InstitutoDesktop.Views.MesasExamenes;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Inscripciones;
using InstitutoServices.Models.MesasExamenes;

namespace InstitutoDesktop.States.Commons.Alumnos
{
    public class ActionsState : IAlumnosViewState
    {
        private readonly AlumnosView _form;

        public ActionsState(AlumnosView form)
        {
            _form = form;
        }

        public void OnAgregar()
        {
            _form.alumnoCurrent = new Alumno();
            _form.TransitionTo(new EditionState(_form));
        }

        public void OnModificar()
        {
            if (_form.Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un alumno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _form.alumnoCurrent = (Alumno)_form.Grilla.CurrentRow.DataBoundItem;
            _form.TransitionTo(new EditionState(_form));
        }

        public async Task OnEliminar()
        {
            _form.alumnoCurrent = (Alumno)_form.Grilla.CurrentRow.DataBoundItem;
            var result = MessageBox.Show(
                $"¿Está seguro que desea eliminar al alumno {_form.alumnoCurrent.ApellidoNombre}?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                await _form._memoryCache.DeleteCacheAsync<Alumno>(_form.alumnoCurrent.Id);
            }
            _form.alumnoCurrent = null;
            _form.TransitionTo(new InitialDisplayState(_form));
        }


        // Estos métodos no aplican en este estado
        public Task LoadData() => Task.CompletedTask;
        public void LoadGrid() {}
        public void LoadGridFilter(string filterText) {}
        public void OnBuscar() { }
        public void UpdateUI() { }
        public Task OnGuardar() => Task.CompletedTask;
        public void OnCancelar() { }
        public void OnSalir() => _form.Close();



    }
}
