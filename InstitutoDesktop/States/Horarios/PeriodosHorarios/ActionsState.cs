using InstitutoDesktop.ExtensionMethods;
using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Util;
using InstitutoDesktop.Views;
using InstitutoDesktop.Views.Commons;
using InstitutoDesktop.Views.Horarios;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Horarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoDesktop.States.Horarios.PeriodosHorarios
{
    public class ActionsState : IPeriodosHorariosViewState
    {
        private readonly PeriodosHorariosView _form;

        public ActionsState(PeriodosHorariosView form)
        {
            _form = form;
        }

        public void OnAgregar()
        {
            _form.periodoHorarioCurrent = new PeriodoHorario();
            _form.TransitionTo(new EditionState(_form));
        }

        public void OnModificar()
        {
            if (_form.Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un período de horarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _form.periodoHorarioCurrent = (PeriodoHorario)_form.Grilla.CurrentRow.DataBoundItem;
            _form.TransitionTo(new EditionState(_form));
        }

        public async Task OnEliminar()
        {
            _form.periodoHorarioCurrent = (PeriodoHorario)_form.Grilla.CurrentRow.DataBoundItem;
            var result = MessageBox.Show(
                $"¿Está seguro que desea eliminar el período de horarios {_form.periodoHorarioCurrent.Nombre}?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                await _form._memoryCache.DeleteCacheAsync<PeriodoHorario>(_form.periodoHorarioCurrent.Id);
            }
            _form.periodoHorarioCurrent = null;
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
