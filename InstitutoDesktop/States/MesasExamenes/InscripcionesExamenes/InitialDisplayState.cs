using InstitutoDesktop.ExtensionMethods;
using InstitutoDesktop.Interfaces.MesasExamenes;
using InstitutoDesktop.Util;
using InstitutoDesktop.Views;
using InstitutoServices.Enums;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.MesasExamenes;

namespace InstitutoDesktop.States.MesasExamenes.InscripcionesExamenes
{
    public class InitialDisplayState : IInscripcionesExamenesViewState
    {
        private readonly InscripcionesExamenesView _form;

        public InitialDisplayState(InscripcionesExamenesView form)
        {
            _form = form;
            UpdateUI();
            _form.dataGridInscripciones.DataBindingComplete += (sender, e) => EnableDisableButtons();
            _form.chkFiltrarPorCarrera.CheckedChanged += (sender, e) =>
            {
                _form.cboCarreras.Enabled = _form.chkFiltrarPorCarrera.Checked;
                LoadGrid();
            };
            _form.cboTurnosExamenes.SelectedIndexChanged += (sender, e) => UpdateGridInscripciones();
            _form.cboCarreras.SelectedIndexChanged += (sender, e) => UpdateCboAnios();
            _form.cboAniosCarreras.SelectedIndexChanged += (sender, e) =>  UpdateVerPorMaterias();
        }

        private void UpdateGridInscripciones()
        {
            if (_form.cboTurnosExamenes.SelectedValue != null && _form.cboTurnosExamenes.SelectedValue.GetType() == typeof(int))
            {
                LoadGrid();
            }
        }

        private void UpdateVerPorMaterias()
        {
            if (_form.cboAniosCarreras.SelectedValue != null && _form.cboAniosCarreras.SelectedValue.GetType() == typeof(int))
            {
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
            _form.btnImprimirTodas.Enabled = _form.dataGridInscripciones.Rows.Count > 0;
            _form.btnImprimirSeleccionada.Enabled = _form.dataGridInscripcionSeleccioanda.Rows.Count > 0;
        }

        public async Task LoadData()
        {
            ShowInActivity.Show("Descargando turnos de exámenes, carreras y años, materias e inscripciones a mesas de exámenes");
            //pongo todos los métodos en paralelo para que se ejecuten al mismo tiempo
            var tareas = new List<Task>
            {
                Task.Run(async () => _form.listaTurnosExamenes = await _form._memoryCache.GetAllCacheAsync<TurnoExamen>()),
                Task.Run(async () => _form.listaCarreras = await _form._memoryCache.GetAllCacheAsync<Carrera>()),
                Task.Run(async () => _form.listaAnioCarreras = await _form._memoryCache.GetAllCacheAsync<AnioCarrera>()),
                Task.Run(async () => _form.listaMaterias = await _form._memoryCache.GetAllCacheAsync<Materia>()),
                Task.Run(async () => _form.listaInscripcionesExamenes = await _form._memoryCache.GetAllCacheAsync<InscripcionExamen>())
            };
            _form.dataGridInscripciones.DataSource = _form.listaInscripcionesExamenes;
            //cuando terminan todas las tareas, cierro el showInActivity y cargo los combos
            await Task.WhenAll(tareas);
            ShowInActivity.Hide();
            LoadComboboxTurnosExamenes();
            LoadComboboxCarreras();
            LoadComboboxAniosCarreras();
            LoadGrid();
        }

        public void LoadGrid()
        {
            _form.dataGridInscripciones.DataSource = null;
            //este método tiene que cargar las inscripciones a mesas de exámenes según el turno de exámenes seleccionado y si el checkbox de ver por carrera está seleccionado tiene que filtar por el turno de exámenes y la carrera seleccionada y si está seleccionado el checkbox de ver por año carrera tiene que filtrar por el turno de exámenes, la carrera y el año seleccionado
            if (!_form.chkFiltrarPorCarrera.Checked && !_form.chkFiltrarPorAñoCarrera.Checked)
            {
                if (_form.listaInscripcionesExamenes != null && _form.listaInscripcionesExamenes.Count > 0
                    && _form.cboTurnosExamenes.SelectedValue != null)
                {
                    _form.dataGridInscripciones.DataSource = _form.listaInscripcionesExamenes.
                        Where(h => h.TurnoExamenId.Equals((int)_form.cboTurnosExamenes.SelectedValue)).ToList();
                    //                    var columnaOcultar = (_form.cboTurnosExamenes.SelectedItem as TurnoExamen).TieneLLamado2 ? "" : "Llamado2";
                }
            }
            //si está seleccionado el checkbox de ver por carrera
            else if (_form.chkFiltrarPorCarrera.Checked && !_form.chkFiltrarPorAñoCarrera.Checked)
            {
                if (_form.listaInscripcionesExamenes != null && _form.listaInscripcionesExamenes.Count > 0
                    && _form.cboTurnosExamenes.SelectedValue != null && _form.cboCarreras.SelectedValue != null)
                {
                    _form.dataGridInscripciones.DataSource = _form.listaInscripcionesExamenes.
                        Where(h => h.TurnoExamenId.Equals((int)_form.cboTurnosExamenes.SelectedValue) &&
                              h.CarreraId.Equals((int)_form.cboCarreras.SelectedValue)).ToList();
                }
            }
            _form.dataGridInscripciones.OcultarColumnas(new string[] { "Id", "CarreraId", "AlumnoId", "TurnoExamen", "DetallesInscripcionesExamenes", "TurnoExamenId", "Eliminado" });
            _form.statusBarMessage.Text = $"Total de inscripciones a mesas de exámenes obtenidas: {_form.dataGridInscripciones.Rows.Count}";
        }

        public void LoadGridFilter(string filterText)
        {
            _form.dataGridInscripciones.DataSource = null;
            //if (_form.listaInscripcionExamen != null && _form.listaMesasExamenes.Count > 0)
            //    _form.dataGridMesasExamenes.DataSource = _form.listaMesasExamenes.
            //        Where(h => h.TurnoExamenId.Equals((int)_form.cboTurnosExamenes.SelectedValue) &&
            //              h.Materia.AnioCarrera.CarreraId.Equals((int)_form.cboCarreras.SelectedValue) &&
            //              h.Materia.AnioCarreraId.Equals((int)_form.cboAniosCarreras.SelectedValue) &&
            //              h.Materia.Nombre.Contains(filterText)).ToList();
            //var columnaOcultar = (_form.cboTurnosExamenes.SelectedItem as TurnoExamen).TieneLLamado2 ? "" : "Llamado2";

            //_form.dataGridMesasExamenes.OcultarColumnas(new string[] { "Id", "MateriaId", "TurnoExamen", "DetallesMesaExamen", "TurnoExamenId", "Eliminado", columnaOcultar });
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
            throw new NotImplementedException();
        }
    }
}
