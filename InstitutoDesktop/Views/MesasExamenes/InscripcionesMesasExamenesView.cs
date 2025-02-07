using InstitutoDesktop.Interfaces.MesasExamenes;
using InstitutoDesktop.Services;
using InstitutoDesktop.States.MesasExamenes.InscripcionesExamenes;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.MesasExamenes;

namespace InstitutoDesktop.Views
{
    public partial class InscripcionesExamenesView : Form
    {
        public List<TurnoExamen>? listaTurnosExamenes = new List<TurnoExamen>();
        public List<Carrera>? listaCarreras = new List<Carrera>();
        public List<AnioCarrera>? listaAnioCarreras = new List<AnioCarrera>();
        public List<Materia>? listaMaterias = new List<Materia>();
        public List<InscripcionExamen>? listaInscripcionesExamenes = new List<InscripcionExamen>();
        public List<InscripcionExamen>? listaInscripcionesExamenesFiltrada = new List<InscripcionExamen>();

        public List<DetalleInscripcionExamen>? listaDetallesInscripcionesExamenes = new List<DetalleInscripcionExamen>();


        public readonly MemoryCacheServiceWinForms _memoryCache;

        public IInscripcionesExamenesViewState _currentState;

        public InscripcionesExamenesView(MemoryCacheServiceWinForms memoryCacheService, MenuPrincipalView menuPrincipal)
        {
            InitializeComponent();
            _memoryCache = memoryCacheService;
            this.MdiParent = menuPrincipal;
            this.WindowState = FormWindowState.Maximized;
            TransitionTo(new InitialDisplayState(this));
            _ = _currentState.LoadData();
            this.WindowState = FormWindowState.Maximized;
        }

        public void TransitionTo(IInscripcionesExamenesViewState state) => _currentState = state;
        private void BtnBuscar_Click(object sender, EventArgs e) => _currentState.OnBuscar();
        private void txtFiltro_TextChanged(object sender, EventArgs e) => BtnBuscar.PerformClick();
        private void btnSalir_Click(object sender, EventArgs e) => this.Close();

        private void btnImprimirTodas_Click(object sender, EventArgs e) => _currentState.OnImprimirTodasPorAlumno();
        private void btnImprimirSeleccionada_Click_1(object sender, EventArgs e) => _currentState.OnImprimirSeleccionadaPorAlumno();

        private void btnImprimirTodasMaterias_Click(object sender, EventArgs e) => _currentState.OnImprimirTodasPorMateria();

        private void btnImprimirMateriaSeleccionada_Click(object sender, EventArgs e) => _currentState.OnImprimirSeleccionadaPorMateria();
    }
}
