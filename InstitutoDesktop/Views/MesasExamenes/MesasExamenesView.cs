using InstitutoDesktop.ExtensionMethods;
using InstitutoDesktop.Services;
using InstitutoDesktop.Util;
using InstitutoServices.Enums;
using InstitutoServices.Interfaces;
using InstitutoServices.Interfaces.Commons;
using InstitutoServices.Interfaces.Horarios;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Horarios;
using InstitutoServices.Models.Inscripciones;
using InstitutoServices.Models.MesasExamenes;
using InstitutoServices.Services.Commons;
using InstitutoServices.Services.Horarios;
using System.Data;
using System.Diagnostics;

namespace InstitutoDesktop.Views
{
    public partial class MesasExamenesView : Form
    {
        BindingSource bindingMesasExamenes = new BindingSource();
        List<TurnoExamen>? listaTurnosExamenes = new List<TurnoExamen>();
        List<Carrera>? listaCarreras = new List<Carrera>();
        List<AnioCarrera>? listaAnioCarreras = new List<AnioCarrera>();
        List<Materia>? listaMaterias = new List<Materia>();
        List<Docente>? listaDocentes = new List<Docente>();
        List<MesaExamen>? listaMesasExamenes = new List<MesaExamen>();
        MesaExamen mesaExamenCurrent;
        DetalleMesaExamen detalleMesaExamenEdit;

        private readonly MemoryCacheServiceWinForms _memoryCache;

        public MesasExamenesView(MemoryCacheServiceWinForms memoryCacheService, MenuPrincipalView menuPrincipal)
        {
            InitializeComponent();
            _memoryCache = memoryCacheService;
            this.MdiParent = menuPrincipal;
            this.WindowState = FormWindowState.Maximized;
            dataGridMesasExamenes.DataSource = bindingMesasExamenes;
            //tabPageAgregarEditar.Enabled= false;
            ObtenerListas();


        }

        private void CargarCombos()
        {
            cboTurnosExamenes.DataSource = listaTurnosExamenes.ToList();
            cboTurnosExamenes.DisplayMember = "Nombre";
            cboTurnosExamenes.ValueMember = "Id";

            cboCarreras.DataSource = listaCarreras.ToList();
            cboCarreras.DisplayMember = "Nombre";
            cboCarreras.ValueMember = "Id";

            cboAniosCarreras.DataSource = listaAnioCarreras.Where(a => a.Carrera.Id.Equals((int)cboCarreras.SelectedValue)).ToList();
            cboAniosCarreras.DisplayMember = "Nombre";
            cboAniosCarreras.ValueMember = "Id";

            cboMaterias.DataSource = listaMaterias.Where(m => m.AnioCarreraId.Equals((int)cboAniosCarreras.SelectedValue)).ToList();
            cboMaterias.DisplayMember = "Nombre";
            cboMaterias.ValueMember = "Id";

            cboDocentes.DataSource = listaDocentes.ToList();
            cboDocentes.DisplayMember = "Nombre";
            cboDocentes.ValueMember = "Id";


            AutoCompleteStringCollection autoCompletadoDocentes = new AutoCompleteStringCollection();
            foreach (Docente docente in listaDocentes.ToList())
            {
                autoCompletadoDocentes.Add(docente.Nombre.ToString());
            }
            cboDocentes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboDocentes.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboDocentes.AutoCompleteCustomSource = autoCompletadoDocentes;

            cboTipoIntegrante.DataSource = Enum.GetValues(typeof(TipoIntegranteEnum));

            CargarGrilla();
        }

        private async void ObtenerListas()
        {
            ShowInActivity.Show("Descargando turnos de exámenes, carreras y años, materias, docentes, y mesas de exámenes");
            //pongo todos los métodos en paralelo para que se ejecuten al mismo tiempo
            var tareas = new List<Task>
            {
                Task.Run(async () => listaTurnosExamenes = await _memoryCache.GetAllCacheAsync<TurnoExamen>()),
                //Task.Run(async () => listaCicloLectivos = await cicloLectivoService.GetAllAsync()),
                Task.Run(async () => listaCarreras = await _memoryCache.GetAllCacheAsync<Carrera>()),
                //Task.Run(async () => listaCarreras = await carreraService.GetAllAsync()),
                Task.Run(async () => listaAnioCarreras = await _memoryCache.GetAllCacheAsync<AnioCarrera>()),
                //Task.Run(async () => listaAnioCarreras = await anioCarreraService.GetAllAsync()),
                Task.Run(async () => listaMaterias = await _memoryCache.GetAllCacheAsync<Materia>()),
                //Task.Run(async () => listaMaterias = await materiaService.GetAllAsync()),
                Task.Run(async () => listaDocentes = await _memoryCache.GetAllCacheAsync<Docente>()),
                Task.Run(async () => listaMesasExamenes = await _memoryCache.GetAllCacheAsync<MesaExamen>())
                
                //Task.Run(async () => listaAulas = await aulaService.GetAllAsync())
            };
            bindingMesasExamenes.DataSource = listaMesasExamenes;
            //cuando terminan todas las tareas, cierro el showInActivity y cargo los combos
            await Task.WhenAll(tareas);
            ShowInActivity.Hide();
            CargarCombos();
        }


        private async Task CargarGrilla()
        {
            bindingMesasExamenes.DataSource = null;
            if (listaMesasExamenes != null && listaMesasExamenes.Count > 0)
                bindingMesasExamenes.DataSource = listaMesasExamenes.
                    Where(h => h.TurnoExamenId.Equals((int)cboTurnosExamenes.SelectedValue) &&
                          h.Materia.AnioCarrera.CarreraId.Equals((int)cboCarreras.SelectedValue) &&
                          h.Materia.AnioCarreraId.Equals((int)cboAniosCarreras.SelectedValue));
            var columnaOcultar = (cboTurnosExamenes.SelectedItem as TurnoExamen).TieneLLamado2 ? "" : "Llamado2";

            dataGridMesasExamenes.OcultarColumnas(new string[] { "Id", "MateriaId", "TurnoExamen", "DetallesMesaExamen", "TurnoExamenId", "Eliminado", columnaOcultar });
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(tabPageAgregarEditar);
            mesaExamenCurrent = new MesaExamen();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cboMaterias.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una materia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboTurnosExamenes.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un turno de examen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtHorario.Text == string.Empty)
            {
                MessageBox.Show("Debe ingresar un horario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (mesaExamenCurrent?.DetallesMesaExamen?.Count < 3)
            {
                MessageBox.Show("Debe definirse al menos tres docentes para la mesa de examen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var turnoExamen = (TurnoExamen)cboTurnosExamenes.SelectedItem;
                mesaExamenCurrent.MateriaId = (int)cboMaterias.SelectedValue;
                mesaExamenCurrent.Materia = (Materia)cboMaterias.SelectedItem;
                mesaExamenCurrent.Llamado1 = dateTime1erLlamado.Value;
                mesaExamenCurrent.Llamado2 = turnoExamen.TieneLLamado2?dateTime2doLlamado.Value:DateTime.MinValue;
                mesaExamenCurrent.Horario = txtHorario.Text;
                mesaExamenCurrent.TurnoExamenId = (int)cboTurnosExamenes.SelectedValue;
                mesaExamenCurrent.TurnoExamen = turnoExamen;

                if (mesaExamenCurrent.Id == 0)
                {
                    await _memoryCache.AddCacheAsync<MesaExamen>(mesaExamenCurrent);
                    //await horarioService.AddAsync(horarioCurrent);
                }
                else
                {
                    await _memoryCache.UpdateCacheAsync<MesaExamen>(mesaExamenCurrent);
                }
            }
            await actualizarListaMesasExamenes();
            await CargarGrilla();
            tabControl.SelectTab(tabPageLista);
        }

        private async Task actualizarListaMesasExamenes()
        {
            listaMesasExamenes = await _memoryCache.GetAllCacheAsync<MesaExamen>();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            mesaExamenCurrent = (MesaExamen)bindingMesasExamenes.Current;
            ActualizarTabAgregarEditar();
            tabControl.SelectTab(tabPageAgregarEditar);
        }

        private void ActualizarTabAgregarEditar()
        {
            var turnoExamen= (TurnoExamen)cboTurnosExamenes.SelectedItem;
            dateTime2doLlamado.Visible = turnoExamen.TieneLLamado2;
            lbl2doLlamado.Visible = turnoExamen.TieneLLamado2;
            cboMaterias.SelectedValue = mesaExamenCurrent?.MateriaId ?? 0;
            dateTime1erLlamado.Value = mesaExamenCurrent?.Llamado1 ?? DateTime.Now;
            dateTime2doLlamado.Value = mesaExamenCurrent?.Llamado2 ?? DateTime.Now;
            txtHorario.Text = mesaExamenCurrent?.Horario ?? string.Empty;
            dataGridDetallesMesa.DataSource = mesaExamenCurrent?.DetallesMesaExamen?.OrderBy(d => d.TipoIntegrante).ToList() ?? null;
            dataGridDetallesMesa.OcultarColumnas(new string[] { "DocenteId", "MesaExamen", "MesaExamenId", "Id", "Eliminado" });
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            mesaExamenCurrent = (MesaExamen)bindingMesasExamenes.Current;
            var result = MessageBox.Show($"¿Está seguro que desea eliminar la mesa de {mesaExamenCurrent.Materia.Nombre}?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                await _memoryCache.DeleteCacheAsync<MesaExamen>(mesaExamenCurrent.Id);
                await actualizarListaMesasExamenes();
                await CargarGrilla();
            }
            mesaExamenCurrent = null;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mesaExamenCurrent = null;
            ActualizarTabAgregarEditar();
            tabControl.SelectTab(tabPageLista);

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {

        }



        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
        }

        private void cboCarreras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCarreras.SelectedValue != null && cboCarreras.SelectedValue.GetType() == typeof(int))
            {
                cboAniosCarreras.DataSource = listaAnioCarreras.Where(a => a.Carrera.Id.Equals(cboCarreras.SelectedValue)).ToList();
            }
        }

        private void btnAgregarDetalleMesaExamen_Click(object sender, EventArgs e)
        {
            var docente = (Docente)cboDocentes.SelectedItem;
            if (mesaExamenCurrent.DetallesMesaExamen.Count>0&&mesaExamenCurrent.DetallesMesaExamen.Any(d => d.DocenteId.Equals(docente.Id)))
            {
                MessageBox.Show("El docente ya se encuentra asignado a la mesa de examen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(cboTipoIntegrante.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de integrante", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(mesaExamenCurrent.DetallesMesaExamen.Any(d => d.TipoIntegrante.Equals((TipoIntegranteEnum)cboTipoIntegrante.SelectedItem))&&detalleMesaExamenEdit==null&&(TipoIntegranteEnum)cboTipoIntegrante.SelectedItem != TipoIntegranteEnum.Suplente)
            {
                MessageBox.Show($"Ya existe un docente definido como {cboTipoIntegrante.SelectedItem}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (detalleMesaExamenEdit != null)
            {
                detalleMesaExamenEdit.DocenteId = docente.Id;
                detalleMesaExamenEdit.Docente = docente;
                detalleMesaExamenEdit.TipoIntegrante = (TipoIntegranteEnum)cboTipoIntegrante.SelectedItem;
                var detalleToDelete = (DetalleMesaExamen)dataGridDetallesMesa.CurrentRow.DataBoundItem;
                mesaExamenCurrent.DetallesMesaExamen.Remove(detalleToDelete);
                mesaExamenCurrent.DetallesMesaExamen.Add(detalleMesaExamenEdit);
                btnAgregarDetalleMesa.Text = "Agregar";
                detalleMesaExamenEdit = null;
            }
            else
            {
                mesaExamenCurrent.DetallesMesaExamen.Add(new DetalleMesaExamen { DocenteId = docente.Id, Docente = docente, TipoIntegrante = (TipoIntegranteEnum)cboTipoIntegrante.SelectedItem });
            }

            dataGridDetallesMesa.DataSource = null;
            dataGridDetallesMesa.DataSource = mesaExamenCurrent.DetallesMesaExamen.OrderBy(d => d.TipoIntegrante).ToList();
            dataGridDetallesMesa.OcultarColumnas(new string[] { "DocenteId","MesaExamen", "MesaExamenId", "Id", "Eliminado" });
            btnAgregarDetalleMesa.Text = "Agregar";


        }



        private void btnQuitarDocente_Click(object sender, EventArgs e)
        {
            if (dataGridDetallesMesa.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un docente para quitar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var detalleMesaExamen = (DetalleMesaExamen)dataGridDetallesMesa.CurrentRow.DataBoundItem;
            mesaExamenCurrent.DetallesMesaExamen.Remove(mesaExamenCurrent.DetallesMesaExamen.First(d => d.Id.Equals(detalleMesaExamen.Id)));
            dataGridDetallesMesa.DataSource = null;
            dataGridDetallesMesa.DataSource = mesaExamenCurrent.DetallesMesaExamen;
            dataGridDetallesMesa.OcultarColumnas(new string[] { "DocenteId", "MesaExamen", "MesaExamenId", "Id", "Eliminado" });

        }



        private void cboAniosCarreras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAniosCarreras.SelectedValue != null && cboAniosCarreras.SelectedValue.GetType() == typeof(int))
            {
                cboMaterias.DataSource = listaMaterias.Where(m => m.AnioCarreraId.Equals(cboAniosCarreras.SelectedValue)).ToList();
                CargarGrilla();
            }
        }

        private void iconButtonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (dataGridDetallesMesa.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un docente para editar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            detalleMesaExamenEdit = (DetalleMesaExamen)dataGridDetallesMesa.CurrentRow.DataBoundItem;
            cboDocentes.SelectedValue = detalleMesaExamenEdit.DocenteId;
            cboTipoIntegrante.SelectedItem = detalleMesaExamenEdit.TipoIntegrante;
            btnAgregarDetalleMesa.Text = "Actualizar";

        }

        private void cboTurnosExamenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTurnosExamenes.SelectedValue != null && cboTurnosExamenes.SelectedValue.GetType() == typeof(int))
            {
                CargarGrilla();
                dateTime2doLlamado.Visible = (cboTurnosExamenes.SelectedItem as TurnoExamen).TieneLLamado2;
                lbl2doLlamado.Visible = (cboTurnosExamenes.SelectedItem as TurnoExamen).TieneLLamado2;
                lblPrimerLlamado.Text = (cboTurnosExamenes.SelectedItem as TurnoExamen).TieneLLamado2 ? "Primer llamado" : "Fecha mesa:";
            }
        }

        private void dateTime1erLlamado_ValueChanged(object sender, EventArgs e)
        {
            dateTime2doLlamado.Value = dateTime1erLlamado.Value.AddDays(15);
        }
    }
}
