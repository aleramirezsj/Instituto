using InstitutoDesktop.Interfaces.Inscripciones;
using InstitutoDesktop.Views;
using InstitutoServices.Models.Inscripciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoDesktop.States.Inscripciones.CiclosLectivos
{
    public class EditionState : ICiclosLectivosState
    {
        private readonly CilosLectivosView _form;

        public EditionState(CilosLectivosView form)
        {
            _form = form;
            UpdateUI();
        }

        public async Task OnGuardar()
        {
            if (string.IsNullOrEmpty(_form.txtNombre.Text))
            {
                MessageBox.Show("Debe definirse un nombre para el ciclo lectivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _form.cicloLectivoCurrent.Nombre = _form.txtNombre.Text;
            _form.cicloLectivoCurrent.Actual = _form.chkActual.Checked;

            if (_form.cicloLectivoCurrent.Id == 0)
            {
                await _form._memoryCache.AddCacheAsync<CicloLectivo>(_form.cicloLectivoCurrent, "CiclosLectivos");
            }
            else
            {
                await _form._memoryCache.UpdateCacheAsync<CicloLectivo>(_form.cicloLectivoCurrent, "CiclosLectivos");
            }

            _form.TransitionTo(new DisplayGridState(_form));
        }

        public void OnCancelar()
        {
            _form.cicloLectivoCurrent = null;
            _form.TransitionTo(new DisplayGridState(_form));
        }

        public void UpdateUI()
        {
            _form.tabPageAgregarEditar.Enabled = true;
            _form.tabPageLista.Enabled = false;
            _form.tabControl.SelectTab(_form.tabPageAgregarEditar);

            _form.txtNombre.Text = _form.cicloLectivoCurrent.Nombre;
            _form.chkActual.Checked = _form.cicloLectivoCurrent.Actual;
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
    }
}