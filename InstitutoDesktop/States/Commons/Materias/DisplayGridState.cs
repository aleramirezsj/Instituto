using InstitutoDesktop.ExtensionMethods;
using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Util;
using InstitutoDesktop.Views;
using InstitutoDesktop.Views.Commons;
using InstitutoServices.Enums;
using InstitutoServices.Models.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoDesktop.States.Commons.Materias
{
    public class DisplayGridState : IMateriasViewState
    {
        private readonly MateriasView _form;

        public DisplayGridState(MateriasView form)
        {
            _form = form;
            UpdateUI();
        }

        private void LoadComboTipoMaterias()
        {
            _form.comboBoxTipoMateria.DataSource = Enum.GetValues(typeof(TipoMateriaEnum));
        }

        public async Task LoadData()
        {
            ShowInActivity.Show("Cargando las materias, carreras y sus años...");
            _form.listaMaterias = await _form._memoryCache.GetAllCacheAsync<Materia>();
            ShowInActivity.Hide();
            await LoadComboboxCarreras();
            await LoadComboboxAniosCarreras();
            LoadComboTipoMaterias();
            LoadGrid();
        }

        public void LoadGrid()
        {
            var anioCarrera=_form.comboBoxAñosCarreras.SelectedItem as AnioCarrera;

            if (_form.listaMaterias != null && _form.listaMaterias.Count > 0)
                _form.Grilla.DataSource = _form.listaMaterias.Where(materia=>materia.AnioCarreraId.Equals(anioCarrera.Id)).OrderBy(materia => materia.Nombre).ToList();
            _form.Grilla.OcultarColumnas(new string[] { "Id", "AnioCarrera", "AnioCarreraId", "Eliminado" });
        }

        public void LoadGridFilter(string filterText)
        {
            var anioCarrera = _form.comboBoxAñosCarreras.SelectedItem as AnioCarrera;

            if (_form.listaMaterias != null && _form.listaMaterias.Count > 0)
                _form.Grilla.DataSource = _form.listaMaterias
                    .Where(materia => materia.Nombre.ToUpper().Contains(filterText.ToUpper())&&
                           materia.AnioCarreraId.Equals(anioCarrera.Id))
                    .OrderBy(materia => materia.Nombre)
                    .ToList();
            _form.Grilla.OcultarColumnas(new string[] { "Id", "AnioCarrera", "AnioCarreraId", "Eliminado" });
        }

        public void OnAgregar()
        {
            _form.materiaCurrent = new Materia();
            _form.TransitionTo(new EditionState(_form));
        }

        public void OnModificar()
        {
            if (_form.Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una materia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _form.materiaCurrent = (Materia)_form.Grilla.CurrentRow.DataBoundItem;
            _form.TransitionTo(new EditionState(_form));
        }

        public async Task OnEliminar()
        {
            _form.materiaCurrent = (Materia)_form.Grilla.CurrentRow.DataBoundItem;
            var result = MessageBox.Show(
                $"¿Está seguro que desea eliminar la materia {_form.materiaCurrent.Nombre}?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                await _form._memoryCache.DeleteCacheAsync<Materia>(_form.materiaCurrent.Id);
                LoadGrid();
            }
            _form.materiaCurrent = null;
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
            
            LoadGrid();
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
            ShowInActivity.Show("Cargando las carreras...");
            _form.comboBoxCarreras.DataSource= await _form._memoryCache.GetAllCacheAsync<Carrera>();
            ShowInActivity.Hide();
            _form.comboBoxCarreras.DisplayMember = "Nombre";
            _form.comboBoxCarreras.ValueMember = "Id";
        }

        public async Task LoadComboboxAniosCarreras()
        {
            ShowInActivity.Show("Cargando años de las carreras...");
            _form.comboBoxAñosCarreras.DataSource = (await _form._memoryCache.GetAllCacheAsync<AnioCarrera>()).
                                                    Where(anio => anio.CarreraId.Equals((int)_form.comboBoxCarreras.SelectedValue)).ToList();
                                                    ;
            ShowInActivity.Hide();
            _form.comboBoxAñosCarreras.DisplayMember = "Nombre";
            _form.comboBoxAñosCarreras.ValueMember = "Id";
        }
    }
}
