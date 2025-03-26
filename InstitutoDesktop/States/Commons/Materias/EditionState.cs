using InstitutoDesktop.Interfaces.Commons;
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
    public class EditionState : IMateriasViewState
    {
        private readonly MateriasView _form;

        public EditionState(MateriasView form)
        {
            _form = form;
            UpdateUI();
        }

        public async Task OnGuardar()
        {
            if (string.IsNullOrEmpty(_form.txtNombre.Text))
            {
                MessageBox.Show("Debe definirse un nombre para la materia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _form.materiaCurrent.Nombre = _form.txtNombre.Text;
            _form.materiaCurrent.AnioCarreraId = (int)_form.comboBoxAñosCarreras.SelectedValue;
            _form.materiaCurrent.TipoPeriodo = (TipoPeriodoEnum)_form.comboBoxTipoPeriodo.SelectedItem;
            _form.materiaCurrent.TipoMateria = (TipoMateriaEnum)_form.comboBoxTipoMateria.SelectedItem;
            _form.materiaCurrent.EsRecreo = _form.chkEsRecreo.Checked;

            if (_form.materiaCurrent.Id == 0)
            {
                await _form._memoryCache.AddCacheAsync<Materia>(_form.materiaCurrent);
            }
            else
            {
                await _form._memoryCache.UpdateCacheAsync<Materia>(_form.materiaCurrent);
            }

            _form.TransitionTo(new DisplayGridState(_form));
        }

        public void OnCancelar()
        {
            _form.materiaCurrent = null;
            _form.TransitionTo(new DisplayGridState(_form));
            
        }

        public void UpdateUI()
        {
            _form.tabPageAgregarEditar.Enabled = true;
            _form.tabPageLista.Enabled = false;
            _form.tabControl.SelectTab(_form.tabPageAgregarEditar);

            _form.txtNombre.Text = _form.materiaCurrent.Nombre;
            _form.comboBoxTipoPeriodo.SelectedItem = _form.materiaCurrent.TipoPeriodo;
            _form.comboBoxTipoMateria.SelectedItem = _form.materiaCurrent.TipoMateria;
            _form.chkEsRecreo.Checked = _form.materiaCurrent.EsRecreo;

        }

        // Estos métodos no aplican en este estado
        public Task LoadData() => Task.CompletedTask;
        public void LoadGrid(string filterText) {}
        public void OnAgregar() { }
        public void OnModificar() { }
        public void OnBuscar() { }
        public Task OnEliminar() => Task.CompletedTask;
        public void OnSalir() => _form.Close();

        public Task LoadComboboxCarreras() => Task.CompletedTask;

        public Task LoadComboboxAniosCarreras() => Task.CompletedTask;
    }
}
