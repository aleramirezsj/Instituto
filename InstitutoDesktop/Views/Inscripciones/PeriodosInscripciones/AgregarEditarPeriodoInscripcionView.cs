using InstitutoDesktop.Services;
using InstitutoServices.Interfaces;
using InstitutoServices.Models.Inscripciones;
using InstitutoServices.Services.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstitutoDesktop.Views.Inscripciones
{
    public partial class AgregarEditarPeriodoInscripcionView : Form
    {
        private PeriodoInscripcion periodoInscripcion;
        private readonly MemoryCacheServiceWinForms _memoryCache;
        public AgregarEditarPeriodoInscripcionView(MemoryCacheServiceWinForms memoryCacheService)
        {
            InitializeComponent();
            _memoryCache = memoryCacheService;
            periodoInscripcion = periodoInscripcion;
            CargarDatosCiclosLectivos();
            CargarDatosPeriodoInscripcionAEditar();

        }
        public AgregarEditarPeriodoInscripcionView(MemoryCacheServiceWinForms memoryCacheService, PeriodoInscripcion periodoInscripcion)
        {
            InitializeComponent();
            _memoryCache = memoryCacheService;
            this.periodoInscripcion = null;
            this.periodoInscripcion = periodoInscripcion;
            CargarDatosCiclosLectivos();
            CargarDatosPeriodoInscripcionAEditar();
        }

        private async void CargarDatosCiclosLectivos()
        {
            var ciclosLectivos = await _memoryCache.GetAllCacheAsync<CicloLectivo>();
            cboCiclosLectivos.DataSource = ciclosLectivos;
            cboCiclosLectivos.DisplayMember = "Nombre";
            cboCiclosLectivos.ValueMember = "Id";
        }

        private void CargarDatosPeriodoInscripcionAEditar()
        {
            if (periodoInscripcion == null)
            {
             
                return;
            }

            txtNombre.Text = periodoInscripcion.Nombre;

            if (periodoInscripcion.CicloLectivo != null)
            {
                cboCiclosLectivos.Text = periodoInscripcion.CicloLectivo.Nombre;
            }
            else
            {
                // Manejar el caso de null, tal vez establecer un valor predeterminado o registrar un error
                cboCiclosLectivos.Text = string.Empty;
            }

            chInscripcionActiva.Checked = periodoInscripcion.InscripcionHabilitada;
            chMaterias2doCuatrimestre.Checked = periodoInscripcion.Es2doCuatrimestre;
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            periodoInscripcion.Nombre = txtNombre.Text;
            periodoInscripcion.CicloLectivo = (CicloLectivo)cboCiclosLectivos.SelectedItem;
            periodoInscripcion.CicloLectivoId=(int)cboCiclosLectivos.SelectedValue;
            periodoInscripcion.InscripcionHabilitada = chInscripcionActiva.Checked;
            periodoInscripcion.Es2doCuatrimestre = chMaterias2doCuatrimestre.Checked;


            if (periodoInscripcion.Id == 0)
            {
                await _memoryCache.AddCacheAsync<PeriodoInscripcion>(periodoInscripcion);
                //await ciclolectivoService.AddAsync(cicloLectivo);
            }
            else
            {
                await _memoryCache.UpdateCacheAsync<PeriodoInscripcion>(periodoInscripcion);
                //await ciclolectivoService.UpdateAsync(cicloLectivo);
            }

            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

