using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Interfaces.MesasExamenes;
using InstitutoDesktop.Views.Commons;
using InstitutoDesktop.Views.Inscripciones;
using InstitutoDesktop.Views.MesasExamenes;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Inscripciones;
using InstitutoServices.Models.MesasExamenes;

namespace InstitutoDesktop.States.Commons.Alumnos
{
    public class EditionState : IAlumnosViewState
    {
        private readonly AlumnosView _form;

        public EditionState(AlumnosView form)
        {
            _form = form;
            UpdateUI();
        }

        public async Task OnGuardar()
        {
            if (string.IsNullOrEmpty(_form.txtNombre.Text))
            {
                MessageBox.Show("Debe definirse un nombre para el alumno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _form.alumnoCurrent.ApellidoNombre = _form.txtNombre.Text;
            _form.alumnoCurrent.Direccion = _form.txtDireccion.Text;
            _form.alumnoCurrent.Telefono = _form.txtTelefono.Text;
            _form.alumnoCurrent.Email = _form.txtEmail.Text;

            if (_form.alumnoCurrent.Id == 0)
            {
                await _form._memoryCache.AddCacheAsync<Alumno>(_form.alumnoCurrent);
            }
            else
            {
                await _form._memoryCache.UpdateCacheAsync<Alumno>(_form.alumnoCurrent);
            }

            _form.TransitionTo(new InitialDisplayState(_form));
            await _form._currentState.LoadData();
        }

        public void OnCancelar()
        {
            _form.alumnoCurrent = null;
            _form.TransitionTo(new InitialDisplayState(_form));
        }

        public void UpdateUI()
        {
            _form.tabPageAgregarEditar.Enabled = true;
            _form.tabPageLista.Enabled = false;
            _form.tabControl.SelectTab(_form.tabPageAgregarEditar);

            _form.txtNombre.Text = _form.alumnoCurrent.ApellidoNombre;
            _form.txtDireccion.Text = _form.alumnoCurrent.Direccion;
            _form.txtTelefono.Text = _form.alumnoCurrent.Telefono;
            _form.txtEmail.Text = _form.alumnoCurrent.Email;
        }

        // Estos métodos no aplican en este estado
        public Task LoadData() => Task.CompletedTask;
        public void LoadGrid(string filterText) {}
        public void OnAgregar() { }
        public void OnModificar() { }
        public void OnBuscar() { }
        public Task OnEliminar() => Task.CompletedTask;
        public void OnSalir() => _form.Close();

    }
}
