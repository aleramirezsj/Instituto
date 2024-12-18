using InstitutoDesktop.Services;
using InstitutoServices.Models.Commons;
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

namespace InstitutoDesktop.ViewReports
{
    public partial class DocentesViewReport : Form
    {
        ReportViewer reporte = new();
        BindingSource BindingDocente = new BindingSource();
        List<Docente> listDoce = new List<Docente>();
        private readonly MemoryCacheServiceWinForms _memoryCache;
        private readonly IServiceProvider _serviceProvider;
        public DocentesViewReport(MemoryCacheServiceWinForms cacheServiceWinForms, MenuPrincipalView menuPrincipalView)
        {
            InitializeComponent();
            _memoryCache = cacheServiceWinForms;
            this.MdiParent= menuPrincipalView;
            this.WindowState = FormWindowState.Maximized;
            //reporte = new ReportViewer();

            reporte.Dock = DockStyle.Fill;

            Controls.Add(reporte);
        }

        private async void DocentesViewReport_Load(object sender, EventArgs e)
        {
            reporte.LocalReport.ReportEmbeddedResource = "InstitutoDesktop.Reports.DocentesReport.rdlc";
            var docentes = await _memoryCache.GetAllCacheAsync<Docente>();
            reporte.LocalReport.DataSources.Add(new ReportDataSource("DSDocentes", docentes));
            reporte.SetDisplayMode(DisplayMode.PrintLayout);
            reporte.RefreshReport();
        }
    }
}
