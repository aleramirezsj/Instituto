using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Views;
using InstitutoDesktop.Views.Commons;
using InstitutoServices.Models.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoDesktop.States.Commons.AniosCarreras
{
    public class EditionState : IAniosCarrerasViewState
    {
        private readonly AniosCarrerasView _form;

        public EditionState(AniosCarrerasView form)
        {
            _form = form;
            UpdateUI();
        }

        public async Task OnGuardar()
        {
            if (string.IsNullOrEmpty(_form.txtNombre.Text))
            {
                MessageBox.Show("Debe definirse un nombre para el año de la carrera", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _form.anioCarreraCurrent.Nombre = _form.txtNombre.Text;
            _form.anioCarreraCurrent.CarreraId = (int)_form.comboBoxCarreras.SelectedValue;

            if (_form.anioCarreraCurrent.Id == 0)
            {
                await _form._memoryCache.AddCacheAsync<AnioCarrera>(_form.anioCarreraCurrent);
            }
            else
            {
                await _form._memoryCache.UpdateCacheAsync<AnioCarrera>(_form.anioCarreraCurrent);
            }

            _form.TransitionTo(new InitialDisplayState(_form));
        }

        public void OnCancelar()
        {
            _form.anioCarreraCurrent = null;
            _form.TransitionTo(new InitialDisplayState(_form));
        }

        public void UpdateUI()
        {
            _form.tabPageAgregarEditar.Enabled = true;
            _form.tabPageLista.Enabled = false;
            _form.tabControl.SelectTab(_form.tabPageAgregarEditar);

            _form.txtNombre.Text = _form.anioCarreraCurrent.Nombre;
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

        public Task LoadComboboxCarreras() => Task.CompletedTask;
    }
}
