using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Views;
using InstitutoDesktop.Views.Commons;
using InstitutoServices.Models.Commons;

namespace InstitutoDesktop.States.Commons.Aulas
{
    public class EditionState : IBaseViewState
    {
        private readonly AulasView _form;

        public EditionState(AulasView form)
        {
            _form = form;
            UpdateUI();
        }

        public async Task OnGuardar()
        {
            if (string.IsNullOrEmpty(_form.txtNombre.Text))
            {
                MessageBox.Show("Debe definirse un nombre para el aula ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _form.aulaCurrent.Nombre = _form.txtNombre.Text;

            if (_form.aulaCurrent.Id == 0)
            {
                await _form._memoryCache.AddCacheAsync<Aula>(_form.aulaCurrent);
            }
            else
            {
                await _form._memoryCache.UpdateCacheAsync<Aula>(_form.aulaCurrent);
            }

            _form.TransitionTo(new DisplayGridState(_form));
        }

        public void OnCancelar()
        {
            _form.aulaCurrent = null;
            _form.TransitionTo(new DisplayGridState(_form));
        }

        public void UpdateUI()
        {
            _form.tabPageAgregarEditar.Enabled = true;
            _form.tabPageLista.Enabled = false;
            _form.tabControl.SelectTab(_form.tabPageAgregarEditar);

            _form.txtNombre.Text = _form.aulaCurrent.Nombre;
        }

        // Estos métodos no aplican en este estado
        public Task LoadData() => Task.CompletedTask;
        public Task LoadGrid() => Task.CompletedTask;
        public Task LoadGridFilter(string filterText) => Task.CompletedTask;
        public void OnAgregar() { }
        public void OnModificar() { }
        public void OnBuscar() { }
        public Task OnEliminar() => Task.CompletedTask;
        public void OnSalir() => _form.Close();
    }
}
