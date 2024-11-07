using InstitutoDesktop.ExtensionMethods;
using InstitutoDesktop.Services;
using InstitutoDesktop.Util;
using InstitutoDesktop.Views.Commons;
using InstitutoServices.Interfaces;
using InstitutoServices.Models.Commons;
using InstitutoServices.Services.Commons;
using Microsoft.Extensions.DependencyInjection;

namespace InstitutoDesktop.Views
{
    public partial class CarrerasView : Form
    {
        BindingSource listaCarreras = new BindingSource();
        private readonly MemoryCacheServiceWinForms _memoryCache;
        private readonly IServiceProvider _serviceProvider;


        public CarrerasView(MemoryCacheServiceWinForms memoryCacheService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _memoryCache = memoryCacheService;
            dataGridCarreras.DataSource = listaCarreras;
            CargarGrilla();
            _serviceProvider = serviceProvider;
        }

        private async Task CargarGrilla()
        {
            listaCarreras.DataSource = null;
            listaCarreras.DataSource = await _memoryCache.GetAllCacheAsync<Carrera>();

            dataGridCarreras.OcultarColumnas(new string[] { "Eliminado" });
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarEditarCarreraView agregarEditarCarreraView = ActivatorUtilities.CreateInstance<AgregarEditarCarreraView>(_serviceProvider);
            agregarEditarCarreraView.ShowDialog();
            CargarGrilla();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var carrera = (Carrera)listaCarreras.Current;
            var respuesta = MessageBox.Show($"¿Está seguro que quiere borrar a la carrera {carrera.Nombre}", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                await _memoryCache.DeleteCacheAsync<Carrera>(carrera.Id);
                await CargarGrilla();
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            var carrera = (Carrera)listaCarreras.Current;
            var agregarEditarCarreraView = ActivatorUtilities.CreateInstance<AgregarEditarCarreraView>(_serviceProvider, carrera);
            agregarEditarCarreraView.ShowDialog();
            await CargarGrilla();
        }
    }
}
