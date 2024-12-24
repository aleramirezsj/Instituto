using InstitutoDesktop.ExtensionMethods;
using InstitutoDesktop.Interfaces.Horarios;
using InstitutoDesktop.Interfaces.MesasExamenes;
using InstitutoDesktop.Services;
using InstitutoDesktop.States.Horarios.Horarios;
using InstitutoDesktop.Util;
using InstitutoServices.Enums;
using InstitutoServices.Interfaces;
using InstitutoServices.Interfaces.Commons;
using InstitutoServices.Interfaces.Horarios;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Horarios;
using InstitutoServices.Models.Inscripciones;
using InstitutoServices.Services.Commons;
using InstitutoServices.Services.Horarios;
using System.Data;
using System.Diagnostics;

namespace InstitutoDesktop.Views
{
    public partial class HorariosView : Form
    {
        public List<PeriodoHorario>? listaPeriodosHorarios = new List<PeriodoHorario>();
        public List<Carrera>? listaCarreras = new List<Carrera>();
        public List<AnioCarrera>? listaAnioCarreras = new List<AnioCarrera>();
        public List<Materia>? listaMaterias = new List<Materia>();
        public List<Docente>? listaDocentes = new List<Docente>();
        public List<Hora>? listaHoras = new List<Hora>();
        public List<Horario>? listaHorarios = new List<Horario>();
        public List<Aula>? listaAulas = new List<Aula>();
        public Horario horarioCurrent;
        public DetalleHorario detalleHorarioEdit;

        public readonly MemoryCacheServiceWinForms _memoryCache;

        public IHorariosViewState _currentState;

        public HorariosView(MemoryCacheServiceWinForms memoryCacheService, MenuPrincipalView menuPrincipal)
        {
            InitializeComponent();
            this.MdiParent = menuPrincipal;
            this.WindowState = FormWindowState.Maximized;
            _memoryCache = memoryCacheService;
            TransitionTo(new InitialDisplayState(this));
            _ = _currentState.LoadData();
            this.WindowState = FormWindowState.Maximized;
        }
        public void TransitionTo(IHorariosViewState state) => _currentState = state;

        private void btnAgregar_Click(object sender, EventArgs e) => _currentState.OnAgregar();
        private void btnModificar_Click(object sender, EventArgs e) => _currentState.OnModificar();
        private void btnEliminar_Click(object sender, EventArgs e) => _currentState.OnEliminar();
        private void btnSalir_Click(object sender, EventArgs e) => this.Close();
        private void BtnBuscar_Click(object sender, EventArgs e) => _currentState.OnBuscar();
        private void txtFiltro_TextChanged(object sender, EventArgs e) => BtnBuscar.PerformClick();
        private void btnAgregarDocente_Click(object sender, EventArgs e) => _currentState.OnAgregarDocenteAIntegrantes();
        private void btnQuitarDocente_Click(object sender, EventArgs e) => _currentState.OnQuitarDocenteDeIntegrantes();
        private void btnAgregarHora_Click(object sender, EventArgs e) => _currentState.OnAgregarHoraADetalle();
        private void btnEditarHora_Click(object sender, EventArgs e) => _currentState.OnEditarHoraDeDetalle();
        private void btnQuitarHora_Click(object sender, EventArgs e) => _currentState.OnQuitarHoraDeDetalle();
        private void btnGuardar_Click(object sender, EventArgs e) => _currentState.OnGuardar();
        private void btnCancelar_Click(object sender, EventArgs e) => _currentState.OnCancelar();
    }
}
