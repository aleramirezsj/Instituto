using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Interfaces.MesasExamenes;
using InstitutoDesktop.Services;
using InstitutoDesktop.States.Commons.Usuarios;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Horarios;
using InstitutoServices.Models.Inscripciones;
using InstitutoServices.Models.MesasExamenes;

namespace InstitutoDesktop.Views.Commons
{
    public partial class UsuariosView : Form
    {
        public IUsuariosViewState _currentState;

        public List<Usuario>? listaUsuarios = new List<Usuario>();
        public Usuario usuarioCurrent;

        public readonly MemoryCacheServiceWinForms _memoryCache;

        public UsuariosView(MemoryCacheServiceWinForms memoryCacheService, MenuPrincipalView menuPrincipal)
        {
            InitializeComponent();
            this.MdiParent = menuPrincipal;
            _memoryCache = memoryCacheService;
            // Iniciar en estado de listado
            TransitionTo(new InitialDisplayState(this));
            _ = _currentState.LoadData();
            this.WindowState = FormWindowState.Maximized;
        }

        public void TransitionTo(IUsuariosViewState state)
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




    }
}
