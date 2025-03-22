using InstitutoDesktop.Services;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Inscripciones;
using InstitutoServices.Models.MesasExamenes;
using Microsoft.Reporting.WinForms;

namespace InstitutoDesktop.ViewReports
{
    public partial class InscripcionPorMateriasViewReport : Form
    {
        ReportViewer reporte;
        private List<DetalleInscripcion> _detalleInscripcion;
        public InscripcionPorMateriasViewReport(MenuPrincipalView menuPrincipalView, List<DetalleInscripcion> detalleInscripcion)
        {
            InitializeComponent();
            _detalleInscripcion = detalleInscripcion;
            this.MdiParent = menuPrincipalView;
            this.WindowState = FormWindowState.Maximized;
            reporte = new ReportViewer();

            reporte.Dock = DockStyle.Fill;

            Controls.Add(reporte);
        }

        private async void InscripcionExamenViewReport_Load(object sender, EventArgs e)
        {
            reporte.LocalReport.ReportEmbeddedResource = "InstitutoDesktop.Reports.InscripcionPorMateriaReport.rdlc";
            //extraigo de _detallesInscripcionesExamenes los datos que necesito para el reporte, Alumno, Carrera, Turno, FechaInscripcion, AnioCarrera, Materia, usando el select
            var inscripciones = _detalleInscripcion.Select(x => new
            {
                Alumno = x.Inscripcion?.Alumno?.ApellidoNombre.ToString(),
                Carrera = x.Inscripcion?.Carrera?.Nombre.ToString(),
                PeriodoInscripcion = x.Inscripcion?.PeriodoInscripcion?.Nombre.ToString(),
                FechaInscripcion = x.Inscripcion?.Fecha,
                AnioCarrera = x.Materia?.AnioCarrera?.Nombre.ToString(),
                Materia = x.Materia?.Nombre.ToString(),
                ModalidadCursado = x.ModalidadCursado.ToString()
            }).OrderBy(x=>x.Materia).ThenBy(x=>x.Alumno).ToList();
            reporte.LocalReport.DataSources.Add(new ReportDataSource("DSInscripcionMaterias", inscripciones));
            reporte.SetDisplayMode(DisplayMode.PrintLayout);
            reporte.RefreshReport();
        }
    }
}
