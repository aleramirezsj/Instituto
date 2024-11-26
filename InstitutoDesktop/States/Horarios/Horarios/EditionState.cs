using InstitutoDesktop.ExtensionMethods;
using InstitutoDesktop.Interfaces.Horarios;
using InstitutoDesktop.Views;
using InstitutoServices.Enums;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Horarios;

namespace InstitutoDesktop.States.Horarios.Horarios
{
    public class EditionState : IHorariosViewState
    {
        private readonly HorariosView _form;

        public EditionState(HorariosView form)
        {
            _form = form;
            _form.dataGridIntegrantes.DataBindingComplete+= (s, e) => EnableDisabledEditarQuitarDocente();
            _form.dataGridHoras.DataBindingComplete += (s, e) => EnableDisabledEditarQuitarHora();
            _form.cboMaterias.SelectedIndexChanged += (s, e) => SeleccionarDocenteDeMateriaSeleccionada();
            UpdateUI();

        }

        private void EnableDisabledEditarQuitarHora()
        {
            _form.btnQuitarHora.Enabled = _form.dataGridHoras.Rows.Count > 0;
            _form.btnEditarHora.Enabled = _form.dataGridHoras.Rows.Count > 0;
        }

        private async void SeleccionarDocenteDeMateriaSeleccionada()
        {
            if (_form.cboMaterias.SelectedValue == null) return;

            var horario = (await _form._memoryCache.GetAllCacheAsync<Horario>())
                .FirstOrDefault(h => h.MateriaId.Equals((int)_form.cboMaterias.SelectedValue));
            if (horario != null)
                _form.cboDocentes.SelectedValue = horario.IntegrantesHorario.FirstOrDefault().DocenteId;

        }

        private void EnableDisabledEditarQuitarDocente()
        {
            _form.btnEditarHora.Enabled = _form.dataGridHoras.Rows.Count > 0;
            _form.btnQuitarHora.Enabled = _form.dataGridHoras.Rows.Count > 0;
        }

        public async Task OnGuardar()
        {
            if(!ControlDataInsert()) return;

            _form.horarioCurrent.MateriaId = (int)_form.cboMaterias.SelectedValue;
            _form.horarioCurrent.Materia = (Materia)_form.cboMaterias.SelectedItem;
            _form.horarioCurrent.PeriodoHorarioId = (int)_form.cboPeriodosHorarios.SelectedValue;
            _form.horarioCurrent.PeriodoHorario = (PeriodoHorario)_form.cboPeriodosHorarios.SelectedItem;

            _form.horarioCurrent.CantidadHoras = _form.horarioCurrent.DetallesHorario.Count();

            if (_form.horarioCurrent.Id == 0)
                await _form._memoryCache.AddCacheAsync<Horario>(_form.horarioCurrent);
            else
                await _form._memoryCache.UpdateCacheAsync<Horario>(_form.horarioCurrent);
            
            //_form._memoryCache.ClearCache<Horario>();
            //await _form._currentState.LoadData();
            _form.TransitionTo(new InitialDisplayState(_form));
            
        }

        private bool ControlDataInsert()
        {
            if (_form.cboMaterias.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una materia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_form.horarioCurrent?.IntegrantesHorario?.Count == 0 && !_form.horarioCurrent.Materia.EsRecreo)
            {
                MessageBox.Show("Debe definirse al menos un docente para el horario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_form.horarioCurrent?.DetallesHorario?.Count == 0)
            {
                MessageBox.Show("Debe definirse al menos una hora para el horario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public void OnCancelar()
        {
            _form.horarioCurrent = null;
            _form.TransitionTo(new InitialDisplayState(_form));
        }

        public void UpdateUI()
        {
            _form.tabPageAgregarEditar.Enabled = true;
            _form.tabPageLista.Enabled = false;
            _form.tabControl.SelectTab(_form.tabPageAgregarEditar);

            _form.cboMaterias.SelectedValue = _form.horarioCurrent?.MateriaId ?? 0;
            _form.dataGridIntegrantes.DataSource = _form.horarioCurrent?.IntegrantesHorario ?? null;
            _form.dataGridIntegrantes.OcultarColumnas(new string[] { "Horario", "HorarioId", "Id", "Eliminado" });
            _form.dataGridHoras.DataSource = _form.horarioCurrent?.DetallesHorario.OrderBy(d => d.Dia).ThenBy(d => d.Hora.Desde).ToList() ?? null;
            _form.cboAulas.SelectedValue = _form.horarioCurrent?.DetallesHorario.FirstOrDefault()?.AulaId ?? 0;
            _form.dataGridHoras.OcultarColumnas(new string[] { "AulaId", "Horario", "HoraId", "HorarioId", "Id", "Eliminado" });
        }
        public void OnAgregarDocenteAIntegrantes()
        {
            var docente = (Docente)_form.cboDocentes.SelectedItem;
            if (_form.horarioCurrent.IntegrantesHorario.Any(d => d.DocenteId.Equals(docente.Id)))
            {
                MessageBox.Show("El docente ya se encuentra asignado al horario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _form.horarioCurrent.IntegrantesHorario.Add(new IntegranteHorario { DocenteId = docente.Id, Docente = docente });
            _form.dataGridIntegrantes.DataSource = null;
            _form.dataGridIntegrantes.DataSource = _form.horarioCurrent.IntegrantesHorario.ToList();
            _form.dataGridIntegrantes.OcultarColumnas(new string[] { "Horario", "DocenteId", "HorarioId", "Id", "Eliminado" });
        }

        public void OnAgregarHoraADetalle()
        {
            if (!ControlDataDetalleInsert()) return;

            var hora = (Hora)_form.cboHoras.SelectedItem;
            var aula = (Aula)_form.cboAulas.SelectedItem;
            if (_form.detalleHorarioEdit != null)
            {
                _form.detalleHorarioEdit.HoraId = hora.Id;
                _form.detalleHorarioEdit.Hora = hora;
                _form.detalleHorarioEdit.Dia = (DiaEnum)_form.cboDias.SelectedValue;
                _form.detalleHorarioEdit.AulaId = aula.Id;
                _form.detalleHorarioEdit.Aula = aula;
                _form.detalleHorarioEdit.HorarioId = _form.horarioCurrent.Id;
                _form.detalleHorarioEdit.Horario = _form.horarioCurrent;
                _form.btnAgregarHora.Text = "Agregar";
                var detalleABorrar = (DetalleHorario)_form.dataGridHoras.CurrentRow.DataBoundItem;
                _form.horarioCurrent.DetallesHorario.Remove(detalleABorrar);
                _form.horarioCurrent.DetallesHorario.Add(_form.detalleHorarioEdit);
                _form.detalleHorarioEdit = null;
            }
            else
            {
                _form.horarioCurrent.DetallesHorario.Add(new DetalleHorario { HoraId = hora.Id, Hora = hora, Dia = (DiaEnum)_form.cboDias.SelectedValue, HorarioId = _form.horarioCurrent.Id, AulaId = aula.Id, Aula = aula });
            }
            _form.dataGridHoras.DataSource = null;
            _form.dataGridHoras.DataSource = _form.horarioCurrent.DetallesHorario.OrderBy(d => d.Dia).ThenBy(d => d.Hora.Desde).ToList();
            _form.dataGridHoras.OcultarColumnas(new string[] { "AulaId", "Horario", "HoraId", "HorarioId", "Id", "Eliminado" });
            SeleccionarLaHoraProxima(hora);

        }

        private void SeleccionarLaHoraProxima(Hora hora)
        {
            var proximaHora = _form.listaHoras.FirstOrDefault(h => (h.Desde.AddMinutes(40).Equals(h.Hasta) && (h.Desde.Equals(hora.Hasta) || h.Desde.Equals(hora.Hasta.AddMinutes(10)) || h.Desde.Equals(hora.Hasta.AddMinutes(15)))));
            if (proximaHora != null)
                _form.cboHoras.SelectedValue = proximaHora.Id;
        }

        private bool ControlDataDetalleInsert()
        {
            var hora = (Hora)_form.cboHoras.SelectedItem;
            if (_form.horarioCurrent.DetallesHorario.Any(d => d.HoraId.Equals(hora.Id) && d.Dia.Equals(_form.cboDias.SelectedValue)) && _form.detalleHorarioEdit == null)
            {
                MessageBox.Show($"La hora {hora.Nombre} en el día {_form.cboDias.SelectedValue} ya se encuentra asignada al horario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_form.cboDias.SelectedItem == null || _form.cboHoras.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un día y una hora", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }


        public void OnQuitarDocenteDeIntegrantes()
        {
            if (_form.dataGridIntegrantes.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un docente para quitar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var integranteHorario = (IntegranteHorario)_form.dataGridIntegrantes.CurrentRow.DataBoundItem;
            _form.horarioCurrent.IntegrantesHorario.Remove(_form.horarioCurrent.IntegrantesHorario.First(d => d.Id.Equals(integranteHorario.Id)));
            _form.dataGridIntegrantes.DataSource = null;
            _form.dataGridIntegrantes.DataSource = _form.horarioCurrent.IntegrantesHorario;
            _form.dataGridIntegrantes.OcultarColumnas(new string[] { "Horario","DocenteId", "HorarioId", "Id", "Eliminado" });
        }

        // Estos métodos no aplican en este estado
        public Task LoadData() => Task.CompletedTask;
        public void LoadGrid() { }
        public void LoadGridFilter(string filterText) {}
        public void OnAgregar() { }
        public void OnModificar() { }
        public void OnBuscar() { }
        public Task OnEliminar() => Task.CompletedTask;
        public void OnSalir() => _form.Close();
        public void LoadComboboxPeriodosHorarios() {}
        public void LoadComboboxCarreras() {}
        public void LoadComboboxAniosCarreras() {}
        public void LoadComboboxMaterias() {}
        public void LoadComboboxDocentes() {}
        public void LoadComboboxAulas() { }
        public void LoadComboboxDias() { }
        public void LoadComboboxHoras() { }

        public void OnEditarHoraDeDetalle()
        {
            if (_form.dataGridHoras.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una hora para editar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _form.detalleHorarioEdit = (DetalleHorario)_form.dataGridHoras.CurrentRow.DataBoundItem;
            _form.cboHoras.SelectedValue = _form.detalleHorarioEdit.HoraId;
            _form.cboDias.SelectedItem = _form.detalleHorarioEdit.Dia;
            _form.cboAulas.SelectedValue = _form.detalleHorarioEdit.AulaId ?? 0;
            _form.btnAgregarHora.Text = "Actualizar";
        }

        public void OnQuitarHoraDeDetalle()
        {
            if (_form.dataGridHoras.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una hora para quitar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var detalleHorario = (DetalleHorario)_form.dataGridHoras.CurrentRow.DataBoundItem;
            _form.horarioCurrent.DetallesHorario.Remove(_form.horarioCurrent.DetallesHorario.First(h => h.Id.Equals(detalleHorario.Id)));
            _form.dataGridHoras.DataSource = null;
            _form.dataGridHoras.DataSource = _form.horarioCurrent.DetallesHorario;
            _form.dataGridHoras.OcultarColumnas(new string[] {"AulaId", "Horario", "HoraId", "HorarioId", "Id", "Eliminado" });
        }
    }
}
