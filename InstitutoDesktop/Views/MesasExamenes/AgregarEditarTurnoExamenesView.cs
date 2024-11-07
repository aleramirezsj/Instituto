using InstitutoServices.Models;
using InstitutoServices.Interfaces;
using InstitutoServices.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InstitutoServices.Services.Commons;
using InstitutoServices.Models.MesasExamenes;
using InstitutoDesktop.Services;
using InstitutoServices.Models.Inscripciones;

namespace InstitutoDesktop.Views.MesasExamenes
{
    public partial class AgregarEditarTurnoExamenesView : Form
    {
        private TurnoExamen turnoexamen;
        private readonly MemoryCacheServiceWinForms _memoryCache;

        public AgregarEditarTurnoExamenesView(MemoryCacheServiceWinForms memoryCacheService)
        {
            InitializeComponent();
            _memoryCache = memoryCacheService;
            turnoexamen = new TurnoExamen();
           CargarCombo();
        }

        public AgregarEditarTurnoExamenesView(MemoryCacheServiceWinForms memoryCacheService, TurnoExamen turnoexamen)
        {
            InitializeComponent();
            _memoryCache = memoryCacheService;
            this.turnoexamen = turnoexamen;
            CargarDatosEnPantalla();
            CargarCombo();
            cbmBoxCicloLectivo.SelectedItem = turnoexamen.CicloLectivo;
        }

        private async void CargarCombo()
        {
            cbmBoxCicloLectivo.DataSource = await _memoryCache.GetAllCacheAsync<CicloLectivo>();
            cbmBoxCicloLectivo.DisplayMember = "Nombre";
            cbmBoxCicloLectivo.ValueMember = "Id";
        }

        private async void CargarDatosEnPantalla()
        {
            txtNombre.Text = turnoexamen.Nombre;
            chkActual.Checked = turnoexamen.Actual; // Cargar el estado del checkbox
            cbmBoxCicloLectivo.SelectedValue = turnoexamen.CicloLectivoId;
            chkInscripcionHabilitada.Checked = turnoexamen.InscripcionHabilitada;
            chkSegundoLlamado.Checked = turnoexamen.TieneLLamado2;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            turnoexamen.Nombre = txtNombre.Text;
            turnoexamen.CicloLectivoId=(int)cbmBoxCicloLectivo.SelectedValue  ;
            turnoexamen.CicloLectivo = (CicloLectivo)cbmBoxCicloLectivo.SelectedItem;
            turnoexamen.Actual = chkActual.Checked;
            turnoexamen.InscripcionHabilitada = chkInscripcionHabilitada.Checked;
            turnoexamen.TieneLLamado2 = chkSegundoLlamado.Checked;
            if (turnoexamen.Id == 0)
            {
                //await turnoexamenesService.AddAsync(turnoexamen);
                await _memoryCache.AddCacheAsync<TurnoExamen>(turnoexamen);
            }
            else
            {
                await _memoryCache.UpdateCacheAsync<TurnoExamen>(turnoexamen);
                //await turnoexamenesService.UpdateAsync(turnoexamen);
            }

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cbmBoxCicloLectivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

    }
}
