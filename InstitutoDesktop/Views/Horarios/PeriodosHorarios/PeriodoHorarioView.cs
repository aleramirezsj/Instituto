using InstitutoDesktop.Services;
using InstitutoDesktop.ExtensionMethods;
using InstitutoServices.Models.Horarios;
using Microsoft.Extensions.DependencyInjection;
using InstitutoDesktop.Views.MesasExamenes;

namespace InstitutoDesktop.Views.Horarios
{
    public partial class PeriodoHorarioView : Form
    {
        private BindingSource listaPeriodoHorario = new BindingSource();
        private readonly MemoryCacheServiceWinForms _memoryCache;
        private readonly IServiceProvider _serviceProvider;
        public PeriodoHorarioView(MemoryCacheServiceWinForms memoryCacheService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _memoryCache = memoryCacheService;
            _serviceProvider = serviceProvider;
            dataGridPeriodoHorario.DataSource = listaPeriodoHorario;
            CargarGrilla();
        }

        private async Task CargarGrilla()
        {
            listaPeriodoHorario.DataSource = null;
            listaPeriodoHorario.DataSource = await _memoryCache.GetAllCacheAsync<PeriodoHorario>();
            dataGridPeriodoHorario.OcultarColumnas(new string[] { "Id", "Eliminado", "CicloLectivoId" });
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var periodoHorario = (PeriodoHorario)listaPeriodoHorario.Current;
            if (periodoHorario == null)
            {
                MessageBox.Show("Debe seleccionar un turno de examen para eliminar.");
                return;
            }

            var respuesta = MessageBox.Show($"¿Está seguro que quiere borrar el Ciclo Lectivo {periodoHorario.Nombre}?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                await _memoryCache.DeleteCacheAsync<PeriodoHorario>(periodoHorario.Id);
                await CargarGrilla();
            }
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarEditarPeriodoHorarioView agregarEditarPeriodoHorarioView = ActivatorUtilities.CreateInstance<AgregarEditarPeriodoHorarioView>(_serviceProvider);
            agregarEditarPeriodoHorarioView.ShowDialog();
            await CargarGrilla();
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            var periodo = listaPeriodoHorario.Current;
            AgregarEditarPeriodoHorarioView agregarEditarPeriodoHorarioView = ActivatorUtilities.CreateInstance<AgregarEditarPeriodoHorarioView>(_serviceProvider,periodo);
            agregarEditarPeriodoHorarioView.ShowDialog();
            await CargarGrilla();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
