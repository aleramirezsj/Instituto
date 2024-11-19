using Firebase.Auth.Providers;
using Firebase.Auth;
using InstitutoDesktop.Interfaces.Commons;
using InstitutoDesktop.Interfaces.MesasExamenes;
using InstitutoDesktop.Views.Commons;
using InstitutoDesktop.Views.Inscripciones;
using InstitutoDesktop.Views.MesasExamenes;
using InstitutoServices.Enums;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Inscripciones;
using InstitutoServices.Models.MesasExamenes;

namespace InstitutoDesktop.States.Commons.Usuarios
{
    public class EditionState : IUsuariosViewState
    {
        private readonly UsuariosView _form;
        private readonly FirebaseAuthClient firebaseAuthClient;

        public EditionState(UsuariosView form)
        {
            _form = form;
            UpdateUI();
            var config = new FirebaseAuthConfig
            {
                ApiKey = InstitutoServices.Properties.Resources.ApiKeyFirebase,
                AuthDomain = InstitutoServices.Properties.Resources.AuthDomainFirebase,
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                },
            };

            firebaseAuthClient = new FirebaseAuthClient(config);
        }

        public async Task OnGuardar()
        {
            if (string.IsNullOrEmpty(_form.txtNombre.Text))
            {
                MessageBox.Show("Debe definirse un nombre para el alumno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_form.txtPassword.Text.Length<6)
            {
                MessageBox.Show("El password debe definirse de al menos 6 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                await firebaseAuthClient.CreateUserWithEmailAndPasswordAsync(_form.txtEmail.Text, _form.txtPassword.Text,_form.txtNombre.Text);
            }
            catch (FirebaseAuthException error) // Use alias here 
            {
                MessageBox.Show("Registrarse", "Ocurrió un problema, no se pudo crear al usuario:" + error.Reason);
                return;
            }


            _form.usuarioCurrent.Nombre = _form.txtNombre.Text;
            _form.usuarioCurrent.Password = _form.txtPassword.Text;
            _form.usuarioCurrent.PermitirAccionesAdministrativas = _form.checkPermitirAccionesAdministrativas.Checked;
            _form.usuarioCurrent.Email = _form.txtEmail.Text;
            _form.usuarioCurrent.TipoUsuario = (TipoUsuarioEnum)_form.comboBoxTipoUsuario.SelectedItem;
            _form.usuarioCurrent.AlumnoId = _form.comboBoxAlumnos.SelectedItem != null ?
                                        ((Alumno)_form.comboBoxAlumnos.SelectedItem).Id : null;
            _form.usuarioCurrent.DocenteId = _form.comboBoxDocentes.SelectedItem != null ?
                                        ((Docente)_form.comboBoxDocentes.SelectedItem).Id : null;

            if (_form.usuarioCurrent.Id == 0)
            {
                await _form._memoryCache.AddCacheAsync<Usuario>(_form.usuarioCurrent);
            }
            else
            {
                await _form._memoryCache.UpdateCacheAsync<Usuario>(_form.usuarioCurrent);
            }

            _form.TransitionTo(new InitialDisplayState(_form));
            await _form._currentState.LoadData();
        }

        public void OnCancelar()
        {
            _form.usuarioCurrent = null;
            _form.TransitionTo(new InitialDisplayState(_form));
        }

        public void UpdateUI()
        {
            _form.tabPageAgregarEditar.Enabled = true;
            _form.tabPageLista.Enabled = false;
            _form.tabControl.SelectTab(_form.tabPageAgregarEditar);

            _form.txtNombre.Text = _form.usuarioCurrent.Nombre;
            _form.txtPassword.Text = _form.usuarioCurrent.Password;
            _form.txtEmail.Text = _form.usuarioCurrent.Email;
            _form.checkPermitirAccionesAdministrativas.Checked = _form.usuarioCurrent.PermitirAccionesAdministrativas;
            _form.comboBoxTipoUsuario.SelectedItem = _form.usuarioCurrent.TipoUsuario;
            _form.comboBoxAlumnos.SelectedItem = _form.usuarioCurrent.Alumno;
            _form.comboBoxDocentes.SelectedItem = _form.usuarioCurrent.Docente;
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
