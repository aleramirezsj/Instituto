using InstitutoDesktop.Services;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.MesasExamenes;
using Microsoft.Reporting.WinForms;

namespace InstitutoDesktop.ViewReports
{
    public partial class InscripcionExamenMateriaViewReport : Form
    {
        ReportViewer reporte;
        private List<DetalleInscripcionExamen> _detalleInscripcionExamenes;
        public InscripcionExamenMateriaViewReport(MenuPrincipalView menuPrincipalView, List<DetalleInscripcionExamen> detalleInscripcionExamenes)
        {
            InitializeComponent();
            _detalleInscripcionExamenes = detalleInscripcionExamenes;
            this.MdiParent = menuPrincipalView;
            this.WindowState = FormWindowState.Maximized;
            reporte = new ReportViewer();

            reporte.Dock = DockStyle.Fill;

            Controls.Add(reporte);
        }

        private async void InscripcionExamenViewReport_Load(object sender, EventArgs e)
        {
            reporte.LocalReport.ReportEmbeddedResource = "InstitutoDesktop.Reports.InscripcionExamenMateriaReport.rdlc";
            //extraigo de _detallesInscripcionesExamenes los datos que necesito para el reporte, Alumno, Carrera, Turno, FechaInscripcion, AnioCarrera, Materia, usando el select
            var inscripcionesExamenes = _detalleInscripcionExamenes.Select(x => new
            {
                Alumno = x.InscripcionExamen?.Alumno?.ApellidoNombre.ToString(),
                Carrera = x.InscripcionExamen?.Carrera?.Nombre.ToString(),
                TurnoExamen = x.InscripcionExamen?.TurnoExamen?.Nombre.ToString(),
                FechaInscripcion = x.InscripcionExamen?.Fecha,
                AnioCarrera = x.Materia?.AnioCarrera?.Nombre.ToString(),
                Materia = x.Materia?.Nombre.ToString()
            }).OrderBy(x=>x.Materia).ThenBy(x=>x.Alumno).ToList();
            reporte.LocalReport.DataSources.Add(new ReportDataSource("DSInscripcionExamen", inscripcionesExamenes));
            reporte.SetDisplayMode(DisplayMode.PrintLayout);
            reporte.RefreshReport();
        }
    }
}
