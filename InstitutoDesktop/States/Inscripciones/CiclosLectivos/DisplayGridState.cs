using InstitutoDesktop.ExtensionMethods;
using InstitutoDesktop.Interfaces.Inscripciones;
using InstitutoDesktop.Util;
using InstitutoDesktop.Views;
using InstitutoServices.Models.Inscripciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoDesktop.States.Inscripciones.CiclosLectivos
{
    public class DisplayGridState : ICiclosLectivosState
    {
        private readonly CilosLectivosView _form;

        public DisplayGridState(CilosLectivosView form)
        {
            _form = form;
            UpdateUI();
        }

        public async Task LoadData()
        {
            ShowInActivity.Show("Cargando ciclos lectivos...");
            _form.listaCicloLectivos = await _form._memoryCache.GetAllCacheAsync<CicloLectivo>("CiclosLectivos");
            ShowInActivity.Hide();
            await LoadGrid();
        }

        public async Task LoadGrid()
        {
            if (_form.listaCicloLectivos != null && _form.listaCicloLectivos.Count > 0)
                _form.Grilla.DataSource = _form.listaCicloLectivos.OrderBy(ciclo => ciclo.Nombre).ToList();
            _form.Grilla.OcultarColumnas(new string[] { "Id", "Eliminado" });
        }

        public async Task LoadGridFilter(string filterText)
        {
            if (_form.listaCicloLectivos != null && _form.listaCicloLectivos.Count > 0)
                _form.Grilla.DataSource = _form.listaCicloLectivos
                    .Where(ciclo => ciclo.Nombre.ToUpper().Contains(filterText.ToUpper()))
                    .OrderBy(ciclo => ciclo.Nombre)
                    .ToList();
            _form.Grilla.OcultarColumnas(new string[] { "Id", "Eliminado" });
        }

        public void OnAgregar()
        {
            _form.cicloLectivoCurrent = new CicloLectivo();
            _form.TransitionTo(new EditionState(_form));
        }

        public void OnModificar()
        {
            if (_form.Grilla.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un ciclo lectivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _form.cicloLectivoCurrent = (CicloLectivo)_form.Grilla.CurrentRow.DataBoundItem;
            _form.TransitionTo(new EditionState(_form));
        }

        public async Task OnEliminar()
        {
            _form.cicloLectivoCurrent = (CicloLectivo)_form.Grilla.CurrentRow.DataBoundItem;
            var result = MessageBox.Show(
                $"¿Está seguro que desea eliminar el ciclo lectivo {_form.cicloLectivoCurrent.Nombre}?",
                "Eliminar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                await _form._memoryCache.DeleteCacheAsync<CicloLectivo>(_form.cicloLectivoCurrent.Id, "CiclosLectivos");
                await LoadGrid();
            }
            _form.cicloLectivoCurrent = null;
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