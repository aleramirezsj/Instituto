using InstitutoDesktop.Interfaces.Inscripciones;
using InstitutoDesktop.Services;
using InstitutoDesktop.States.Inscripciones.InscripcionesMaterias;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Inscripciones;

namespace InstitutoDesktop.Views
{
    public partial class InscripcionesMateriasView : Form
    {
        public List<PeriodoInscripcion>? listaPeriodosInscripciones = new List<PeriodoInscripcion>();
        public List<Carrera>? listaCarreras = new List<Carrera>();
        public List<AnioCarrera>? listaAnioCarreras = new List<AnioCarrera>();
        public List<Materia>? listaMaterias = new List<Materia>();
        public List<Inscripcion>? listaInscripciones = new List<Inscripcion>();
        public List<Inscripcion>? listaInscripcionesFiltrada = new List<Inscripcion>();

        public List<DetalleInscripcion>? listaDetallesInscripciones = new List<DetalleInscripcion>();


        public readonly MemoryCacheServiceWinForms _memoryCache;

        public IInscripcionesMateriasViewState _currentState;

        public InscripcionesMateriasView(MemoryCacheServiceWinForms memoryCacheService, MenuPrincipalView menuPrincipal)
        {
            InitializeComponent();
            _memoryCache = memoryCacheService;
            this.MdiParent = menuPrincipal;
            this.WindowState = FormWindowState.Maximized;
            TransitionTo(new InitialDisplayState(this));
            _ = _currentState.LoadData();
            this.WindowState = FormWindowState.Maximized;
        }

        public void TransitionTo(IInscripcionesMateriasViewState state) => _currentState = state;
        private void BtnBuscar_Click(object sender, EventArgs e) => _currentState.OnBuscar();
        private void txtFiltro_TextChanged(object sender, EventArgs e) => BtnBuscar.PerformClick();

        private void btnSalir_Click(object sender, EventArgs e) => this.Close();

        private void btnImprimirTodas_Click(object sender, EventArgs e) => _currentState.OnImprimirTodasPorAlumno();
        private void btnImprimirSeleccionada_Click_1(object sender, EventArgs e) => _currentState.OnImprimirSeleccionadaPorAlumno();

        private void btnImprimirTodasMaterias_Click(object sender, EventArgs e) => _currentState.OnImprimirTodasPorMateria();

        private void btnImprimirMateriaSeleccionada_Click(object sender, EventArgs e) => _currentState.OnImprimirSeleccionadaPorMateria();

        private void txtFiltroPorMateria_TextChanged(object sender, EventArgs e) => btnBuscarMateria.PerformClick();

        private void btnBuscarMateria_Click(object sender, EventArgs e) => _currentState.OnBuscar();
    }
}
