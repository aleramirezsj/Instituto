using InstitutoDesktop.ExtensionMethods;
using InstitutoDesktop.Interfaces.MesasExamenes;
using InstitutoDesktop.Util;
using InstitutoDesktop.Views;
using InstitutoServices.Enums;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.MesasExamenes;

namespace InstitutoDesktop.States.MesasExamenes.MesasExamenes
{
    public class InitialDisplayState : IMesasExamenesViewState
    {
        private readonly MesasExamenesView _form;

        public InitialDisplayState(MesasExamenesView form)
        {
            _form = form;
            UpdateUI();
            _form.dataGridMesasExamenes.DataBindingComplete += (sender, e) => EnableDisableButtons();
            _form.cboTurnosExamenes.SelectedIndexChanged += (sender, e) => UpdateGridAnd2doLLamadoOptions();
            _form.cboCarreras.SelectedIndexChanged += (sender, e) => UpdateCboAnios();
            _form.cboAniosCarreras.SelectedIndexChanged += (sender, e) =>  UpdateCboMaterias();
        }

        private void UpdateGridAnd2doLLamadoOptions()
        {
            if (_form.cboTurnosExamenes.SelectedValue != null && _form.cboTurnosExamenes.SelectedValue.GetType() == typeof(int))
            {
                _form.dateTime2doLlamado.Visible = (_form.cboTurnosExamenes.SelectedItem as TurnoExamen).TieneLLamado2;
                _form.lbl2doLlamado.Visible = (_form.cboTurnosExamenes.SelectedItem as TurnoExamen).TieneLLamado2;
                _form.lblPrimerLlamado.Text = (_form.cboTurnosExamenes.SelectedItem as TurnoExamen).TieneLLamado2 ? "Primer llamado" : "Fecha mesa:";
                LoadGrid(_form.txtFiltro.Text);
            }
        }

        private void UpdateCboMaterias()
        {
            if (_form.cboAniosCarreras.SelectedValue != null && _form.cboAniosCarreras.SelectedValue.GetType() == typeof(int))
            {
                LoadComboboxMaterias();
                LoadGrid(_form.txtFiltro.Text);
            }
        }

        private void UpdateCboAnios()
        {
            if (_form.cboCarreras.SelectedValue != null && _form.cboCarreras.SelectedValue.GetType() == typeof(int))
                _form.cboAniosCarreras.DataSource = _form.listaAnioCarreras.
                                                    Where(a => a.Carrera.Id.Equals(_form.cboCarreras.SelectedValue)).ToList();
        }

        private void EnableDisableButtons()
        {
            _form.btnModificar.Enabled = _form.dataGridMesasExamenes.Rows.Count > 0;
            _form.btnEliminar.Enabled = _form.dataGridMesasExamenes.Rows.Count > 0;
        }

        public async Task LoadData()
        {
            ShowInActivity.Show("Descargando turnos de exámenes, carreras y años, materias, docentes, y mesas de exámenes");
            //pongo todos los métodos en paralelo para que se ejecuten al mismo tiempo
            var tareas = new List<Task>
            {
                Task.Run(async () => _form.listaTurnosExamenes = await _form._memoryCache.GetAllCacheAsync<TurnoExamen>()),
                Task.Run(async () => _form.listaCarreras = await _form._memoryCache.GetAllCacheAsync<Carrera>()),
                Task.Run(async () => _form.listaAnioCarreras = await _form._memoryCache.GetAllCacheAsync<AnioCarrera>()),
                Task.Run(async () => _form.listaMaterias = await _form._memoryCache.GetAllCacheAsync<Materia>()),
                Task.Run(async () => _form.listaDocentes = await _form._memoryCache.GetAllCacheAsync<Docente>()),
                Task.Run(async () => _form.listaMesasExamenes = await _form._memoryCache.GetAllCacheAsync<MesaExamen>())
            };
            _form.dataGridMesasExamenes.DataSource = _form.listaMesasExamenes;
            //cuando terminan todas las tareas, cierro el showInActivity y cargo los combos
            await Task.WhenAll(tareas);
            ShowInActivity.Hide();
            LoadComboboxCarreras();
            LoadComboboxAniosCarreras();
            LoadComboboxMaterias();
            LoadComboboxDocentes();
            LoadComboboxTipoIntegrante();
            LoadComboboxTurnosExamenes();
            LoadGrid(_form.txtFiltro.Text);
        }

        public void LoadGrid(string filterText)
        {
            _form.dataGridMesasExamenes.DataSource = null;
            if (_form.listaMesasExamenes != null && _form.listaMesasExamenes.Count > 0)
            {
                _form.dataGridMesasExamenes.DataSource = _form.listaMesasExamenes.
                    Where(h => h.TurnoExamenId.Equals((int)_form.cboTurnosExamenes.SelectedValue) &&
                          h.Materia.AnioCarrera.CarreraId.Equals((int)_form.cboCarreras.SelectedValue) &&
                          h.Materia.AnioCarreraId.Equals((int)_form.cboAniosCarreras.SelectedValue) &&
                          h.Materia.Nombre.Contains(filterText)).ToList();
                var columnaOcultar = (_form.cboTurnosExamenes.SelectedItem as TurnoExamen).TieneLLamado2 ? "" : "Llamado2";

                _form.dataGridMesasExamenes.OcultarColumnas(new string[] { "Id", "MateriaId", "TurnoExamen", "DetallesMesaExamen", "TurnoExamenId", "Eliminado", columnaOcultar });
            }
        }


        public void OnBuscar()
        {
            LoadGrid(_form.txtFiltro.Text);
        }

        public async void UpdateUI()
        {
            LoadGrid(_form.txtFiltro.Text);
            _form.tabPageAgregarEditar.Enabled = false;
            _form.tabPageLista.Enabled = true;
            _form.tabControl.SelectTab(_form.tabPageLista);
        }

        // Estos métodos no aplican en este estado
        public void OnAgregar() {
            _form.TransitionTo(new ActionsState(_form));
            _form._currentState.OnAgregar();
        }
        public void OnModificar() {
            _form.TransitionTo(new ActionsState(_form));
            _form._currentState.OnModificar();
        }
        public Task OnEliminar() {
            _form.TransitionTo(new ActionsState(_form));
            return _form._currentState.OnEliminar();
        }
        public Task OnGuardar() => Task.CompletedTask;
        public void OnCancelar() { }
        public void OnSalir() => _form.Close();


        public void LoadComboboxTurnosExamenes()
        {
            _form.cboTurnosExamenes.DataSource = _form.listaTurnosExamenes.ToList();
            _form.cboTurnosExamenes.DisplayMember = "Nombre";
            _form.cboTurnosExamenes.ValueMember = "Id";
            _form.cboTurnosExamenes.SelectedValue=_form.listaTurnosExamenes.FirstOrDefault(turno=>turno.Actual).Id;
        }

        public void LoadComboboxCarreras()
        {
            _form.cboCarreras.DataSource = _form.listaCarreras.ToList();
            _form.cboCarreras.DisplayMember = "Nombre";
            _form.cboCarreras.ValueMember = "Id";
        }

        public void LoadComboboxAniosCarreras()
        {
            _form.cboAniosCarreras.DataSource = _form.listaAnioCarreras.Where(a => a.Carrera.Id.Equals((int)_form.cboCarreras.SelectedValue)).ToList();
            _form.cboAniosCarreras.DisplayMember = "Nombre";
            _form.cboAniosCarreras.ValueMember = "Id";
        }

        public void LoadComboboxMaterias()
        {
            _form.cboMaterias.DataSource = _form.listaMaterias.Where(m => m.AnioCarreraId.Equals((int)_form.cboAniosCarreras.SelectedValue)).ToList();
            _form.cboMaterias.DisplayMember = "Nombre";
            _form.cboMaterias.ValueMember = "Id";

            AutoCompleteStringCollection autoCompletadoMaterias = new AutoCompleteStringCollection();
            foreach (Materia materia in _form.listaMaterias.Where(m => m.AnioCarreraId.Equals((int)_form.cboAniosCarreras.SelectedValue)).ToList())
            {
                autoCompletadoMaterias.Add(materia.Nombre.ToString());
            }
            _form.cboMaterias.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            _form.cboMaterias.AutoCompleteSource = AutoCompleteSource.CustomSource;
            _form.cboMaterias.AutoCompleteCustomSource = autoCompletadoMaterias;
        }

        public void LoadComboboxDocentes()
        {
            _form.cboDocentes.DataSource = _form.listaDocentes.ToList();
            _form.cboDocentes.DisplayMember = "Nombre";
            _form.cboDocentes.ValueMember = "Id";

            AutoCompleteStringCollection autoCompletadoDocentes = new AutoCompleteStringCollection();
            foreach (Docente docente in _form.listaDocentes.ToList())
            {
                autoCompletadoDocentes.Add(docente.Nombre.ToString());
            }
            _form.cboDocentes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            _form.cboDocentes.AutoCompleteSource = AutoCompleteSource.CustomSource;
            _form.cboDocentes.AutoCompleteCustomSource = autoCompletadoDocentes;
        }

        public void LoadComboboxTipoIntegrante()
        {
            _form.cboTipoIntegrante.DataSource = Enum.GetValues(typeof(TipoIntegranteEnum));
        }

        public void OnAgregarDocenteADetalle() {
            _form.TransitionTo(new EditionState(_form));
            _form._currentState.OnAgregarDocenteADetalle();
        }
        public void OnQuitarDocenteDeDetalle() {
            _form.TransitionTo(new EditionState(_form));
            _form._currentState.OnQuitarDocenteDeDetalle();
        }
        public void OnEditarDocenteDeDetalle() {
            _form.TransitionTo(new EditionState(_form));
            _form._currentState.OnEditarDocenteDeDetalle();
        }
    }
}
