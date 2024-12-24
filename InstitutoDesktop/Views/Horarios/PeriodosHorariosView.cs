using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Services;
using InstitutoDesktop.States.Horarios.PeriodosHorarios;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Horarios;

namespace InstitutoDesktop.Views.Horarios
{
    public partial class PeriodosHorariosView : Form
    {
        public IPeriodosHorariosViewState _currentState;

        public List<PeriodoHorario>? listaPeriodosHorarios = new List<PeriodoHorario>();
        public PeriodoHorario periodoHorarioCurrent;

        public readonly MemoryCacheServiceWinForms _memoryCache;

        public PeriodosHorariosView(MemoryCacheServiceWinForms memoryCacheService, MenuPrincipalView menuPrincipal)
        {
            InitializeComponent();
            this.MdiParent = menuPrincipal;
            _memoryCache = memoryCacheService;
            // Iniciar en estado de listado
            TransitionTo(new InitialDisplayState(this));
            _ = _currentState.LoadData();
            this.WindowState = FormWindowState.Maximized;
        }

        public void TransitionTo(IPeriodosHorariosViewState state)
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




    }
}
