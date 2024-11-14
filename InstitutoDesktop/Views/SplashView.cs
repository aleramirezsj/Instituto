using InstitutoDesktop.Services;
using InstitutoDesktop.ViewReports;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Horarios;
using InstitutoServices.Models.Inscripciones;
using InstitutoServices.Models.MesasExamenes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstitutoDesktop.Views
{
    public partial class SplashView : Form
    {
        bool dataReady = false;
        bool printReady = false;

        private readonly MemoryCacheServiceWinForms _cacheService;
        private readonly IServiceProvider _serviceProvider;

        public SplashView(MemoryCacheServiceWinForms memoryCacheService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _cacheService = memoryCacheService;
            _serviceProvider = serviceProvider;
        }




        private async Task ImprimirReporte()
        {
            await Task.Run(() =>
            {

                ReportViewer reporte = new ReportViewer();
                reporte.LocalReport.ReportEmbeddedResource = "InstitutoDesktop.Reports.DocentesReport.rdlc";
                var docentes = new List<Docente>(){ new Docente() { Id=1, Nombre="Juan Perez"}};
                reporte.LocalReport.DataSources.Add(new ReportDataSource("DSDocentes", docentes));
                reporte.SetDisplayMode(DisplayMode.PrintLayout);
                reporte.RefreshReport();
                printReady = true;

            });

        }

        private async Task DescargarListas()
        {
            await Task.WhenAll(new List<Task>
            {
                Task.Run(async () => await _cacheService.GetAllCacheAsync<Alumno>()),
                Task.Run(async () => await _cacheService.GetAllCacheAsync <AnioCarrera>()),
                Task.Run(async () => await _cacheService.GetAllCacheAsync <Aula>()),
                Task.Run(async () => await _cacheService.GetAllCacheAsync <Carrera>()),
                Task.Run(async () => await _cacheService.GetAllCacheAsync <CicloLectivo>()),
                Task.Run(async () => await _cacheService.GetAllCacheAsync <Docente>()),
                Task.Run(async () => await _cacheService.GetAllCacheAsync<Hora>()),
                Task.Run(async () => await _cacheService.GetAllCacheAsync<Horario>()),
                Task.Run(async () => await _cacheService.GetAllCacheAsync<IntegranteHorario>()),
                Task.Run(async () => await _cacheService.GetAllCacheAsync<JefaturaSeccion>()),
                Task.Run(async () => await _cacheService.GetAllCacheAsync<Materia>()),
                Task.Run(async () => await _cacheService.GetAllCacheAsync<TurnoExamen>()),
                Task.Run(async () => await _cacheService.GetAllCacheAsync<Inscripcion>()),
                Task.Run(async () => await _cacheService.GetAllCacheAsync<DetalleInscripcion>()),
                Task.Run(async () => await _cacheService.GetAllCacheAsync<MesaExamen>()),
                Task.Run(async () => await _cacheService.GetAllCacheAsync<DetalleMesaExamen>()),
                Task.Run(async () => await _cacheService.GetAllCacheAsync<InscripcionExamen>()),
                Task.Run(async () => await _cacheService.GetAllCacheAsync<DetalleInscripcionExamen>()),
                Task.Run(async () => await _cacheService.GetAllCacheAsync<PeriodoHorario>()),
                Task.Run(async () => await _cacheService.GetAllCacheAsync<PeriodoInscripcion>()),
            });
            dataReady = true;
        }

        private async void SplashView_Activated_1(object sender, EventArgs e)
        {
            var conectarDbTask = DescargarListas();
            var imprimirReporteTask = ImprimirReporte();
            await Task.WhenAll(conectarDbTask, imprimirReporteTask);
        }

        private void timer_Tick_1(object sender, EventArgs e)
        {
            if (progressBar.Value < 97)
                progressBar.Value += 3;
            if (dataReady && printReady)
            {
                timer.Enabled = false;
                this.Visible = false;
                var frmMenuPrincipal = ActivatorUtilities.CreateInstance<MenuPrincipalView>(_serviceProvider); ;
                frmMenuPrincipal.ShowDialog();
                this.Close();
            }
        }
    }
}
