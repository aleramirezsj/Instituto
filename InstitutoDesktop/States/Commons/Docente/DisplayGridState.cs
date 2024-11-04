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

namespace InstitutoDesktop.States.Docentes
{
    public class DisplayGridState : IDocentesState
    {
        private readonly DocentesView _form;

        public DisplayGridState(DocentesView form)
        {
            _form = form;
            UpdateUI();
        }

        public async Task LoadData()
        {
            ShowInActivity.Show("Cargando docentes...");
            _form.listaDocente = await _form._memoryCache.GetAllCacheAsync<Docente>("Docentes");
            ShowInActivity.Hide();
            await LoadGrid();
        }

        public async Task LoadGrid()
        {
            if (_form.listaDocente != null && _form.listaDocente.Count > 0)
                _form.Grilla.DataSource = _form.listaDocente.OrderBy(docente => docente.Nombre).ToList();
            _form.Grilla.OcultarColumnas(new string[] { "Id", "Eliminado" });
        }

        public async Task LoadGridFilter(string filterText)
        {
            if (_form.listaDocente != null && _form.listaDocente.Count > 0)
                _form.Grilla.DataSource = _form.listaDocente
                    .Where(docente => docente.Nombre.ToUpper().Contains(filterText.ToUpper()))
                    .OrderBy(docente => docente.Nombre)
                    .ToList();
            _form.Grilla.OcultarColumnas(new string[] { "Id", "Eliminado" });
        }

        public void OnAgregar()
        {
            _form.docenteCurrent = new Docente();
            _form.TransitionTo(new EditionState(_form));
        }

        public void OnModificar()
        {
            if (_form.Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un docente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _form.docenteCurrent = (Docente)_form.Grilla.CurrentRow.DataBoundItem;
            _form.TransitionTo(new EditionState(_form));
        }

        public async Task OnEliminar()
        {
            _form.docenteCurrent = (Docente)_form.Grilla.CurrentRow.DataBoundItem;
            var result = MessageBox.Show(
                $"¿Está seguro que desea eliminar al docente {_form.docenteCurrent.Nombre}?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                await _form._memoryCache.DeleteCacheAsync<Docente>(_form.docenteCurrent.Id, "Docentes");
                await LoadGrid();
            }
            _form.docenteCurrent = null;
        }

        public void OnBuscar()
        {
            if (string.IsNullOrEmpty(_form.txtFiltro.Text))
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
