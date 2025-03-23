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
using InstitutoServices.Util;
using InstitutoDesktop.ExtensionMethods;

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
            if (!ControlDeDatos()) return;
            
            _form.usuarioCurrent.Nombre = _form.txtNombre.Text;
            if (_form.usuarioCurrent.Password != _form.txtPassword.Text)
                _form.usuarioCurrent.Password = _form.txtPassword.Text.GetHashSha256();
            _form.usuarioCurrent.PermitirAccionesAdministrativas = _form.checkPermitirAccionesAdministrativas.Checked;
            _form.usuarioCurrent.Email = _form.txtEmail.Text;
            _form.usuarioCurrent.TipoUsuario = (TipoUsuarioEnum)_form.comboBoxTipoUsuario.SelectedItem;
            _form.usuarioCurrent.AlumnoId = _form.comboBoxAlumnos.SelectedItem != null ?
                                        ((Alumno)_form.comboBoxAlumnos.SelectedItem).Id : null;
            _form.usuarioCurrent.DocenteId = _form.comboBoxDocentes.SelectedItem != null ?
                                        ((Docente)_form.comboBoxDocentes.SelectedItem).Id : null;

            if (_form.usuarioCurrent.Id == 0)
            {
                try
                {
                    await firebaseAuthClient.CreateUserWithEmailAndPasswordAsync(_form.txtEmail.Text, _form.txtPassword.Text, _form.txtNombre.Text);
                }
                catch (FirebaseAuthException error) // Use alias here 
                {
                    MessageBox.Show("Registrarse", "Ocurrió un problema, no se pudo crear al usuario:" + error.Reason);
                    return;
                }
                await _form._memoryCache.AddCacheAsync<Usuario>(_form.usuarioCurrent);
            }
            else
            {
                await _form._memoryCache.UpdateCacheAsync<Usuario>(_form.usuarioCurrent);
            }

            _form.TransitionTo(new InitialDisplayState(_form));
            await _form._currentState.LoadData();
        }

        private bool ControlDeDatos()
        {
            if (string.IsNullOrEmpty(_form.txtNombre.Text) || string.IsNullOrEmpty(_form.txtEmail.Text))
            {
                MessageBox.Show("Debe definirse un nombre y email para el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (_form.checkPermitirAccionesAdministrativas.Checked &&
                string.IsNullOrEmpty(_form.txtPassword.Text))
            {
                MessageBox.Show("El usuario no tiene contraseña definida, para poder permitir las acciones administrativas debe definirle una contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_form.usuarioCurrent.Id == 0 && (string.IsNullOrEmpty(_form.txtNombre.Text) || string.IsNullOrEmpty(_form.txtEmail.Text) || string.IsNullOrEmpty(_form.txtPassword.Text)))
            {
                MessageBox.Show("Debe definirse un nombre, email y contraseña para usuarios nuevos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
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
            _form.comboBoxAlumnos.SelectedValue = _form.usuarioCurrent.AlumnoId??0;
            _form.comboBoxDocentes.SelectedValue = _form.usuarioCurrent.DocenteId??0;
        }

        // Estos métodos no aplican en este estado
        public Task LoadData() => Task.CompletedTask;
        public void LoadGrid(string filterText) {}
        public void OnAgregar() { }
        public void OnModificar() { }
        public void OnBuscar() { }
        public Task OnEliminar() => Task.CompletedTask;
        public void OnSalir() => _form.Close();
        public Task LoadComboboxDocentes() => Task.CompletedTask;
        public Task LoadComboboxAlumnos() => Task.CompletedTask;
        public void LoadComboboxTipoUsuario() { }

    }
}
