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
using InstitutoServices.Models;
using InstitutoServices.Services.Commons;
using InstitutoServices.Models.Commons;
using InstitutoDesktop.Util;
using InstitutoDesktop.Services;

namespace InstitutoDesktop.Views.Commons
{
    public partial class AgregarEditarCarreraView : Form
    {
        private readonly MemoryCacheServiceWinForms _memoryCache;

        private Carrera carrera;

        //nuevo
        public AgregarEditarCarreraView(MemoryCacheServiceWinForms memoryCache)
        {
            InitializeComponent();
            carrera=new Carrera();
            _memoryCache = memoryCache;
        }

        //editar
        public AgregarEditarCarreraView(MemoryCacheServiceWinForms memoryCache,Carrera carrera)
        {
            InitializeComponent();
            this.carrera = carrera;
            _memoryCache = memoryCache;
            CargarDatosCarreraAEditar();
        }

        private async void CargarDatosCarreraAEditar()
        {
            txtNombre.Text = carrera.Nombre;
            txtSigla.Text = carrera.Sigla;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            carrera.Nombre = txtNombre.Text;
            carrera.Sigla = txtSigla.Text;
            
            if (carrera.Id == 0)
            {
                await _memoryCache.AddCacheAsync<Carrera>(carrera);
            }
            else
            {
                await _memoryCache.UpdateCacheAsync<Carrera>(carrera);
            }
            this.Close();
        }
    }
}
