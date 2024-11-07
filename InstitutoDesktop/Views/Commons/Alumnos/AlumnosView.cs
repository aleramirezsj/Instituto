using InstitutoDesktop.ExtensionMethods;
using InstitutoDesktop.Services;
using InstitutoDesktop.Util;
using InstitutoServices.Interfaces;
using InstitutoServices.Models.Commons;
using InstitutoServices.Services.Commons;
using Microsoft.Extensions.DependencyInjection;

namespace InstitutoDesktop.Views.Commons.Alumnos
{
    public partial class AlumnosView : Form
    {
        BindingSource listaAlumnos=new BindingSource();
        private readonly MemoryCacheServiceWinForms _memoryCache;
        private readonly IServiceProvider _serviceProvider;

        public AlumnosView(MemoryCacheServiceWinForms memoryCacheService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _memoryCache = memoryCacheService;
            _serviceProvider = serviceProvider;
            dataGridAlumnos.DataSource = listaAlumnos;
            CargarGrilla();
        }

        private async Task CargarGrilla()
        {
            listaAlumnos.DataSource = null;
            listaAlumnos.DataSource = await _memoryCache.GetAllCacheAsync<Alumno>();
            dataGridAlumnos.OcultarColumnas(new string[] { "Eliminado" });
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarEditarAlumnosView agregarEditarAlumnosView = ActivatorUtilities.CreateInstance<AgregarEditarAlumnosView>(_serviceProvider);
            agregarEditarAlumnosView.ShowDialog();
            CargarGrilla();
        }

        private async void iconButton2_Click(object sender, EventArgs e)
        {
            var alumno = (Alumno)listaAlumnos.Current;
            var respuesta = MessageBox.Show($"¿Está seguro que quiere borrar a el alumno {alumno.ApellidoNombre}", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                await _memoryCache.DeleteCacheAsync<Alumno>(alumno.Id);
                //await alumnoService.DeleteAsync(alumno.Id);
                await CargarGrilla();
            }
        }

        private async void iconButton1_Click(object sender, EventArgs e)
        {
            var alumno = (Alumno)listaAlumnos.Current;
            AgregarEditarAlumnosView agregarEditarAlumnosView = ActivatorUtilities.CreateInstance<AgregarEditarAlumnosView>(_serviceProvider, alumno);
            agregarEditarAlumnosView.ShowDialog();
            await CargarGrilla();
        }
    }
}
