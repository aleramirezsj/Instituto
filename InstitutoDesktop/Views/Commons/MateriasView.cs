using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Services;
using InstitutoDesktop.States.Commons.Materias;
using InstitutoServices.Models.Commons;
using System.Diagnostics;

namespace InstitutoDesktop.Views.Commons
{
    public partial class MateriasView : Form
    {
        private IMateriasViewState _currentState;

        public List<Materia>? listaMaterias = new List<Materia>();
        public Materia materiaCurrent;

        public readonly MemoryCacheServiceWinForms _memoryCache;

        public MateriasView(MemoryCacheServiceWinForms memoryCacheService, MenuPrincipalView menuPrincipal)
        {
            InitializeComponent();
            Debug.Print("Se instancio MateriasView");
            this.MdiParent = menuPrincipal;
            _memoryCache = memoryCacheService;
            // Iniciar en estado de listado
            TransitionTo(new DisplayGridState(this));
            _ = _currentState.LoadData();
            this.WindowState = FormWindowState.Maximized;
        }

        public void TransitionTo(IMateriasViewState state)
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
            this.Dispose();
            this.Close();
        }

        private void Grilla_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            btnModificar.Enabled = Grilla.Rows.Count > 0;
            btnEliminar.Enabled = Grilla.Rows.Count > 0;
        }

        private void comboBoxCarreras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCarreras.SelectedValue != null && comboBoxCarreras.SelectedValue.GetType() == typeof(int))
            {
                _currentState.LoadComboboxAniosCarreras();
                _currentState.UpdateUI();
            }
        }

        private void comboBoxAñosCarreras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAñosCarreras.SelectedValue != null && comboBoxAñosCarreras.SelectedValue.GetType() == typeof(int))
            {
                _currentState.UpdateUI();
            }
        }
    }
}
