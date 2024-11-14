using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Interfaces.Views;
using InstitutoDesktop.Services;
using InstitutoDesktop.States.Commons.Carreras;
using InstitutoServices.Models.Commons;

namespace InstitutoDesktop.Views.Commons
{
    public partial class CarrerasView : Form
    {
        public IBaseViewState _currentState { get; set; }

        public List<Carrera>? listaCarreras { get; set; } = new List<Carrera>();
        public Carrera carreraCurrent { get; set; }

        public MemoryCacheServiceWinForms _memoryCache { get; set; }

        

        public CarrerasView(MemoryCacheServiceWinForms memoryCacheService, MenuPrincipalView menuPrincipal)
        {
            InitializeComponent();
            this.MdiParent = menuPrincipal;
            this.WindowState = FormWindowState.Maximized;
            _memoryCache = memoryCacheService;
            // Iniciar en estado de listado
            TransitionTo(new DisplayGridState(this));
            _ = _currentState.LoadData();
        }

        

        public void TransitionTo(IBaseViewState state) 
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
            btnBuscar.PerformClick();
        }

        private void btnSalir_Click(object sender, EventArgs e)
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
