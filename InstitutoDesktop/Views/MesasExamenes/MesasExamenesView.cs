﻿using InstitutoDesktop.ExtensionMethods;
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

        public MesasExamenesView(MemoryCacheServiceWinForms memoryCacheService)
        {
            InitializeComponent();
            _memoryCache = memoryCacheService;
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
                Task.Run(async () => listaTurnosExamenes = await _memoryCache.GetAllCacheAsync<TurnoExamen>("TurnosExamenes")),
                //Task.Run(async () => listaCicloLectivos = await cicloLectivoService.GetAllAsync()),
                Task.Run(async () => listaCarreras = await _memoryCache.GetAllCacheAsync<Carrera>("Carreras")),
                //Task.Run(async () => listaCarreras = await carreraService.GetAllAsync()),
                Task.Run(async () => listaAnioCarreras = await _memoryCache.GetAllCacheAsync<AnioCarrera>("AniosCarreras")),
                //Task.Run(async () => listaAnioCarreras = await anioCarreraService.GetAllAsync()),
                Task.Run(async () => listaMaterias = await _memoryCache.GetAllCacheAsync<Materia>("Materias")),
                //Task.Run(async () => listaMaterias = await materiaService.GetAllAsync()),
                Task.Run(async () => listaDocentes = await _memoryCache.GetAllCacheAsync<Docente>("Docentes")),
                Task.Run(async () => listaMesasExamenes = await _memoryCache.GetAllCacheAsync<MesaExamen>("MesasExamenes"))
                
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
            if (listaMesasExamenes != null && listaMesasExamenes.Count > 0)
                bindingMesasExamenes.DataSource = listaMesasExamenes.
                    Where(h => h.TurnoExamenId.Equals((int)cboTurnosExamenes.SelectedValue) &&
                          h.Materia.AnioCarrera.CarreraId.Equals((int)cboCarreras.SelectedValue) &&
                          h.Materia.AnioCarreraId.Equals((int)cboAniosCarreras.SelectedValue));
            dataGridMesasExamenes.OcultarColumnas(new string[] { "Id","MateriaId", "TurnoExamen", "DetallesMesaExamen",  "TurnoExamenId", "Eliminado" });
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
            if (mesaExamenCurrent?.DetallesMesaExamen?.Count < 3 )
            {
                MessageBox.Show("Debe definirse al menos tres docente para la mesa de examen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }else
            {
                mesaExamenCurrent.MateriaId = (int)cboMaterias.SelectedValue;
                mesaExamenCurrent.TurnoExamenId = (int)cboTurnosExamenes.SelectedValue;
                mesaExamenCurrent.Materia = (Materia)cboMaterias.SelectedItem;
                mesaExamenCurrent.TurnoExamen = (TurnoExamen)cboTurnosExamenes.SelectedItem;

                if (mesaExamenCurrent.Id == 0)
                {
                    await _memoryCache.AddCacheAsync<MesaExamen>(mesaExamenCurrent, "MesasExamenes");
                    //await horarioService.AddAsync(horarioCurrent);
                }
                else
                {
                    await _memoryCache.UpdateCacheAsync<MesaExamen>(mesaExamenCurrent, "MesasExamenes");
                }
            }
            await actualizarListaMesasExamenes();
            await CargarGrilla();
            tabControl.SelectTab(tabPageLista);
        }

        private async Task actualizarListaMesasExamenes()
        {
            listaMesasExamenes = await _memoryCache.GetAllCacheAsync<MesaExamen>("MesasExamenes");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            mesaExamenCurrent = (MesaExamen)bindingMesasExamenes.Current;
            ActualizarTabAgregarEditar();
            tabControl.SelectTab(tabPageAgregarEditar);
        }

        private void ActualizarTabAgregarEditar()
        {
            cboMaterias.SelectedValue = mesaExamenCurrent?.MateriaId ?? 0;
            dataGridDetallesMesa.DataSource = mesaExamenCurrent?.DetallesMesaExamen ?? null;
            dataGridDetallesMesa.OcultarColumnas(new string[] { "MesaExamen", "MesaExamenId", "Id", "Eliminado" });

        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            mesaExamenCurrent = (MesaExamen)bindingMesasExamenes.Current;
            var result = MessageBox.Show($"¿Está seguro que desea eliminar la mesa de {mesaExamenCurrent.Materia.Nombre}?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                await _memoryCache.DeleteCacheAsync<MesaExamen>(mesaExamenCurrent.Id, "MesasExamenes");
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

        private void btnAgregarDocente_Click(object sender, EventArgs e)
        {
            var docente = (Docente)cboDocentes.SelectedItem;
            if (mesaExamenCurrent.DetallesMesaExamen.Any(d => d.DocenteId.Equals(docente.Id)))
            {
                MessageBox.Show("El docente ya se encuentra asignado a la mesa de examen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            mesaExamenCurrent.DetallesMesaExamen.Add(new DetalleMesaExamen { DocenteId = docente.Id, Docente = docente, TipoIntegrante=(TipoIntegranteEnum)cboTipoIntegrante.SelectedItem });
            dataGridDetallesMesa.DataSource = null;
            dataGridDetallesMesa.DataSource = mesaExamenCurrent.DetallesMesaExamen;
            dataGridDetallesMesa.OcultarColumnas(new string[] { "MesaExamen", "MesaExamenId", "Id", "Eliminado" });
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
            dataGridDetallesMesa.OcultarColumnas(new string[] { "MesaExamen", "MesaExamenId", "Id", "Eliminado" });


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
            btnAgregarDetalleMesa.Text = "Actualizar";

        }
    }
}