using InstitutoDesktop.Interfaces;
using InstitutoDesktop.Services;
using InstitutoDesktop.States.Instituciones;
using InstitutoServices.Models;
using InstitutoServices.Models.Commons;
using System.Diagnostics;
using System.Windows.Forms;

namespace InstitutoDesktop.Views
{
    public partial class InstitucionView : Form
    {
        public IInstitucionViewState _currentState;

        public List<Institucion>? listaInstituciones = new List<Institucion>();
        public Institucion? institucionCurrent;

        public readonly MemoryCacheServiceWinForms _memoryCache;

        public InstitucionView(MemoryCacheServiceWinForms memoryCacheService, MenuPrincipalView menuPrincipal)
        {
            InitializeComponent();
            this.MdiParent = menuPrincipal;
            _memoryCache = memoryCacheService;
            // Iniciar en estado de listado
            TransitionTo(new InitialDisplayState(this));
            this.WindowState = FormWindowState.Maximized;
        }


        public void TransitionTo(IInstitucionViewState state)
        {
            _currentState = state;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _currentState.OnGuardar();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _currentState.OnCancelar();
        }


        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            _currentState.OnModificar();
        }

        private void iconButtonSalir_Click_1(object sender, EventArgs e)
        {
            _currentState.OnSalir();
        }
    }
}
