using InstitutoDesktop.ExtensionMethods;
using InstitutoDesktop.Services;
using InstitutoDesktop.Util;
using InstitutoDesktop.Views.Commons.Materias;
using InstitutoServices.Interfaces;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Horarios;
using InstitutoServices.Services.Commons;
using Microsoft.Extensions.DependencyInjection;

namespace InstitutoDesktop.Views.Horarios
{
    public partial class HorasView : Form
    {
        BindingSource BindingHoras = new BindingSource();
        List<Hora> listaHoras = new List<Hora>();
        private readonly MemoryCacheServiceWinForms _memoryCache;
        private readonly IServiceProvider _serviceProvider;

        public HorasView(MemoryCacheServiceWinForms memoryCacheService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _memoryCache = memoryCacheService;
            _serviceProvider = serviceProvider;
            dataGridHoras.DataSource = BindingHoras;

            CargarGrilla();
        }
        private async Task CargarGrilla()
        {
            listaHoras = await _memoryCache.GetAllCacheAsync<Hora>();
            BindingHoras.DataSource = listaHoras.OrderBy(h=>h.Desde).ToList();
            dataGridHoras.OcultarColumnas(new string[] { "Desde", "Hasta", "Eliminado" });

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarEditarHoraView agregarEditarHora = ActivatorUtilities.CreateInstance<AgregarEditarHoraView>(_serviceProvider);
            agregarEditarHora.ShowDialog();
            CargarGrilla();
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            var hora = (Hora)BindingHoras.Current;
            AgregarEditarHoraView agregarEditarHoraView = ActivatorUtilities.CreateInstance<AgregarEditarHoraView>(_serviceProvider, hora);
            agregarEditarHoraView.ShowDialog();
            await CargarGrilla();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var hora = (Hora)BindingHoras.Current;
            var respuesta = MessageBox.Show($"¿Está seguro que quiere borrar a la carrera {hora.Nombre}", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                //await horaService.DeleteAsync(hora.Id);
                await _memoryCache.DeleteCacheAsync<Hora>(hora.Id);
                await CargarGrilla();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            BindingHoras.DataSource = listaHoras.Where(h => h.Nombre.Contains(txtFiltro.Text)).OrderBy(h => h.Desde).ToList();

        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            BtnBuscar.PerformClick();
        }
    }
}
