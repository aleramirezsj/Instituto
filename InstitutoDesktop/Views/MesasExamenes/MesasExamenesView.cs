using InstitutoDesktop.Interfaces.MesasExamenes;
using InstitutoDesktop.Services;
using InstitutoDesktop.States.MesasExamenes.MesasExamenes;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.MesasExamenes;

namespace InstitutoDesktop.Views
{
    public partial class MesasExamenesView : Form
    {
        public List<TurnoExamen>? listaTurnosExamenes = new List<TurnoExamen>();
        public List<Carrera>? listaCarreras = new List<Carrera>();
        public List<AnioCarrera>? listaAnioCarreras = new List<AnioCarrera>();
        public List<Materia>? listaMaterias = new List<Materia>();
        public List<Docente>? listaDocentes = new List<Docente>();
        public List<MesaExamen>? listaMesasExamenes = new List<MesaExamen>();
        public MesaExamen mesaExamenCurrent;
        public DetalleMesaExamen detalleMesaExamenEdit;

        public readonly MemoryCacheServiceWinForms _memoryCache;

        public IMesasExamenesViewState _currentState;

        public MesasExamenesView(MemoryCacheServiceWinForms memoryCacheService, MenuPrincipalView menuPrincipal)
        {
            InitializeComponent();
            _memoryCache = memoryCacheService;
            this.MdiParent = menuPrincipal;
            this.WindowState = FormWindowState.Maximized;
            TransitionTo(new InitialDisplayState(this));
            _ = _currentState.LoadData();
        }

        public void TransitionTo(IMesasExamenesViewState state) => _currentState = state;
        private void btnAgregar_Click(object sender, EventArgs e) => _currentState.OnAgregar();
        private void btnGuardar_Click(object sender, EventArgs e) => _currentState.OnGuardar();
        private void btnModificar_Click(object sender, EventArgs e) => _currentState.OnModificar();
        private void btnEliminar_Click(object sender, EventArgs e) => _currentState.OnEliminar();
        private void btnCancelar_Click(object sender, EventArgs e) => _currentState.OnCancelar();
        private void BtnBuscar_Click(object sender, EventArgs e) => _currentState.OnBuscar();
        private void txtFiltro_TextChanged(object sender, EventArgs e) => BtnBuscar.PerformClick();
        private void btnSalir_Click(object sender, EventArgs e) => this.Close();
        private void btnAgregarDocenteADetalle_Click(object sender, EventArgs e) => _currentState.OnAgregarDocenteADetalle();
        private void BtnEditarDocenteDeDetalle_Click(object sender, EventArgs e) => _currentState.OnEditarDocenteDeDetalle();
        private void btnQuitarDocenteDeDetalle_Click(object sender, EventArgs e) => _currentState.OnQuitarDocenteDeDetalle();
    }
}
