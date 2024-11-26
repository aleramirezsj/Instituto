using InstitutoDesktop.ExtensionMethods;
using InstitutoDesktop.Interfaces.Horarios;
using InstitutoDesktop.Util;
using InstitutoDesktop.Views;
using InstitutoServices.Enums;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Horarios;
using InstitutoServices.Models.MesasExamenes;

namespace InstitutoDesktop.States.Horarios.Horarios
{
    public class InitialDisplayState : IHorariosViewState
    {
        private readonly HorariosView _form;

        public InitialDisplayState(HorariosView form)
        {
            _form = form;
            UpdateUI();
            _form.dataGridHorarios.DataBindingComplete += (sender, e) => EnableDisableButtons();
            _form.cboPeriodosHorarios.SelectedIndexChanged += (sender, e) => UpdateGrid();
            _form.cboCarreras.SelectedIndexChanged += (sender, e) => UpdateCboAnios();
            _form.cboAniosCarreras.SelectedIndexChanged += (sender, e) =>  UpdateCboMaterias();
        }

        private void UpdateGrid()
        {
            if (_form.cboPeriodosHorarios.SelectedValue != null && _form.cboPeriodosHorarios.SelectedValue.GetType() == typeof(int))
            {
                LoadGrid();
            }
        }

        private void UpdateCboMaterias()
        {
            if (_form.cboAniosCarreras.SelectedValue != null && _form.cboAniosCarreras.SelectedValue.GetType() == typeof(int))
            {
                LoadComboboxMaterias();
                LoadGrid();
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
            _form.btnModificar.Enabled = _form.dataGridHorarios.Rows.Count > 0;
            _form.btnEliminar.Enabled = _form.dataGridHorarios.Rows.Count > 0;
        }

        public async Task LoadData()
        {
            ShowInActivity.Show("Descargando ciclos lectivos, carreras y años, materias, docentes, horas y horarios");
            //pongo todos los métodos en paralelo para que se ejecuten al mismo tiempo
            var tareas = new List<Task>
            {
                Task.Run(async () => _form.listaPeriodosHorarios = await _form._memoryCache.GetAllCacheAsync<PeriodoHorario>()),                    
                Task.Run(async () => _form.listaCarreras = await _form._memoryCache.GetAllCacheAsync<Carrera>()),
                Task.Run(async () => _form.listaAnioCarreras = await _form._memoryCache.GetAllCacheAsync<AnioCarrera>()),
                Task.Run(async () => _form.listaMaterias = await _form._memoryCache.GetAllCacheAsync<Materia>()),
                Task.Run(async () => _form.listaDocentes = await _form._memoryCache.GetAllCacheAsync<Docente>()),
                Task.Run(async () => _form.listaHoras = await _form._memoryCache.GetAllCacheAsync<Hora>()),
                Task.Run(async () => _form.listaHorarios = await _form._memoryCache.GetAllCacheAsync<Horario>()),
                Task.Run(async () => _form.listaAulas = await _form._memoryCache.GetAllCacheAsync<Aula>())
            };
            _form.dataGridHorarios.DataSource = _form.listaHorarios;
            //cuando terminan todas las tareas, cierro el showInActivity y cargo los combos
            await Task.WhenAll(tareas);
            ShowInActivity.Hide();
            LoadComboboxPeriodosHorarios();
            LoadComboboxCarreras();
            LoadComboboxAniosCarreras();
            LoadComboboxMaterias();
            LoadComboboxDocentes();
            LoadComboboxAulas();
            LoadComboboxHoras();
            LoadComboboxDias();
            LoadGrid();
        }

        

        public void LoadGrid()
        {
            if (_form.listaHorarios != null && _form.listaHorarios.Count > 0 &&
                _form.cboPeriodosHorarios.SelectedValue!=null&&
                _form.cboCarreras.SelectedValue!=null&&
                _form.cboAniosCarreras.SelectedValue!=null)
                _form.dataGridHorarios.DataSource = _form.listaHorarios.
                    Where(h => h.PeriodoHorarioId.Equals((int)_form.cboPeriodosHorarios.SelectedValue) &&
                          h.Materia.AnioCarrera.CarreraId.Equals((int)_form.cboCarreras.SelectedValue) &&
                          h.Materia.AnioCarreraId.Equals((int)_form.cboAniosCarreras.SelectedValue)).
                          OrderBy(h=>h.Materia.Nombre).ToList();
            _form.dataGridHorarios.OcultarColumnas(new string[] { "Id", "MateriaId", "PeriodoHorario", "DetallesHorario", "IntegrantesHorario", "PeriodoHorarioId", "Eliminado" });
        }

        public void LoadGridFilter(string filterText)
        {
            if (_form.listaHorarios != null && _form.listaHorarios.Count > 0 && _form.cboPeriodosHorarios.SelectedValue != null && _form.cboCarreras.SelectedValue != null && _form.cboAniosCarreras.SelectedValue != null)
                _form.dataGridHorarios.DataSource = _form.listaHorarios.
                    Where(h => h.PeriodoHorarioId.Equals((int)_form.cboPeriodosHorarios.SelectedValue) &&
                          h.Materia.AnioCarrera.CarreraId.Equals((int)_form.cboCarreras.SelectedValue) &&
                          h.Materia.AnioCarreraId.Equals((int)_form.cboAniosCarreras.SelectedValue) &&
                          h.Materia.Nombre.ToUpper().Contains(_form.txtFiltro.Text.ToUpper()))
                          .OrderBy(h => h.Materia.Nombre).ToList();
            _form.dataGridHorarios.OcultarColumnas(new string[] { "Id", "MateriaId", "PeriodoHorario", "DetallesHorario", "IntegrantesHorario", "PeriodoHorarioId", "Eliminado" });
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


        public void LoadComboboxPeriodosHorarios()
        {
            _form.cboPeriodosHorarios.SetDataAndAutoComplete<PeriodoHorario>(_form.listaPeriodosHorarios.ToList());
            _form.cboPeriodosHorarios.SelectedValue=_form.listaPeriodosHorarios.FirstOrDefault(turno=>turno.Actual).Id;
        }

        public void LoadComboboxCarreras() => _form.cboCarreras.SetDataAndAutoComplete<Carrera>(_form.listaCarreras.ToList());

        public void LoadComboboxAniosCarreras()
        {
            _form.cboAniosCarreras.SetDataAndAutoComplete<AnioCarrera>(_form.listaAnioCarreras.Where(a => a.Carrera.Id.Equals((int)_form.cboCarreras.SelectedValue)).ToList());
        }

        public void LoadComboboxMaterias()=>
            _form.cboMaterias.SetDataAndAutoComplete<Materia>(_form.listaMaterias.Where(m => m.AnioCarreraId.Equals((int)_form.cboAniosCarreras.SelectedValue)).ToList());

        public void LoadComboboxDocentes() =>_form.cboDocentes.SetDataAndAutoComplete<Docente>(_form.listaDocentes.ToList());

        public void LoadComboboxDias() =>_form.cboDias.DataSource = Enum.GetValues(typeof(DiaEnum));
        
        public void LoadComboboxAulas()=>_form.cboAulas.SetDataAndAutoComplete<Aula>(_form.listaAulas.ToList());

        public void LoadComboboxHoras()=> _form.cboHoras.SetDataAndAutoCompleteWithToString<Hora>(_form.listaHoras.ToList());

        public void OnAgregarDocenteAIntegrantes() {
            _form.TransitionTo(new EditionState(_form));
            _form._currentState.OnAgregarDocenteAIntegrantes();
        }
        public void OnQuitarDocenteDeIntegrantes() {
            _form.TransitionTo(new EditionState(_form));
            _form._currentState.OnQuitarDocenteDeIntegrantes();
        }
        public void OnEditarHoraDeDetalle() {
            _form.TransitionTo(new EditionState(_form));
            _form._currentState.OnEditarHoraDeDetalle();
        }
        public void OnAgregarHoraADetalle()
        {
            _form.TransitionTo(new EditionState(_form));
            _form._currentState.OnAgregarHoraADetalle();
        }
        public void OnQuitarHoraDeDetalle()
        {
            _form.TransitionTo(new EditionState(_form));
            _form._currentState.OnQuitarHoraDeDetalle();
        }
    }
}
