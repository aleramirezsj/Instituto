using InstitutoDesktop.ExtensionMethods;
using InstitutoDesktop.Services;
using InstitutoDesktop.Util;
using InstitutoServices.Models.Commons;
using InstitutoServices.Services.Commons;
using Microsoft.Extensions.DependencyInjection;

namespace InstitutoDesktop.Views.Commons.Materias
{
    public partial class MateriaView : Form
    {
        BindingSource BindingAniosCarrera = new BindingSource();
        BindingSource BindingCarreras = new BindingSource();
        BindingSource BindingMaterias = new BindingSource();
        List<AnioCarrera>? ListAniosCarreraFiltrada = new List<AnioCarrera>();
        List<Materia>? ListMateriasFiltrada = new List<Materia>();
        private readonly MemoryCacheServiceWinForms _memoryCache;
        private readonly IServiceProvider _serviceProvider;


        public MateriaView(MemoryCacheServiceWinForms memoryCacheService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _memoryCache = memoryCacheService;
            _serviceProvider = serviceProvider;

            ObtenerListas();
        }

        private async void ObtenerListas()
        {
            ShowInActivity.Show("Descargando carreras, años de la carrera y materias");
            var tareas = new List<Task>()
            {
                Task.Run(async () => BindingCarreras.DataSource = await _memoryCache.GetAllCacheAsync<Carrera>()),
                //Task.Run(async () => BindingCarreras.DataSource = await carreraService.GetAllAsync()),
                //Task.Run(async () => ListAniosCarreraFiltrada = await anioCarreraService.GetAllAsync()),
                Task.Run(async () => ListAniosCarreraFiltrada = await _memoryCache.GetAllCacheAsync<AnioCarrera>()),
                //Task.Run(async () => ListMateriasFiltrada = await materiaService.GetAllAsync())
                Task.Run(async () => ListMateriasFiltrada = await _memoryCache.GetAllCacheAsync<Materia>())
            };
            await Task.WhenAll(tareas);
            ShowInActivity.Hide();
            BindingAniosCarrera.DataSource = ListAniosCarreraFiltrada;
            BindingMaterias.DataSource = ListMateriasFiltrada;
            CargarCboCarreras();
        }

        private async void ActualizarLista()
        {

            ListMateriasFiltrada = await _memoryCache.GetAllCacheAsync<Materia>();

            BindingMaterias.DataSource = ListMateriasFiltrada;
            CargarDatosEnGrilla();
        }
        private async void CargarCboCarreras()
        {
            cboCarreras.DataSource = BindingCarreras;
            cboCarreras.DisplayMember = "Nombre";
            cboCarreras.ValueMember = "Id";
            CargarCboAnioCarreras();
        }

        private void CargarCboAnioCarreras()
        {
            if (cboCarreras.SelectedValue is int carreraId)
            {
                cboAniosCarreras.DataSource = BindingAniosCarrera;
                BindingAniosCarrera.DataSource = ListAniosCarreraFiltrada.Where(a => a.CarreraId.Equals(carreraId)).ToList();
                cboAniosCarreras.DisplayMember = "Nombre";
                cboAniosCarreras.ValueMember = "Id";
                CargarDatosEnGrilla();
            }
        }


        private async Task CargarDatosEnGrilla()
        {
            if (cboCarreras.SelectedValue is int carreraId && cboAniosCarreras.SelectedValue is int anioCarreraId)
            {
                dataGridMaterias.DataSource = BindingMaterias;
                BindingMaterias.DataSource = ListMateriasFiltrada.Where(a => a.AnioCarreraId.Equals(anioCarreraId)).ToList();
                dataGridMaterias.OcultarColumnas(new string[] { "AnioCarreraId", "AnioCarrera", "Eliminado" });
                dataGridMaterias.EstablecerAnchoDeColumnas(new int[] { 100, 350 });
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Obtener la carrera y el año seleccionados
            var carrera = (Carrera)BindingCarreras.Current;
            var anioCarrera = (AnioCarrera)BindingAniosCarrera.Current;

            // Crear el formulario para agregar una nueva materia
            NuevoEditarMateriaView nuevoEditarMateriaView = ActivatorUtilities.CreateInstance<NuevoEditarMateriaView>(_serviceProvider, carrera, anioCarrera);

            // Mostrar el formulario como diálogo
            nuevoEditarMateriaView.ShowDialog();

            // Si se agregó la materia, actualizar la grilla
            ActualizarLista();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var materia = (Materia)BindingMaterias.Current;
            var aniocarrera = (AnioCarrera)BindingAniosCarrera.Current;
            NuevoEditarMateriaView nuevoEditarMateriaView = ActivatorUtilities.CreateInstance<NuevoEditarMateriaView>(_serviceProvider, materia, aniocarrera);
            nuevoEditarMateriaView.ShowDialog();
            ActualizarLista();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            var materia = (Materia)BindingMaterias.Current;
            var respuesta = MessageBox.Show($"¿Está seguro que quiere borrar la materia {materia.Nombre}", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                //await materiaService.DeleteAsync(materia.Id);
                await _memoryCache.DeleteCacheAsync<Materia>(materia.Id);
                ActualizarLista();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboCarreras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCarreras.SelectedValue != null && cboCarreras.SelectedValue.GetType() == typeof(int))
            {
                CargarCboAnioCarreras();
            }
        }

        private void cboAniosCarreras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAniosCarreras.SelectedValue != null && cboAniosCarreras.SelectedValue.GetType() == typeof(int))
            {
                CargarDatosEnGrilla();
            }
        }
    }
}
