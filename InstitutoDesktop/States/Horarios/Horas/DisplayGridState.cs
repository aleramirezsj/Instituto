using InstitutoDesktop.ExtensionMethods;
using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Util;
using InstitutoDesktop.Views;
using InstitutoDesktop.Views.Commons;
using InstitutoDesktop.Views.Horarios;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Horarios;
using InstitutoServices.Models.Inscripciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoDesktop.States.Horarios.Horas
{
    public class DisplayGridState : IBaseViewState
    {
        private readonly HorasView _form;

        public DisplayGridState(HorasView form)
        {
            _form = form;
            UpdateUI();
        }

        public async Task LoadData()
        {
            ShowInActivity.Show("Cargando Horas...");
            _form.listaHoras = await _form._memoryCache.GetAllCacheAsync<Hora>();
            ShowInActivity.Hide();
            await LoadGrid();
        }

        public async Task LoadGrid()
        {
            if (_form.listaHoras != null && _form.listaHoras.Count > 0)
                _form.Grilla.DataSource = _form.listaHoras.OrderBy(ciclo => ciclo.Nombre).ToList();
            _form.Grilla.OcultarColumnas(new string[] { "Id", "Desde", "Hasta", "Eliminado" });
        }

        public async Task LoadGridFilter(string filterText)
        {
            if (_form.listaHoras != null && _form.listaHoras.Count > 0)
                _form.Grilla.DataSource = _form.listaHoras
                    .Where(ciclo => ciclo.Nombre.ToUpper().Contains(filterText.ToUpper()))
                    .OrderBy(ciclo => ciclo.Nombre)
                    .ToList();
            _form.Grilla.OcultarColumnas(new string[] { "Id", "Desde","Hasta", "Eliminado" });
        }

        public void OnAgregar()
        {
            _form.horaCurrent = new Hora();
            _form.TransitionTo(new EditionState(_form));
        }

        public void OnModificar()
        {
            if (_form.Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una hora", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _form.horaCurrent = (Hora)_form.Grilla.CurrentRow.DataBoundItem;
            _form.TransitionTo(new EditionState(_form));
        }

        public async Task OnEliminar()
        {
            _form.horaCurrent = (Hora)_form.Grilla.CurrentRow.DataBoundItem;
            var result = MessageBox.Show(
                $"¿Está seguro que desea eliminar la hora  {_form.horaCurrent.Nombre}?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                await _form._memoryCache.DeleteCacheAsync<Hora>(_form.horaCurrent.Id);
                await LoadGrid();
            }
            _form.horaCurrent = null;
        }
        public void OnBuscar()
        {
            if (_form.txtFiltro.Text == "")
                LoadGrid();
            else
                LoadGridFilter(_form.txtFiltro.Text);
        }

        public void UpdateUI()
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
    }
}
