using InstitutoDesktop.Interfaces.Horarios;
using InstitutoDesktop.Views;
using InstitutoServices.Models.Horarios;
using InstitutoServices.Models.MesasExamenes;

namespace InstitutoDesktop.States.Horarios.Horarios
{
    public class ActionsState : IHorariosViewState
    {
        private readonly HorariosView _form;

        public ActionsState(HorariosView form)
        {
            _form = form;
        }

        public void OnAgregar()
        {
            _form.horarioCurrent = new Horario();
            _form.TransitionTo(new EditionState(_form));
        }

        public void OnModificar()
        {
            if (_form.dataGridHorarios.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un horario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _form.horarioCurrent = (Horario)_form.dataGridHorarios.CurrentRow.DataBoundItem;
            _form.TransitionTo(new EditionState(_form));
        }

        public async Task OnEliminar()
        {
            _form.horarioCurrent = (Horario)_form.dataGridHorarios.CurrentRow.DataBoundItem;
            var result = MessageBox.Show(
                $"¿Está seguro que desea eliminar el horario de la materia {_form.horarioCurrent.Materia.Nombre}?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                await _form._memoryCache.DeleteCacheAsync<Horario>(_form.horarioCurrent.Id);
            }
            _form.horarioCurrent = null;
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
        public void LoadComboboxPeriodosHorarios() {}
        public void LoadComboboxCarreras() {}
        public void LoadComboboxAniosCarreras() {}
        public void LoadComboboxMaterias() {}
        public void LoadComboboxDocentes() {}
        public void LoadComboboxDias(){}
        public void LoadComboboxAulas() { }
        public void LoadComboboxHoras() { }
        public void OnAgregarDocenteAIntegrantes() { }
        public void OnQuitarDocenteDeIntegrantes() { }
        public void OnAgregarHoraADetalle() { }
        public void OnEditarHoraDeDetalle() { }
        public void OnQuitarHoraDeDetalle() { }
    }
}
