using InstitutoDesktop.ExtensionMethods;
using InstitutoDesktop.Interfaces.Inscripciones;
using InstitutoDesktop.Interfaces.MesasExamenes;
using InstitutoDesktop.Util;
using InstitutoDesktop.Views;
using InstitutoServices.Enums;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Inscripciones;
using InstitutoServices.Models.MesasExamenes;

namespace InstitutoDesktop.States.Inscripciones.InscripcionesMaterias
{
    public class InitialDisplayState : IInscripcionesMateriasViewState
    {
        private readonly InscripcionesMateriasView _form;

        public InitialDisplayState(InscripcionesMateriasView form)
        {
            _form = form;
            UpdateUI();
            _form.dataGridInscripciones.DataBindingComplete += (sender, e) => {
                EnableDisableButtons();
            };


            _form.chkFiltrarPorCarrera.CheckedChanged += (sender, e) =>
            {
                _form.cboCarreras.Enabled = _form.chkFiltrarPorCarrera.Checked;
                LoadGrid(_form.txtFiltro.Text);
            };
            _form.chkFiltrarPorAñoCarrera.CheckedChanged += (sender, e) =>
            {
                _form.cboAniosCarreras.Enabled = _form.chkFiltrarPorAñoCarrera.Checked;
                LoadGrid(_form.txtFiltro.Text);
            };
            _form.cboPeriodosInscripciones.SelectedIndexChanged += (sender, e) => UpdateGridInscripciones();
            _form.cboCarreras.SelectedIndexChanged += (sender, e) => UpdateCboAnios();
            _form.cboAniosCarreras.SelectedIndexChanged += (sender, e) =>  UpdateVerPorMaterias();
            _form.dataGridInscripciones.SelectionChanged += (sender, e) => LoadGridInscripcionSeleccionada();
            _form.dataGridMaterias.SelectionChanged += (sender, e) => LoadGridMateriaSeleccionada();

            _form.tabPageVerPorMaterias.Enter += (sender, e) =>
            {
                _form.chkFiltrarPorCarrera.Checked = true;
                _form.chkFiltrarPorAñoCarrera.Enabled = true;
                _form.chkFiltrarPorAñoCarrera.Checked = true;

            };
            _form.tabPageVerPorAlumnos.Enter += (sender, e) =>
            {
                _form.chkFiltrarPorAñoCarrera.Enabled = false;
                _form.chkFiltrarPorAñoCarrera.Checked = false;
            };
        }

        private void LoadGridMateriaSeleccionada()
        {
            //compruebo que haya una fila seleccionada y que el valor de la fila seleccionada no sea null
            if (_form.dataGridMaterias.SelectedRows.Count > 0 && _form.dataGridMaterias.SelectedRows[0].DataBoundItem != null)
            {
                //obtengo el objeto de la fila seleccionada
                var idMateria = (int)_form.dataGridMaterias.CurrentRow.Cells[0].Value;
                //cargo el grid de inscripciones seleccionadas
                _form.dataGridAlumnos.DataSource = _form.listaDetallesInscripciones
                    .Where(d => d.MateriaId.Equals(idMateria) && d.Inscripcion.PeriodoInscripcionId.Equals((int)_form.cboPeriodosInscripciones.SelectedValue) && d.Inscripcion.CarreraId.Equals((int)_form.cboCarreras.SelectedValue))
                    .Select(Alumno => new { Alumno = Alumno.Inscripcion.Alumno.ApellidoNombre, Modalidad_cursado = Alumno.ModalidadCursado.ToString() })
                    .OrderBy(x=>x.Alumno).ToList();
                //oculto las columnas que no quiero mostrar
                _form.dataGridAlumnos.OcultarColumnas(new string[] { "Id", "InscripcionExamenId", "Materia","MateriaId","Eliminado" });
                //actualizo el status bar
                //_form.statusBarMessage.Text = $"Total de inscripciones a mesas de exámenes obtenidas: {_form.dataGridInscripciones.Rows.Count} - Total de inscripciones seleccionadas: {_form.dataGridInscripcionSeleccioanda.Rows.Count}";
            }
        }

        private void LoadGridInscripcionSeleccionada()
        {
            if (_form.dataGridInscripcionSeleccioanda == null) return; // Verificación adicional

            //compruebo que haya una fila seleccionada y que el valor de la fila seleccionada sea un objeto de tipo InscripcionExamen
            if (_form.dataGridInscripciones.SelectedRows.Count > 0 && _form.dataGridInscripciones.SelectedRows[0].DataBoundItem.GetType() == typeof(Inscripcion))
            {
                //obtengo el objeto de la fila seleccionada
                var inscripcion = (Inscripcion)_form.dataGridInscripciones.SelectedRows[0].DataBoundItem;
                //cargo el grid de inscripciones seleccionadas
                _form.dataGridInscripcionSeleccioanda.DataSource = _form.listaDetallesInscripciones
                    .Where(d=>d.InscripcionId.Equals(inscripcion.Id))
                        .Select(x=> new {Año=x?.Materia?.AnioCarrera?.Nombre, Materia=x?.Materia?.Nombre, Modalidad_cursado=x.ModalidadCursado.ToString()}).ToList();
                //establezco el ancho de las columnas si la grilla existe
                if (_form.dataGridInscripcionSeleccioanda?.ColumnCount > 0)
                {
                    _form.dataGridInscripcionSeleccioanda.EstablecerAnchoDeColumnas(new int[] { 100 });
                }

            }
        }

        private void UpdateGridInscripciones()
        {
            if (_form.cboPeriodosInscripciones.SelectedValue != null && _form.cboPeriodosInscripciones.SelectedValue.GetType() == typeof(int))
            {
                LoadGrid(_form.txtFiltro.Text);
            }
        }

        private void UpdateVerPorMaterias()
        {
            if (_form.cboAniosCarreras.SelectedValue != null && _form.cboAniosCarreras.SelectedValue.GetType() == typeof(int))
            {
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
            _form.btnImprimirTodas.Enabled = _form.dataGridInscripciones?.Rows?.Count > 0;
            _form.btnImprimirSeleccionada.Enabled = _form.dataGridInscripcionSeleccioanda?.Rows?.Count > 0;
        }

        public async Task LoadData()
        {
            ShowInActivity.Show("Descargando turnos de exámenes, carreras y años, materias e inscripciones a mesas de exámenes");
            //pongo todos los métodos en paralelo para que se ejecuten al mismo tiempo
            var tareas = new List<Task>
            {
                Task.Run(async () => _form.listaPeriodosInscripciones = await _form._memoryCache.GetAllCacheAsync<PeriodoInscripcion>()),
                Task.Run(async () => _form.listaCarreras = await _form._memoryCache.GetAllCacheAsync<Carrera>()),
                Task.Run(async () => _form.listaAnioCarreras = await _form._memoryCache.GetAllCacheAsync<AnioCarrera>()),
                Task.Run(async () => _form.listaMaterias = await _form._memoryCache.GetAllCacheAsync<Materia>()),
                Task.Run(async () => _form.listaInscripciones = await _form._memoryCache.GetAllCacheAsync<Inscripcion>()),
                Task.Run(async () => _form.listaDetallesInscripciones = await _form._memoryCache.GetAllCacheAsync<DetalleInscripcion>()),

            };
            _form.dataGridInscripciones.DataSource = _form.listaInscripciones;
            //cuando terminan todas las tareas, cierro el showInActivity y cargo los combos
            await Task.WhenAll(tareas);
            ShowInActivity.Hide();
            LoadComboboxPeriodosInscripciones();
            LoadComboboxCarreras();
            LoadComboboxAniosCarreras();
            LoadGrid(_form.txtFiltro.Text);
        }

        public void LoadGrid(string filterText="")
        {
            //_form.dataGridInscripciones.DataSource = null;
            //este método tiene que cargar las inscripciones a mesas de exámenes según el turno de exámenes seleccionado y si el checkbox de ver por carrera está seleccionado tiene que filtrar por el turno de exámenes y la carrera seleccionada y si está seleccionado el checkbox de ver por año carrera tiene que filtrar por el turno de exámenes, la carrera y el año seleccionado
            if (!_form.chkFiltrarPorCarrera.Checked && !_form.chkFiltrarPorAñoCarrera.Checked)
            {
                if (_form.listaInscripciones != null && _form.listaInscripciones.Count > 0
                    && _form.cboPeriodosInscripciones.SelectedValue != null)
                {
                    _form.listaInscripcionesFiltrada = _form.listaInscripciones.
                        Where(i => i.PeriodoInscripcionId.Equals((int)_form.cboPeriodosInscripciones.SelectedValue) &&
                              i.Alumno.ApellidoNombre.ToUpper().Contains(filterText.ToUpper()))
                        .OrderBy(i=>i.Carrera.Nombre).ThenBy(i => i.Alumno.ApellidoNombre).ToList();
                    //                    var columnaOcultar = (_form.cboTurnosExamenes.SelectedItem as TurnoExamen).TieneLLamado2 ? "" : "Llamado2";
                    _form.dataGridInscripciones.DataSource = _form.listaInscripcionesFiltrada;
                    //_form.dataGridInscripciones.EstablecerAnchoDeColumnas(new int[] { 100 });

                }
            }
            //si está seleccionado el checkbox de ver por carrera
            else if (_form.chkFiltrarPorCarrera.Checked && !_form.chkFiltrarPorAñoCarrera.Checked)
            {
                if (_form.listaInscripciones != null && _form.listaInscripciones.Count > 0
                    && _form.cboPeriodosInscripciones.SelectedValue != null && _form.cboCarreras.SelectedValue != null)
                {
                    _form.listaInscripcionesFiltrada = _form.listaInscripciones.
                        Where(i => i.PeriodoInscripcionId.Equals((int)_form.cboPeriodosInscripciones.SelectedValue) &&
                              i.CarreraId.Equals((int)_form.cboCarreras.SelectedValue) &&
                              i.Alumno.ApellidoNombre.ToUpper().Contains(filterText.ToUpper()))
                        .OrderBy(h => h.Alumno.ApellidoNombre).ToList();

                    _form.dataGridInscripciones.DataSource = _form.listaInscripcionesFiltrada;
                    //_form.dataGridInscripciones.EstablecerAnchoDeColumnas(new int[] { 100 });


                }
            }
            //si está seleccionado el checkbox de ver por año carrera
            else if (_form.chkFiltrarPorCarrera.Checked && _form.chkFiltrarPorAñoCarrera.Checked)
            {
                if (_form.listaInscripciones != null && _form.listaInscripciones.Count > 0
                    && _form.cboPeriodosInscripciones.SelectedValue != null && _form.cboCarreras.SelectedValue != null && _form.cboAniosCarreras.SelectedValue != null)
                {
                    var listaMateriasAgrupadas= _form.listaDetallesInscripciones.
                        Where(d => d.Inscripcion.PeriodoInscripcionId.Equals((int)_form.cboPeriodosInscripciones.SelectedValue) &&
                              d.Inscripcion.CarreraId.Equals((int)_form.cboCarreras.SelectedValue) &&
                              d.Materia.AnioCarreraId.Equals((int)_form.cboAniosCarreras.SelectedValue))
                        .GroupBy(x=>x.MateriaId)
                        .OrderBy(x => x.FirstOrDefault().Materia.Nombre)
                        .ToList();
                    //listo las materias agrupadas en la grilla mostrando el nombre y la cantidad de inscripciones
                    _form.dataGridMaterias.DataSource = listaMateriasAgrupadas.Select(x => new { Id=x.FirstOrDefault().MateriaId,Materia = x.FirstOrDefault().Materia.Nombre, Inscriptos = x.Count() })
                        .OrderBy(x => x.Materia).ToList();
                }
            }
            _form.dataGridInscripciones.OcultarColumnas(new string[] { "Id", "CarreraId", "AlumnoId", "PeriodoInscripcionId", "DetallesInscripcionesExamenes", "PeriodoInscripcion", "Eliminado","Inscripto" });
            _form.statusBarMessage.Text = $"Total de inscripciones a mesas de exámenes obtenidas: {_form.dataGridInscripciones.Rows.Count}";
        }

        


        public void OnBuscar()
        {
            LoadGrid(_form.txtFiltro.Text);
        }

        public async void UpdateUI()
        {
            LoadGrid();
            _form.tabPageVerPorMaterias.Enabled = true;
            _form.tabPageVerPorAlumnos.Enabled = true;
            _form.tabControl.SelectTab(_form.tabPageVerPorAlumnos);
        }


        public void OnSalir() => _form.Close();


        public void LoadComboboxPeriodosInscripciones()
        {
            _form.cboPeriodosInscripciones.DataSource = _form.listaPeriodosInscripciones.ToList();
            _form.cboPeriodosInscripciones.DisplayMember = "Nombre";
            _form.cboPeriodosInscripciones.ValueMember = "Id";
            _form.cboPeriodosInscripciones.SelectedValue=_form.listaPeriodosInscripciones.LastOrDefault(p=>p.CicloLectivo.Actual).Id;
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

        public void OnImprimirTodasPorAlumno()
        {
            _form.TransitionTo(new ActionsState(_form));
            _form._currentState.OnImprimirTodasPorAlumno();
        }

        public void OnImprimirTodasPorMateria()
        {
            _form.TransitionTo(new ActionsState(_form));
            _form._currentState.OnImprimirTodasPorMateria();
        }

        public void OnImprimirSeleccionadaPorAlumno()
        {
            _form.TransitionTo(new ActionsState(_form));
            _form._currentState.OnImprimirSeleccionadaPorAlumno();
        }

        public void OnImprimirSeleccionadaPorMateria()
        {
            _form.TransitionTo(new ActionsState(_form));
            _form._currentState.OnImprimirSeleccionadaPorMateria();
        }


    }
}
