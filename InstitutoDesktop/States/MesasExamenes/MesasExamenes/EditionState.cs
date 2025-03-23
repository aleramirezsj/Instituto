using InstitutoDesktop.ExtensionMethods;
using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Interfaces.MesasExamenes;
using InstitutoDesktop.Views;
using InstitutoDesktop.Views.Inscripciones;
using InstitutoDesktop.Views.MesasExamenes;
using InstitutoServices.Enums;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Horarios;
using InstitutoServices.Models.Inscripciones;
using InstitutoServices.Models.MesasExamenes;

namespace InstitutoDesktop.States.MesasExamenes.MesasExamenes
{
    public class EditionState : IMesasExamenesViewState
    {
        private readonly MesasExamenesView _form;

        public EditionState(MesasExamenesView form)
        {
            _form = form;
            _form.dateTime1erLlamado.ValueChanged += (s, e) => _form.dateTime2doLlamado.Value = _form.dateTime1erLlamado.Value.AddDays(14);
            _form.dataGridDetallesMesa.DataBindingComplete += (s, e) => _form.dataGridDetallesMesa.OcultarColumnas(new string[] { "DocenteId", "MesaExamen", "MesaExamenId", "Id", "Eliminado" });
            _form.dataGridDetallesMesa.DataBindingComplete+= (s, e) => EnableDisabledEditarQuitarDocente();
            _form.cboMaterias.SelectedIndexChanged += (s, e) => SeleccionarDocenteDeMateriaSeleccionada();
            UpdateUI();

        }

        private async void SeleccionarDocenteDeMateriaSeleccionada()
        {
            if(_form.cboMaterias.SelectedValue == null) return;
            var periodoHorarioActual= (await _form._memoryCache.GetAllCacheAsync<PeriodoHorario>())
                                           .FirstOrDefault(periodo => periodo.Actual);
            var horario = (await _form._memoryCache.GetAllCacheAsync<Horario>())
                .FirstOrDefault(h => h.MateriaId.Equals((int)_form.cboMaterias.SelectedValue) &&
                h.PeriodoHorarioId.Equals(periodoHorarioActual.Id));
            if (horario != null)
                _form.cboDocentes.SelectedValue = horario.IntegrantesHorario.FirstOrDefault().DocenteId;
            
        }

        private void EnableDisabledEditarQuitarDocente()
        {
            _form.BtnEditarDocenteDeDetalle.Enabled = _form.dataGridDetallesMesa.Rows.Count > 0;
            _form.btnQuitarDocenteDeDetalle.Enabled = _form.dataGridDetallesMesa.Rows.Count > 0;
        }

        public async Task OnGuardar()
        {
            if(!ControlDataInsert()) return;

            var turnoExamen = (TurnoExamen)_form.cboTurnosExamenes.SelectedItem;
            _form.mesaExamenCurrent.MateriaId = (int)_form.cboMaterias.SelectedValue;
            _form.mesaExamenCurrent.Materia = (Materia)_form.cboMaterias.SelectedItem;
            _form.mesaExamenCurrent.Llamado1 = _form.dateTime1erLlamado.Value;
            _form.mesaExamenCurrent.Llamado2 = turnoExamen.TieneLLamado2 ? _form.dateTime2doLlamado.Value : DateTime.MinValue;
            _form.mesaExamenCurrent.Horario = _form.txtHorario.Text;
            _form.mesaExamenCurrent.TurnoExamenId = (int)_form.cboTurnosExamenes.SelectedValue;
            _form.mesaExamenCurrent.TurnoExamen = turnoExamen;

            if (_form.mesaExamenCurrent.Id == 0)
                await _form._memoryCache.AddCacheAsync<MesaExamen>(_form.mesaExamenCurrent);
            else
                await _form._memoryCache.UpdateCacheAsync<MesaExamen>(_form.mesaExamenCurrent);
    
            _form.TransitionTo(new InitialDisplayState(_form));
            //await _form._currentState.LoadData();
        }

        private bool ControlDataInsert()
        {
            if (_form.cboMaterias.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una materia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_form.cboTurnosExamenes.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un turno de examen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_form.txtHorario.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un horario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_form.mesaExamenCurrent?.DetallesMesaExamen?.Count < 3)
            {
                MessageBox.Show("Debe definirse al menos tres docentes para la mesa de examen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public void OnCancelar()
        {
            _form.mesaExamenCurrent = null;
            _form.TransitionTo(new InitialDisplayState(_form));
        }

        public void UpdateUI()
        {
            _form.tabPageAgregarEditar.Enabled = true;
            _form.tabPageLista.Enabled = false;
            _form.tabControl.SelectTab(_form.tabPageAgregarEditar);

            var turnoExamen = (TurnoExamen)_form.cboTurnosExamenes.SelectedItem;
            _form.dateTime2doLlamado.Visible = turnoExamen.TieneLLamado2;
            _form.lbl2doLlamado.Visible = turnoExamen.TieneLLamado2;
            _form.cboMaterias.SelectedValue = _form.mesaExamenCurrent?.MateriaId ?? 0;
            _form.dateTime1erLlamado.Value = _form.mesaExamenCurrent?.Llamado1 ?? DateTime.Now;
            _form.dateTime2doLlamado.Value = _form.mesaExamenCurrent?.Llamado2 ?? DateTime.Now;
            _form.txtHorario.Text = _form.mesaExamenCurrent?.Horario ?? string.Empty;
            _form.dataGridDetallesMesa.DataSource = _form.mesaExamenCurrent?.DetallesMesaExamen?.OrderBy(d => d.TipoIntegrante).ToList() ?? null;
            _form.dataGridDetallesMesa.OcultarColumnas(new string[] { "DocenteId", "MesaExamen", "MesaExamenId", "Id", "Eliminado" });
        }
        public void OnAgregarDocenteADetalle()
        {
            var docente = (Docente)_form.cboDocentes.SelectedItem;
            if(!ControlDataDetalleInsert()) return;

            if (_form.detalleMesaExamenEdit != null)
            {
                _form.detalleMesaExamenEdit.DocenteId = docente.Id;
                _form.detalleMesaExamenEdit.Docente = docente;
                _form.detalleMesaExamenEdit.TipoIntegrante = (TipoIntegranteEnum)_form.cboTipoIntegrante.SelectedItem;
                var detalleToDelete = (DetalleMesaExamen)_form.dataGridDetallesMesa.CurrentRow.DataBoundItem;
                _form.mesaExamenCurrent.DetallesMesaExamen.Remove(detalleToDelete);
                _form.mesaExamenCurrent.DetallesMesaExamen.Add(_form.detalleMesaExamenEdit);
                _form.btnAgregarDocenteADetalle.Text = "Agregar";
                _form.detalleMesaExamenEdit = null;
            }
            else
            {
                _form.mesaExamenCurrent.DetallesMesaExamen.Add(new DetalleMesaExamen { DocenteId = docente.Id, Docente = docente, TipoIntegrante = (TipoIntegranteEnum)_form.cboTipoIntegrante.SelectedItem });
            }

            _form.dataGridDetallesMesa.DataSource = null;
            _form.dataGridDetallesMesa.DataSource = _form.mesaExamenCurrent.DetallesMesaExamen.OrderBy(d => d.TipoIntegrante).ToList();
            _form.dataGridDetallesMesa.OcultarColumnas(new string[] { "DocenteId", "MesaExamen", "MesaExamenId", "Id", "Eliminado" });
            _form.btnAgregarDocenteADetalle.Text = "Agregar";
            var nroIndice = _form.cboTipoIntegrante.SelectedIndex;
            nroIndice++;
            if (nroIndice == 4) { nroIndice = 0; }
                _form.cboTipoIntegrante.SelectedIndex = nroIndice;
            _form.cboDocentes.Focus();
        }

        private bool ControlDataDetalleInsert()
        {
            if (_form.mesaExamenCurrent.DetallesMesaExamen.Count > 0 
                && _form.mesaExamenCurrent.DetallesMesaExamen.Any(d => d.DocenteId.Equals((int)_form.cboDocentes.SelectedValue))
                && _form.btnAgregarDocenteADetalle.Text=="Agregar")
            {
                MessageBox.Show("El docente ya se encuentra asignado a la mesa de examen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_form.cboTipoIntegrante.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de integrante", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //if (_form.mesaExamenCurrent.DetallesMesaExamen.Any(d => d.TipoIntegrante.Equals((TipoIntegranteEnum)_form.cboTipoIntegrante.SelectedItem)) && _form.detalleMesaExamenEdit == null && (TipoIntegranteEnum)_form.cboTipoIntegrante.SelectedItem != TipoIntegranteEnum.Suplente)
            //{
            //    MessageBox.Show($"Ya existe un docente definido como {_form.cboTipoIntegrante.SelectedItem}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            return true;
        }
        public void OnEditarDocenteDeDetalle()
        {
            if (_form.dataGridDetallesMesa.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un docente para editar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _form.detalleMesaExamenEdit = (DetalleMesaExamen)_form.dataGridDetallesMesa.CurrentRow.DataBoundItem;
            _form.cboDocentes.SelectedValue = _form.detalleMesaExamenEdit.DocenteId;
            _form.cboTipoIntegrante.SelectedItem = _form.detalleMesaExamenEdit.TipoIntegrante;
            _form.btnAgregarDocenteADetalle.Text = "Actualizar";
        }

        public void OnQuitarDocenteDeDetalle()
        {
            if (_form.dataGridDetallesMesa.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un docente para quitar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var detalleMesaExamen = (DetalleMesaExamen)_form.dataGridDetallesMesa.CurrentRow.DataBoundItem;
            _form.mesaExamenCurrent.DetallesMesaExamen.Remove(_form.mesaExamenCurrent.DetallesMesaExamen.First(d => d.Id.Equals(detalleMesaExamen.Id)));
            _form.dataGridDetallesMesa.DataSource = null;
            _form.dataGridDetallesMesa.DataSource = _form.mesaExamenCurrent.DetallesMesaExamen;
        }

        // Estos métodos no aplican en este estado
        public Task LoadData() => Task.CompletedTask;
        public void LoadGrid(string filterText) {}
        public void OnAgregar() { }
        public void OnModificar() { }
        public void OnBuscar() { }
        public Task OnEliminar() => Task.CompletedTask;
        public void OnSalir() => _form.Close();
        public void LoadComboboxTurnosExamenes() {}
        public void LoadComboboxCarreras() {}
        public void LoadComboboxAniosCarreras() {}
        public void LoadComboboxMaterias() {}
        public void LoadComboboxDocentes() {}
        public void LoadComboboxTipoIntegrante() { }
    }
}
