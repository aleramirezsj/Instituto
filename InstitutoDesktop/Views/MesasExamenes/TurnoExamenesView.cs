using InstitutoDesktop.ExtensionMethods;
using InstitutoDesktop.Services;
using InstitutoDesktop.Util;
using InstitutoDesktop.Views.Commons.Materias;
using InstitutoDesktop.Views.Inscripciones;
using InstitutoServices.Interfaces;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.MesasExamenes;
using InstitutoServices.Services.Commons;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstitutoDesktop.Views.MesasExamenes
{
    public partial class TurnoExamenesView : Form
    {
        private BindingSource listaTurnos = new BindingSource();
        private readonly MemoryCacheServiceWinForms _memoryCache;
        private readonly IServiceProvider _serviceProvider;

        public TurnoExamenesView(MemoryCacheServiceWinForms memoryCacheService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _memoryCache = memoryCacheService;
            _serviceProvider = serviceProvider;
            dataGridTurnoExamenes.DataSource = listaTurnos;
            CargarGrilla();
        }

        private async Task CargarGrilla()
        {
            listaTurnos.DataSource = null;
            listaTurnos.DataSource = (await _memoryCache.GetAllCacheAsync<TurnoExamen>()).OrderBy(turno=>turno.Id);
            dataGridTurnoExamenes.OcultarColumnas(new string[] {"Id", "Eliminado" });
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var turnoexamen = (TurnoExamen)listaTurnos.Current;
            if (turnoexamen == null)
            {
                MessageBox.Show("Debe seleccionar un turno de examen para eliminar.");
                return;
            }

            var respuesta = MessageBox.Show($"¿Está seguro que quiere borrar el Ciclo Lectivo {turnoexamen.Nombre}?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                await _memoryCache.DeleteCacheAsync<TurnoExamen>(turnoexamen.Id);
                await CargarGrilla();
            }
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarEditarTurnoExamenesView agregarEditarTurnoExamenesView = ActivatorUtilities.CreateInstance<AgregarEditarTurnoExamenesView>(_serviceProvider);
            agregarEditarTurnoExamenesView.ShowDialog();
            await CargarGrilla();

            
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            var turnoexamen = (TurnoExamen)listaTurnos.Current;
            if (turnoexamen == null)
            {
                MessageBox.Show("Debe seleccionar un valor de la grilla");
                return;
            }
            AgregarEditarTurnoExamenesView agregarEditarTurnoExamenesView = ActivatorUtilities.CreateInstance<AgregarEditarTurnoExamenesView>(_serviceProvider, turnoexamen);
            agregarEditarTurnoExamenesView.ShowDialog();

                    await CargarGrilla();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
