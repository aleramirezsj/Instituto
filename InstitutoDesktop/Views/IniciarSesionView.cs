using Firebase.Auth;
using Firebase.Auth.Providers;
using InstitutoDesktop.ExtensionMethods;
using InstitutoDesktop.Services;
using InstitutoServices.Enums;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Firebase;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace InstitutoDesktop.Views
{
    public partial class IniciarSesionView : Form
    {
        FirebaseAuthClient firebaseAuthClient;

        private readonly MemoryCacheServiceWinForms _cacheService;
        private readonly IServiceProvider _serviceProvider;

        public event EventHandler<bool> OnLoginSuccess;
        private int intentos = 0;



        public IniciarSesionView(MemoryCacheServiceWinForms memoryCacheService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _cacheService = memoryCacheService;
            _serviceProvider = serviceProvider;
            ConfiguracionFirebase();
        }

        private void ConfiguracionFirebase()
        {
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



        private void chkVerContraseña_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkVerContraseña.Checked ? '\0' : '*';
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();


        }

        

        private async void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            var listaUsuarios = await _cacheService.GetAllCacheAsync<Usuario>();
            var usuario = listaUsuarios
                            .Where(usuario => usuario.Email == txtEmail.Text &&
                            usuario.Password == txtPassword.Text.GetHashSha256() &&
                            (usuario.PermitirAccionesAdministrativas || usuario.TipoUsuario == TipoUsuarioEnum.Directivo)).FirstOrDefault();
            UserCredential user=null;
            try
            {
                user = await firebaseAuthClient.SignInWithEmailAndPasswordAsync(txtEmail.Text, txtPassword.Text);
            }
            catch (FirebaseAuthException error)
            {

                //MessageBox.Show($"Ha ocurrido un error en la autenticación:{error.Reason}");
                //intentos++;
                //if (intentos == 3)
                //{
                //    MessageBox.Show("Se ha superado la cantidad de intentos permitidos, el sistema se cerrará");
                //    OnLoginSuccess.Invoke(this, false);
                //    this.Close();
                //}
                //return;
            }
            if (user == null&& usuario == null)
            {
                MessageBox.Show("Email o password incorrecto, intentelo nuevamente");
                intentos++;
                if (intentos == 3)
                {
                    MessageBox.Show("Se ha superado la cantidad de intentos permitidos, el sistema se cerrará");
                    OnLoginSuccess.Invoke(this, false);
                    this.Close();
                }
                return;
            }

            if (usuario == null)
            {
                MessageBox.Show("Usuario no autorizado al uso de este software");
                intentos++;
                if (intentos == 3)
                {
                    MessageBox.Show("Se ha superado la cantidad de intentos permitidos, el sistema se cerrará");
                    OnLoginSuccess.Invoke(this, false);
                    this.Close();
                }
                return;
            }

            OnLoginSuccess.Invoke(this, true);

            this.Close();
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            OnLoginSuccess.Invoke(this, false);
            this.Close();
        }
    }
}
