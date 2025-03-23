using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Views;
using InstitutoDesktop.Views.Commons;
using InstitutoServices.Models.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoDesktop.States.Docentes
{
    public class EditionState : ICrudViewState
    {
        private readonly DocentesView _form;

        public EditionState(DocentesView form)
        {
            _form = form;
            UpdateUI();
        }

        public async Task OnGuardar()
        {
            if (string.IsNullOrEmpty(_form.txtNombre.Text))
            {
                MessageBox.Show("Debe definirse un nombre para el docente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _form.docenteCurrent.Nombre = _form.txtNombre.Text;

            if (_form.docenteCurrent.Id == 0)
            {
                await _form._memoryCache.AddCacheAsync<Docente>(_form.docenteCurrent);
            }
            else
            {
                await _form._memoryCache.UpdateCacheAsync<Docente>(_form.docenteCurrent);
            }

            _form.TransitionTo(new DisplayGridState(_form));
        }

        public void OnCancelar()
        {
            _form.docenteCurrent = null;
            _form.TransitionTo(new DisplayGridState(_form));
        }

        public void UpdateUI()
        {
            _form.tabPageAgregarEditar.Enabled = true;
            _form.tabPageLista.Enabled = false;
            _form.tabControl.SelectTab(_form.tabPageAgregarEditar);

            _form.txtNombre.Text = _form.docenteCurrent.Nombre;
        }

        // Estos métodos no aplican en este estado
        public Task LoadData() => Task.CompletedTask;
        public void LoadGrid(string filterText) {}
        public void OnAgregar() { }
        public void OnModificar() { }
        public void OnBuscar() { }
        public Task OnEliminar() => Task.CompletedTask;
        public void OnSalir() => _form.Close();
    }
}
