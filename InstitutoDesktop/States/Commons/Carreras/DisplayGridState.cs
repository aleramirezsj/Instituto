using InstitutoDesktop.ExtensionMethods;
using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Util;
using InstitutoDesktop.Views;
using InstitutoDesktop.Views.Commons;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Inscripciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoDesktop.States.Commons.Carreras
{
    public class DisplayGridState : ICrudViewState
    {
        private readonly CarrerasView _form;

        public DisplayGridState(CarrerasView form)
        {
            _form = form;
            UpdateUI();
        }

        public async Task LoadData()
        {
            ShowInActivity.Show("Cargando Aulas...");
            _form.listaCarreras = await _form._memoryCache.GetAllCacheAsync<Carrera>();
            ShowInActivity.Hide();
            LoadGrid(_form.txtFiltro.Text);
        }

        public void LoadGrid(string filterText)
        {
            if (_form.listaCarreras != null && _form.listaCarreras.Count > 0)
                _form.Grilla.DataSource = _form.listaCarreras
                    .Where(ciclo => ciclo.Nombre.ToUpper().Contains(filterText.ToUpper()))
                    .OrderBy(ciclo => ciclo.Nombre)
                    .ToList();
            _form.Grilla.OcultarColumnas(new string[] { "Id", "Eliminado" });
        }

        public void OnAgregar()
        {
            _form.carreraCurrent = new Carrera();
            _form.TransitionTo(new EditionState(_form));
        }

        public void OnModificar()
        {
            if (_form.Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un aula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _form.carreraCurrent = (Carrera)_form.Grilla.CurrentRow.DataBoundItem;
            _form.TransitionTo(new EditionState(_form));
        }

        public async Task OnEliminar()
        {
            _form.carreraCurrent = (Carrera)_form.Grilla.CurrentRow.DataBoundItem;
            var result = MessageBox.Show(
                $"¿Está seguro que desea eliminar la carrera  {_form.carreraCurrent.Nombre}?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                await _form._memoryCache.DeleteCacheAsync<Carrera>(_form.carreraCurrent.Id);
                LoadGrid(_form.txtFiltro.Text);
            }
            _form.carreraCurrent = null;
        }
        public void OnBuscar()
        {
            LoadGrid(_form.txtFiltro.Text);
        }

        public void UpdateUI()
        {
            LoadGrid(_form.txtFiltro.Text);
            _form.tabPageAgregarEditar.Enabled = false;
            _form.tabPageLista.Enabled = true;
            _form.tabControl.SelectTab(_form.tabPageLista);
        }

        // Estos métodos no aplican en este estado
        public Task OnGuardar() => Task.CompletedTask;
        public void OnCancelar() { }
        public void OnSalir() => _form.Close();
    }
}
