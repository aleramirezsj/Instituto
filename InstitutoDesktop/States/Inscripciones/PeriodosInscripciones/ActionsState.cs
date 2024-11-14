using InstitutoDesktop.ExtensionMethods;
using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Util;
using InstitutoDesktop.Views;
using InstitutoDesktop.Views.Commons;
using InstitutoDesktop.Views.Horarios;
using InstitutoDesktop.Views.Inscripciones;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Horarios;
using InstitutoServices.Models.Inscripciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoDesktop.States.Inscripciones.PeriodosInscripciones
{
    public class ActionsState : IPeriodosInscripcionesViewState
    {
        private readonly PeriodosInscripcionesView _form;

        public ActionsState(PeriodosInscripcionesView form)
        {
            _form = form;
        }

        public void OnAgregar()
        {
            _form.periodoInscripcionCurrent = new PeriodoInscripcion();
            _form.TransitionTo(new EditionState(_form));
        }

        public void OnModificar()
        {
            if (_form.Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un período de inscripciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _form.periodoInscripcionCurrent = (PeriodoInscripcion)_form.Grilla.CurrentRow.DataBoundItem;
            _form.TransitionTo(new EditionState(_form));
        }

        public async Task OnEliminar()
        {
            _form.periodoInscripcionCurrent = (PeriodoInscripcion)_form.Grilla.CurrentRow.DataBoundItem;
            var result = MessageBox.Show(
                $"¿Está seguro que desea eliminar el período de inscripciones {_form.periodoInscripcionCurrent.Nombre}?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                await _form._memoryCache.DeleteCacheAsync<PeriodoInscripcion>(_form.periodoInscripcionCurrent.Id);
            }
            _form.periodoInscripcionCurrent = null;
            _form.TransitionTo(new InitialDisplayState(_form));
        }


        // Estos métodos no aplican en este estado
        public Task LoadData() => Task.CompletedTask;
        public Task LoadGrid() => Task.CompletedTask;
        public Task LoadGridFilter(string filterText) => Task.CompletedTask;
        public void OnBuscar() { }
        public void UpdateUI() { }
        public Task OnGuardar() => Task.CompletedTask;
        public void OnCancelar() { }
        public void OnSalir() => _form.Close();
        public Task LoadComboboxCiclosLectivos()=> Task.CompletedTask;



    }
}
