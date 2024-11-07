using InstitutoDesktop.Views;
using InstitutoDesktop.Views.Inscripciones;
using InstitutoDesktop.Views.Horarios;
using InstitutoDesktop.Views.MesasExamenes;

using InstitutoDesktop.Views.Commons.Alumnos;

using InstitutoDesktop.Views.Commons;
using InstitutoDesktop.Views.Commons.Materias;
using InstitutoDesktop.Services;
using InstitutoServices.Services.Commons;
using Microsoft.Extensions.Caching.Memory;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Inscripciones;
using InstitutoServices.Models.Horarios;
using InstitutoServices.Models.MesasExamenes;
using Microsoft.Extensions.DependencyInjection;
using InstitutoDesktop.ViewReports;
using InstitutoDesktop.Views.Inscripciones.PeriodosInscripciones;





namespace InstitutoDesktop
{
    public partial class MenuPrincipalView : Form
    {
        bool logueado = false;
        private readonly MemoryCacheServiceWinForms _cacheService;
        private readonly IServiceProvider _serviceProvider;


        public MenuPrincipalView(MemoryCacheServiceWinForms memoryCacheService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _cacheService = memoryCacheService;
            GetCacheData();
            _serviceProvider = serviceProvider;
        }

        private void GetCacheData()
        {
            Task.WhenAll(new List<Task>
            {
                Task.Run(async () => _cacheService.GetAllCacheAsync<Alumno>()),
                Task.Run(async () => _cacheService.GetAllCacheAsync<AnioCarrera>()),
                Task.Run(async () =>_cacheService.GetAllCacheAsync<Aula>()),
                Task.Run(async () =>_cacheService.GetAllCacheAsync<Carrera>()),
                Task.Run(async () =>_cacheService.GetAllCacheAsync<CicloLectivo>()),
                Task.Run(async () =>_cacheService.GetAllCacheAsync<Docente>()),
                Task.Run(async () =>_cacheService.GetAllCacheAsync<Hora>()),
                Task.Run(async () =>_cacheService.GetAllCacheAsync<Horario>()),
                Task.Run(async () =>_cacheService.GetAllCacheAsync<IntegranteHorario>()),
                Task.Run(async () =>_cacheService.GetAllCacheAsync<JefaturaSeccion>()),
                Task.Run(async () =>_cacheService.GetAllCacheAsync<Materia>()),
                Task.Run(async () =>_cacheService.GetAllCacheAsync<TurnoExamen>()),
                Task.Run(async () =>_cacheService.GetAllCacheAsync<Inscripcion>()),
                Task.Run(async () =>_cacheService.GetAllCacheAsync<DetalleInscripcion>()),
                Task.Run(async () =>_cacheService.GetAllCacheAsync<MesaExamen>()),
                Task.Run(async () =>_cacheService.GetAllCacheAsync<DetalleMesaExamen>()),
                Task.Run(async () =>_cacheService.GetAllCacheAsync<InscripcionExamen>()),
                Task.Run(async () =>_cacheService.GetAllCacheAsync<DetalleInscripcionExamen>()),
                Task.Run(async () =>_cacheService.GetAllCacheAsync<PeriodoHorario>()),
                Task.Run(async () =>_cacheService.GetAllCacheAsync<PeriodoInscripcion>()),

            });


        }



        private void iconMenuItem4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }









        private void turnoExamenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TurnoExamenesView turnoexamenesview = ActivatorUtilities.CreateInstance<TurnoExamenesView>(_serviceProvider);
            turnoexamenesview.ShowDialog();
        }



        private void iconMenuItem9_Click(object sender, EventArgs e)
        {

        }



        private void MenuPrincipalView_Activated(object sender, EventArgs e)
        {
            //if (!logueado)
            //{
            //    IniciarSesionView iniciarSesionView = new IniciarSesionView();
            //    iniciarSesionView.ShowDialog();
            //    if (!iniciarSesionView.loginSuccessfull)
            //    {
            //        Application.Exit();
            //    }
            //    else
            //    {
            //        logueado = true;
            //    }
            //}

        }








        private void mnuDocentes_Click(object sender, EventArgs e)
        {
            DocentesViewReport docentesViewReport = ActivatorUtilities.CreateInstance<DocentesViewReport>(_serviceProvider);
            docentesViewReport.ShowDialog();
        }
        private void iconMenuItem11_Click(object sender, EventArgs e)
        {
            MesasExamenesView mesasExamenesView = ActivatorUtilities.CreateInstance<MesasExamenesView>(_serviceProvider);
            mesasExamenesView.ShowDialog();
        }

        private void subMenuCiclosLectivos_Click(object sender, EventArgs e)
        {
            CiclosLectivosView ciclosLectivosView = ActivatorUtilities.CreateInstance<CiclosLectivosView>(_serviceProvider,this );
            ciclosLectivosView.Show();
        }

        private void subMenuAulas_Click(object sender, EventArgs e)
        {
            AulasView aulasView = ActivatorUtilities.CreateInstance<AulasView>(_serviceProvider);
            aulasView.Show();
        }

        private void subMenuAlumnos_Click(object sender, EventArgs e)
        {
            AlumnosView alumnosView = ActivatorUtilities.CreateInstance<AlumnosView>(_serviceProvider);
            alumnosView.ShowDialog();
        }

        private void subMenuDocentes_Click(object sender, EventArgs e)
        {
            DocentesView docentesView = ActivatorUtilities.CreateInstance<DocentesView>(_serviceProvider);
            docentesView.Show();
        }

        private void subMenuCarreras_Click(object sender, EventArgs e)
        {
            CarrerasView carrerasView = ActivatorUtilities.CreateInstance<CarrerasView>(_serviceProvider);
            carrerasView.ShowDialog();
        }

        private void subMenuAñosCarreras_Click(object sender, EventArgs e)
        {
            AniosCarrerasView aniosCarreraView = ActivatorUtilities.CreateInstance<AniosCarrerasView>(_serviceProvider);
            aniosCarreraView.Show();
        }

        private void subMenuMaterias_Click(object sender, EventArgs e)
        {
            MateriaView materiaView = ActivatorUtilities.CreateInstance<MateriaView>(_serviceProvider);
            materiaView.ShowDialog();
        }

        private void subMenuHoras_Click(object sender, EventArgs e)
        {
            HorasView horasView = ActivatorUtilities.CreateInstance<HorasView>(_serviceProvider);
            horasView.ShowDialog();
        }

        private void subMenuPeriodosHorarios_Click(object sender, EventArgs e)
        {
            PeriodoHorarioView periodoHorarioView = ActivatorUtilities.CreateInstance<PeriodoHorarioView>(_serviceProvider);
            periodoHorarioView.ShowDialog();
        }

        private void subMenuHorarios_Click(object sender, EventArgs e)
        {
            HorariosView horariosView = ActivatorUtilities.CreateInstance<HorariosView>(_serviceProvider,this);
            horariosView.Show();
        }

        private void subMenuTurnosExámenes_Click(object sender, EventArgs e)
        {
            TurnoExamenesView turnoExamenesView = ActivatorUtilities.CreateInstance<TurnoExamenesView>(_serviceProvider);
            turnoExamenesView.ShowDialog();
        }

        private void subMenuPeriodosInscripciones_Click(object sender, EventArgs e)
        {
            PeriodoInscripcionView periodoInscripcionView = ActivatorUtilities.CreateInstance<PeriodoInscripcionView>(_serviceProvider);
            periodoInscripcionView.ShowDialog();
        }

        private void subMenuConformacionMesasExamenes_Click(object sender, EventArgs e)
        {
            MesasExamenesView mesasExamenesView = ActivatorUtilities.CreateInstance<MesasExamenesView>(_serviceProvider);
            mesasExamenesView.ShowDialog();
        }
    }
}
