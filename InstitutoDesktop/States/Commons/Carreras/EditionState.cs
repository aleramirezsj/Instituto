using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Views;
using InstitutoDesktop.Views.Commons;
using InstitutoServices.Models.Commons;

namespace InstitutoDesktop.States.Commons.Carreras
{
    public class EditionState : IBaseViewState
    {
        private readonly CarrerasView _form;

        public EditionState(CarrerasView form)
        {
            _form = form;
            UpdateUI();
        }

        public async Task OnGuardar()
        {
            if (string.IsNullOrEmpty(_form.txtNombre.Text))
            {
                MessageBox.Show("Debe definirse un nombre para la carrera ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _form.carreraCurrent.Sigla = _form.txtSigla.Text;
            _form.carreraCurrent.Nombre = _form.txtNombre.Text;

            if (_form.carreraCurrent.Id == 0)
            {
                await _form._memoryCache.AddCacheAsync<Carrera>(_form.carreraCurrent);
            }
            else
            {
                await _form._memoryCache.UpdateCacheAsync<Carrera>(_form.carreraCurrent);
            }

            _form.TransitionTo(new DisplayGridState(_form));
        }

        public void OnCancelar()
        {
            _form.carreraCurrent = null;
            _form.TransitionTo(new DisplayGridState(_form));
        }

        public void UpdateUI()
        {
            _form.tabPageAgregarEditar.Enabled = true;
            _form.tabPageLista.Enabled = false;
            _form.tabControl.SelectTab(_form.tabPageAgregarEditar);

            _form.txtNombre.Text = _form.carreraCurrent.Nombre;
            _form.txtSigla.Text = _form.carreraCurrent.Sigla;
        }

        // Estos métodos no aplican en este estado
        public Task LoadData() => Task.CompletedTask;
        public void LoadGrid() {}
        public void LoadGridFilter(string filterText) {}
        public void OnAgregar() { }
        public void OnModificar() { }
        public void OnBuscar() { }
        public Task OnEliminar() => Task.CompletedTask;
        public void OnSalir() => _form.Close();
    }
}
