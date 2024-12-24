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

namespace InstitutoDesktop.States.Commons.Aulas
{
    public class DisplayGridState : ICrudViewState
    {
        private readonly AulasView _form;

        public DisplayGridState(AulasView form)
        {
            _form = form;
            UpdateUI();
        }

        public async Task LoadData()
        {
            ShowInActivity.Show("Cargando Aulas...");
            _form.listaAulas = await _form._memoryCache.GetAllCacheAsync<Aula>();
            ShowInActivity.Hide();
            LoadGrid();
        }

        public void LoadGrid()
        {
            if (_form.listaAulas != null && _form.listaAulas.Count > 0)
                _form.Grilla.DataSource = _form.listaAulas.OrderBy(ciclo => ciclo.Nombre).ToList();
            _form.Grilla.OcultarColumnas(new string[] { "Id", "Eliminado" });
        }

        public void LoadGridFilter(string filterText)
        {
            if (_form.listaAulas != null && _form.listaAulas.Count > 0)
                _form.Grilla.DataSource = _form.listaAulas
                    .Where(ciclo => ciclo.Nombre.ToUpper().Contains(filterText.ToUpper()))
                    .OrderBy(ciclo => ciclo.Nombre)
                    .ToList();
            _form.Grilla.OcultarColumnas(new string[] { "Id", "Eliminado" });
        }

        public void OnAgregar()
        {
            _form.aulaCurrent = new Aula();
            _form.TransitionTo(new EditionState(_form));
        }

        public void OnModificar()
        {
            if (_form.Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un aula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _form.aulaCurrent = (Aula)_form.Grilla.CurrentRow.DataBoundItem;
            _form.TransitionTo(new EditionState(_form));
        }

        public async Task OnEliminar()
        {
            _form.aulaCurrent = (Aula)_form.Grilla.CurrentRow.DataBoundItem;
            var result = MessageBox.Show(
                $"¿Está seguro que desea eliminar el aula {_form.aulaCurrent.Nombre}?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                await _form._memoryCache.DeleteCacheAsync<Aula>(_form.aulaCurrent.Id);
                LoadGrid();
            }
            _form.aulaCurrent = null;
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
