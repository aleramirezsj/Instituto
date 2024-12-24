using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Services;
using InstitutoDesktop.States.Commons.Aulas;
using InstitutoServices.Models.Commons;

namespace InstitutoDesktop.Views.Commons
{
    public partial class AulasView : Form
    {
        private ICrudViewState _currentState;

        public List<Aula>? listaAulas = new List<Aula>();
        public Aula aulaCurrent;

        public readonly MemoryCacheServiceWinForms _memoryCache;

        public AulasView(MemoryCacheServiceWinForms memoryCacheService, MenuPrincipalView menuPrincipal)
        {
            InitializeComponent();
            this.MdiParent = menuPrincipal;
            this.WindowState = FormWindowState.Maximized;
            _memoryCache = memoryCacheService;
            // Iniciar en estado de listado
            TransitionTo(new DisplayGridState(this));
            _ = _currentState.LoadData();
            this.WindowState = FormWindowState.Maximized;

        }

        public void TransitionTo(ICrudViewState state) 
        {
            _currentState = state;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            _currentState.OnAgregar();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
           _currentState.OnGuardar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            _currentState.OnModificar();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
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

        private void Grilla_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            btnModificar.Enabled = Grilla.Rows.Count > 0;
            btnEliminar.Enabled = Grilla.Rows.Count > 0;
        }
    }
}
