using InstitutoDesktop.ExtensionMethods;
using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Util;
using InstitutoDesktop.Views.Horarios;
using InstitutoServices.Models.Horarios;
using InstitutoServices.Models.Inscripciones;

namespace InstitutoDesktop.States.Horarios.PeriodosHorarios
{
    public class InitialDisplayState : IPeriodosHorariosViewState
    {
        private readonly PeriodosHorariosView _form;

        public InitialDisplayState(PeriodosHorariosView form)
        {
            _form = form;
            UpdateUI();
            _form.Grilla.DataBindingComplete += (sender, e) => EnableDisableButtons();
        }

        private void EnableDisableButtons()
        {
            _form.btnModificar.Enabled = _form.Grilla.Rows.Count > 0;
            _form.btnEliminar.Enabled = _form.Grilla.Rows.Count > 0;
        }



        public async Task LoadData()
        {
            ShowInActivity.Show("Cargando períodos de horarios...");
            _form.listaPeriodosHorarios = await _form._memoryCache.GetAllCacheAsync<PeriodoHorario>();
            ShowInActivity.Hide();
            await LoadComboboxCiclosLectivos();
            await LoadGrid();
        }

        public async Task LoadGrid()
        {
            if (_form.listaPeriodosHorarios != null && _form.listaPeriodosHorarios.Count > 0)
                _form.Grilla.DataSource = _form.listaPeriodosHorarios.OrderBy(periodo => periodo.CicloLectivoId).ToList();
            _form.Grilla.OcultarColumnas(new string[] { "Id","CicloLectivoId","Es2doCuatrimestre",  "Eliminado" });
        }

        public async Task LoadGridFilter(string filterText)
        {
            if (_form.listaPeriodosHorarios != null && _form.listaPeriodosHorarios.Count > 0)
                _form.Grilla.DataSource = _form.listaPeriodosHorarios
                    .Where(periodo => periodo.Nombre.ToUpper().Contains(filterText.ToUpper()))
                    .OrderBy(periodo => periodo.CicloLectivoId)
                    .ToList();
            _form.Grilla.OcultarColumnas(new string[] { "Id", "CicloLectivoId", "Es2doCuatrimestre", "Eliminado" });
        }


        public void OnBuscar()
        {
            if (string.IsNullOrEmpty(_form.txtFiltro.Text))
                LoadGrid();
            else
                LoadGridFilter(_form.txtFiltro.Text);
        }

        public async void UpdateUI()
        {
            
            await LoadGrid();
            _form.tabPageAgregarEditar.Enabled = false;
            _form.tabPageLista.Enabled = true;
            _form.tabControl.SelectTab(_form.tabPageLista);
        }

        // Estos métodos no aplican en este estado
        public void OnAgregar() { }
        public void OnModificar() { }
        public Task OnEliminar() => Task.CompletedTask;
        public Task OnGuardar() => Task.CompletedTask;
        public void OnCancelar() { }
        public void OnSalir() => _form.Close();

        public async Task LoadComboboxCiclosLectivos()
        {
            ShowInActivity.Show("Cargando ciclos lectivos...");
            _form.comboBoxCiclosLectivos.DataSource= await _form._memoryCache.GetAllCacheAsync<CicloLectivo>();
            ShowInActivity.Hide();
            _form.comboBoxCiclosLectivos.DisplayMember = "Nombre";
            _form.comboBoxCiclosLectivos.ValueMember = "Id";
        }


    }
}
