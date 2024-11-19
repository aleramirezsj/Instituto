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

namespace InstitutoDesktop.Views
{
    public partial class IniciarSesionView : Form
    {
        private readonly string _clientId = InstitutoServices.Properties.Resources.client_id + ".apps.googleusercontent.com";
        private readonly string _redirectUri = $"com.googleusercontent.apps.{InstitutoServices.Properties.Resources.client_id}:/oauth2redirect";
        private readonly string _authUri = "https://accounts.google.com/o/oauth2/v2/auth";
        private readonly string _tokenUri = "https://oauth2.googleapis.com/token";

        FirebaseAuthClient firebaseAuthClient;
        public bool loginSuccessfull { get; set; } = false;

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

        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            var listaUsuarios = await _cacheService.GetAllCacheAsync<Usuario>();
            var usuario = listaUsuarios
                            .Where(usuario => usuario.Email == txtEmail.Text &&
                            usuario.Password.GetHashSha256() == txtPassword.Text.GetHashSha256() &&
                            (usuario.PermitirAccionesAdministrativas || usuario.TipoUsuario == TipoUsuarioEnum.Directivo)).FirstOrDefault();
            var user = await firebaseAuthClient.SignInWithEmailAndPasswordAsync(txtEmail.Text, txtPassword.Text);
            if (user == null)
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
                return;
            }

            OnLoginSuccess.Invoke(this, true);

            this.Close();
            
        }

        private void chkVerContraseña_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkVerContraseña.Checked ? '\0' : '*';
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            

        }

        private async void btnIngresarConGoogle_Click(object sender, EventArgs e)
        {
            var authUrl = $"{_authUri}?client_id={_clientId}&redirect_uri={_redirectUri}&response_type=code&scope=email%20profile&access_type=offline";
            Process.Start(new ProcessStartInfo(authUrl) { UseShellExecute = true });

            // Aquí puedes implementar la lógica para recibir el código de autorización
            // desde el navegador predeterminado y continuar con el flujo de autenticación.
            string authCode = await ReceiveAuthCodeAsync();

            if (!string.IsNullOrEmpty(authCode))
            {
                string googleAccessToken = await ExchangeAuthCodeForToken(authCode);
                string userName = await SignInWithGoogleAccessToken(googleAccessToken);

                if (!string.IsNullOrEmpty(userName))
                {
                    MessageBox.Show($"Bienvenido, {userName}");
                    loginSuccessfull = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al iniciar sesión con Google.");
                }
            }
            else
            {
                MessageBox.Show("No se recibió el código de autorización.");
            }
        }

        private async Task<string> ReceiveAuthCodeAsync()
        {
            // Implementa la lógica para recibir el código de autorización desde el navegador.
            // Esto puede implicar abrir un servidor local para capturar el redireccionamiento
            // con el código de autorización.
            // Aquí se proporciona un ejemplo básico de cómo podrías hacerlo.

            var listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:5000/");
            listener.Start();

            var context = await listener.GetContextAsync();
            var authCode = context.Request.QueryString["code"];

            var response = context.Response;
            string responseString = "<html><body>Autenticación completada. Puedes cerrar esta ventana.</body></html>";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            var responseOutput = response.OutputStream;
            await responseOutput.WriteAsync(buffer, 0, buffer.Length);
            responseOutput.Close();
            listener.Stop();

            return authCode;
        }


        private async Task<string> ExchangeAuthCodeForToken(string authCode)
        {
            using (var client = new HttpClient())
            {
                var tokenRequest = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("code", authCode),
                    new KeyValuePair<string, string>("client_id", _clientId),
                    new KeyValuePair<string, string>("redirect_uri", _redirectUri),
                    new KeyValuePair<string, string>("grant_type", "authorization_code"),
                });

                var response = await client.PostAsync(_tokenUri, tokenRequest);
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                var tokenData = System.Text.Json.JsonDocument.Parse(jsonResponse).RootElement;

                return tokenData.GetProperty("id_token").GetString();
            }
        }

        private readonly string _firebaseApiKey = InstitutoServices.Properties.Resources.ApiKeyGoogleCloud;

        public async Task<string> SignInWithGoogleAccessToken(string googleAccessToken)
        {
            var firebaseUrl = $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithIdp?key={_firebaseApiKey}";

            var requestData = new
            {
                postBody = $"id_token={googleAccessToken}&providerId=google.com",
                requestUri = "http://localhost",
                returnSecureToken = true
            };

            using var httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync(firebaseUrl, requestData);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadFromJsonAsync<FirebaseSignInResponse>();
                return jsonResponse?.DisplayName;
            }
            else
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error al registrar el usuario: {errorResponse}");
                throw new HttpRequestException($"Error al registrar el usuario en Firebase: {response.ReasonPhrase}");
            }
        }
    }
}
