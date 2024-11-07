using InstitutoDesktop.Services;
using InstitutoServices.Interfaces;
using InstitutoServices.Models.Inscripciones;
using InstitutoServices.Services.Commons;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstitutoDesktop.Views.Inscripciones.PeriodosInscripciones
{
    public partial class PeriodoInscripcionView : Form
    {
       
        BindingSource listaPeriodosInscripcion = new BindingSource();
        private readonly MemoryCacheServiceWinForms _memoryCache;
        private readonly IServiceProvider _serviceProvider;
        private readonly PeriodoInscripcion _periodoInscripcion;
        public PeriodoInscripcionView(MemoryCacheServiceWinForms memoryCacheService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _memoryCache = memoryCacheService;
            _serviceProvider = serviceProvider;
            _periodoInscripcion = _periodoInscripcion;
            dataGridPeriodoInscripcion.DataSource = listaPeriodosInscripcion;
            CargarGrilla();
        }

        private async Task CargarGrilla()
        {
            listaPeriodosInscripcion.DataSource = null;
            listaPeriodosInscripcion.DataSource = await _memoryCache.GetAllCacheAsync<PeriodoInscripcion>();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {

            AgregarEditarPeriodoInscripcionView agregarEditarPeriodoInscripcionView = ActivatorUtilities.CreateInstance<AgregarEditarPeriodoInscripcionView>(_serviceProvider);
            agregarEditarPeriodoInscripcionView.ShowDialog();

            await CargarGrilla();
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            var periodoInscripcion = (PeriodoInscripcion)listaPeriodosInscripcion.Current;
            AgregarEditarPeriodoInscripcionView agregarEditarPeriodoInscripcionView =
        ActivatorUtilities.CreateInstance<AgregarEditarPeriodoInscripcionView>(_serviceProvider, periodoInscripcion);
            agregarEditarPeriodoInscripcionView.ShowDialog();
            await CargarGrilla();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var periodoInscripcion = (PeriodoInscripcion)listaPeriodosInscripcion.Current;

            var respuesta = MessageBox.Show($"¿Está seguro que quiere borrar el período de inscripción{periodoInscripcion.Nombre}", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                //await ciclolectivoService.DeleteAsync(ciclolectivo.Id);
                await _memoryCache.DeleteCacheAsync<PeriodoInscripcion>(periodoInscripcion.Id);
                await CargarGrilla();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
