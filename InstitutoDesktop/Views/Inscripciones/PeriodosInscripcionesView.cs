using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Services;
using InstitutoDesktop.States.Inscripciones.PeriodosInscripciones;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Horarios;
using InstitutoServices.Models.Inscripciones;

namespace InstitutoDesktop.Views.Inscripciones
{
    public partial class PeriodosInscripcionesView : Form
    {
        public IPeriodosInscripcionesViewState _currentState;

        public List<PeriodoInscripcion>? listaPeriodosInscripciones = new List<PeriodoInscripcion>();
        public PeriodoInscripcion periodoInscripcionCurrent;

        public readonly MemoryCacheServiceWinForms _memoryCache;

        public PeriodosInscripcionesView(MemoryCacheServiceWinForms memoryCacheService, MenuPrincipalView menuPrincipal)
        {
            InitializeComponent();
            this.MdiParent = menuPrincipal;
            _memoryCache = memoryCacheService;
            // Iniciar en estado de listado
            TransitionTo(new InitialDisplayState(this));
            _ = _currentState.LoadData();
            this.WindowState = FormWindowState.Maximized;
        }

        public void TransitionTo(IPeriodosInscripcionesViewState state)
        {
            _currentState = state;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            TransitionTo(new ActionsState(this));
            _currentState.OnAgregar();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            _currentState.OnGuardar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            TransitionTo(new ActionsState(this));
            _currentState.OnModificar();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            TransitionTo(new ActionsState(this));
            _currentState.OnEliminar();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _currentState.OnCancelar();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            _currentState.OnBuscar();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            BtnBuscar.PerformClick();
        }

        private void iconButtonSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkVisualizarMateriasAnualesY1erCuatrimestre_CheckedChanged(object sender, EventArgs e)
        {
            this.checkMaterias2doCuatrimestre.Checked = !checkVisualizarMateriasAnualesY1erCuatrimestre.Checked;
        }

        private void checkMaterias2doCuatrimestre_CheckedChanged(object sender, EventArgs e)
        {
            this.checkVisualizarMateriasAnualesY1erCuatrimestre.Checked=!this.checkMaterias2doCuatrimestre.Checked;
        }
    }
}
