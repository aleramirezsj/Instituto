using InstitutoDesktop.Services;
using InstitutoServices.Enums;
using InstitutoServices.Models;
using InstitutoServices.Models.Commons;
using InstitutoServices.Services;
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

namespace InstitutoDesktop.Views.Commons.Materias
{
    public partial class NuevoEditarMateriaView : Form
    {
        Materia materia;
        private readonly MemoryCacheServiceWinForms _memoryCache;

        // NUEVO
        public NuevoEditarMateriaView(MemoryCacheServiceWinForms memoryCacheService, Carrera carrera, AnioCarrera anioCarrera)
        {
            InitializeComponent();
            _memoryCache = memoryCacheService;
            materia = new Materia { AnioCarreraId = anioCarrera.Id };

            // Mostrar el año y carrera combinados en el TextBox
            txtAnioYCarrera.Text = anioCarrera.AñoYCarrera;

            // Poblar el ComboBox con los valores de TipoMateriaEnum
            cmbTipoMateria.DataSource = Enum.GetValues(typeof(TipoMateriaEnum));
        }

        // EDITAR
        public NuevoEditarMateriaView(MemoryCacheServiceWinForms memoryCacheService, Materia materia, AnioCarrera anioCarrera)
        {
            InitializeComponent();
            _memoryCache = memoryCacheService;
            this.materia = materia;

            // Mostrar el año y carrera combinados en el TextBox
            if (anioCarrera != null)
            {
                txtAnioYCarrera.Text = anioCarrera.AñoYCarrera;
            }

            // Mostrar el nombre de la materia en el TextBox correspondiente
            txtMateria.Text = materia.Nombre;

            // Mostrar si la materia es recreo o no en el CheckBox correspondiente
            chkEsRecreo.Checked = materia.EsRecreo;

            
            cmbTipoMateria.DataSource = Enum.GetValues(typeof(TipoMateriaEnum));
            cmbTipoMateria.SelectedItem = materia.TipoMateria; 
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            materia.Nombre = txtMateria.Text;
            materia.EsRecreo = chkEsRecreo.Checked;
            materia.TipoMateria = (TipoMateriaEnum)cmbTipoMateria.SelectedItem;

            if (materia.Id == 0)
            {
                await _memoryCache.AddCacheAsync<Materia>(materia);
            }
            else
            {
                await _memoryCache.UpdateCacheAsync<Materia>(materia);
            }

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbTipoMateria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
