using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Interfaces.Views;
using InstitutoDesktop.Services;
using InstitutoDesktop.States.Horarios.Horas;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Horarios;

namespace InstitutoDesktop.Views.Horarios
{
    public partial class HorasView : Form
    {
        public ICrudViewState _currentState { get; set; }

        public List<Hora>? listaHoras { get; set; } = new List<Hora>();
        public Hora horaCurrent { get; set; }

        public MemoryCacheServiceWinForms _memoryCache { get; set; }

        

        public HorasView(MemoryCacheServiceWinForms memoryCacheService, MenuPrincipalView menuPrincipal)
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
