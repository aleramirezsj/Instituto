using InstitutoDesktop.ExtensionMethods;
using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Util;
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
    public class DisplayGridAniosCarrerasViewState : IAniosCarrerasViewState
    {
        private readonly AniosCarrerasView _form;

        public DisplayGridAniosCarrerasViewState(AniosCarrerasView form)
        {
            _form = form;
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            await LoadComboboxCarreras();
            UpdateUI();
        }

        public async Task LoadData()
        {
            ShowInActivity.Show("Cargando años de las carreras...");
            _form.listaAniosCarreras = await _form._memoryCache.GetAllCacheAsync<AnioCarrera>();
            ShowInActivity.Hide();
            await LoadComboboxCarreras();
            await LoadGrid();
        }

        public async Task LoadGrid()
        {
            if (_form.listaAniosCarreras != null && _form.listaAniosCarreras.Count > 0)
                _form.Grilla.DataSource = _form.listaAniosCarreras.Where(anio=>anio.CarreraId.Equals((int)_form.comboBoxCarreras.SelectedValue)).OrderBy(anio => anio.Nombre).ToList();
            _form.Grilla.OcultarColumnas(new string[] { "Id", "Carrera", "CarreraId", "AñoYCarrera", "Eliminado" });
        }

        public async Task LoadGridFilter(string filterText)
        {
            if (_form.listaAniosCarreras != null && _form.listaAniosCarreras.Count > 0)
                _form.Grilla.DataSource = _form.listaAniosCarreras
                    .Where(anio => anio.Nombre.ToUpper().Contains(filterText.ToUpper())&&
                           anio.CarreraId.Equals((int)_form.comboBoxCarreras.SelectedValue))
                    .OrderBy(anio => anio.Nombre)
                    .ToList();
            _form.Grilla.OcultarColumnas(new string[] { "Id", "Carrera","CarreraId", "AñoYCarrera","Eliminado" });
        }

        public void OnAgregar()
        {
            _form.anioCarreraCurrent = new AnioCarrera();
            _form.TransitionTo(new EditionAniosCarrerasViewState(_form));
        }

        public void OnModificar()
        {
            if (_form.Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un año de carrera", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _form.anioCarreraCurrent = (AnioCarrera)_form.Grilla.CurrentRow.DataBoundItem;
            _form.TransitionTo(new EditionAniosCarrerasViewState(_form));
        }

        public async Task OnEliminar()
        {
            _form.anioCarreraCurrent = (AnioCarrera)_form.Grilla.CurrentRow.DataBoundItem;
            var result = MessageBox.Show(
                $"¿Está seguro que desea eliminar el año {_form.anioCarreraCurrent.Nombre}?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                await _form._memoryCache.DeleteCacheAsync<AnioCarrera>(_form.anioCarreraCurrent.Id);
                await LoadGrid();
            }
            _form.anioCarreraCurrent = null;
        }

        public void OnBuscar()
        {
            if (string.IsNullOrEmpty(_form.txtFiltro.Text))
                LoadGrid();
            else
                LoadGridFilter(_form.txtFiltro.Text);
        }

        public async void UpdateUI()
        {
            
            await LoadGrid();
            _form.tabPageAgregarEditar.Enabled = false;
            _form.tabPageLista.Enabled = true;
            _form.tabControl.SelectTab(_form.tabPageLista);
        }

        // Estos métodos no aplican en este estado
        public Task OnGuardar() => Task.CompletedTask;
        public void OnCancelar() { }
        public void OnSalir() => _form.Close();

        public async Task LoadComboboxCarreras()
        {
            ShowInActivity.Show("Cargando años de las carreras...");
            _form.comboBoxCarreras.DataSource= await _form._memoryCache.GetAllCacheAsync<Carrera>();
            ShowInActivity.Hide();
            _form.comboBoxCarreras.DisplayMember = "Nombre";
            _form.comboBoxCarreras.ValueMember = "Id";
        }


    }
}
