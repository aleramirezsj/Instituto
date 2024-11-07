using InstitutoDesktop.Services;
using InstitutoServices.Models.Horarios;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Inscripciones;
using InstitutoServices.Models.MesasExamenes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstitutoDesktop.Views.Horarios
{
    public partial class AgregarEditarPeriodoHorarioView : Form
    {
        private PeriodoHorario periodoHorario;
        private readonly MemoryCacheServiceWinForms _memoryCache;

        public AgregarEditarPeriodoHorarioView(MemoryCacheServiceWinForms memoryCacheService)
        {
            InitializeComponent();
            _memoryCache = memoryCacheService;
            periodoHorario = new PeriodoHorario();
        }
        public AgregarEditarPeriodoHorarioView(MemoryCacheServiceWinForms memoryCacheService, PeriodoHorario periodoHorario)
        {
            InitializeComponent();
            _memoryCache = memoryCacheService;
            this.periodoHorario = periodoHorario;
            CargarDatosEnPantalla();
        }

        private async void CargarDatosEnPantalla()
        {
            comboBoxCicloLectivo.DataSource = await _memoryCache.GetAllCacheAsync<CicloLectivo>();
            comboBoxCicloLectivo.DisplayMember = "Nombre"; // Nombre de la propiedad a mostrar
            comboBoxCicloLectivo.ValueMember = "Id"; // Nombre de la propiedad de valor único
            chMaterias2doCuatrimestre.Checked = periodoHorario.Es2doCuatrimestre;

            // Asigna los valores al resto de controles
            txtNombre.Text = periodoHorario.Nombre;
            chkActual.Checked = periodoHorario.Actual;

            // Selecciona el ciclo lectivo predefinido en el ComboBox
            if (periodoHorario.CicloLectivo != null)
            {
                comboBoxCicloLectivo.SelectedValue = periodoHorario.CicloLectivoId;
            }


            //txtNombre.Text = periodoHorario.Nombre;
            //chkActual.Checked = periodoHorario.Actual;
            //comboBoxCicloLectivo.Text = periodoHorario.CicloLectivo.Nombre;
            ////comboBoxCicloLectivo.DataSource = periodoHorario.CicloLectivo;
            ////comboBoxCicloLectivo.Items.Contains(periodoHorario.CicloLectivo);
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            periodoHorario.CicloLectivo = comboBoxCicloLectivo.SelectedItem as CicloLectivo;
            periodoHorario.CicloLectivoId = (int)comboBoxCicloLectivo.SelectedValue;
            periodoHorario.Es2doCuatrimestre = chMaterias2doCuatrimestre.Checked;
            periodoHorario.Nombre = txtNombre.Text;
            periodoHorario.Actual = chkActual.Checked;
            if (periodoHorario.Id == 0)
            {
                await _memoryCache.AddCacheAsync<PeriodoHorario>(periodoHorario);
            }
            else
            {
                await _memoryCache.UpdateCacheAsync<PeriodoHorario>(periodoHorario);
            }

            this.Close();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
