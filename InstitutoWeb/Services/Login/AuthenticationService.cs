using InstitutoServices.Interfaces.Commons;
using InstitutoServices.Models.Login;
using InstitutoServices.Services.Commons;
using InstitutoWeb.Interfaces;
using Microsoft.JSInterop;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;

namespace InstitutoWeb.Services.Login
{
    public class AuthenticationService
    {
        private readonly IJSRuntime _jsRuntime;
        IUsuarioStateService _usuarioStateService;
        IUsuarioService _usuarioService;

        public AuthenticationService(IJSRuntime jsRuntime, IUsuarioStateService usuarioStateService, IUsuarioService usuarioService)
        {
            _jsRuntime = jsRuntime;
            _usuarioStateService = usuarioStateService;
            _usuarioService = usuarioService;
        }

        public async Task<FirebaseUser?> LoginWithGoogle()
        {
            var userFirebase = await _jsRuntime.InvokeAsync<FirebaseUser>("appHelpers.firebaseAuth.loginWithGoogle");

            if (userFirebase != null)
            {
                var usuario = await _usuarioService.GetUserByEmail(userFirebase.Email);
                _usuarioStateService.SetUsuario(usuario, userFirebase);

            }
            return userFirebase;
        }

        public async Task<FirebaseUser?> LoginWithFacebook()
        {
            var userFirebase = await _jsRuntime.InvokeAsync<FirebaseUser>("appHelpers.firebaseAuth.loginWithFacebook");
            if (userFirebase != null)
            {
                var usuario = await _usuarioService.GetUserByEmail(userFirebase.Email);
                _usuarioStateService.SetUsuario(usuario, userFirebase);
            }
            return userFirebase;
        }

        public async Task<LoginResponse> SignInWithEmailPassword(string email, string password, bool rememberPassword)
        {

                LoginResponse response = await _jsRuntime.InvokeAsync<LoginResponse>("appHelpers.firebaseAuth.signInWithEmailPassword", email, password, rememberPassword);

            return response;

        }

        public async Task<LoginResponse> createUserWithEmailAndPassword(string email, string password, string displayName)
        {
            LoginResponse response = await _jsRuntime.InvokeAsync<LoginResponse>("appHelpers.firebaseAuth.createUserWithEmailAndPassword", email, password, displayName);
            return response;
        }

        public async Task SignOut()
        {
            await _jsRuntime.InvokeVoidAsync("appHelpers.firebaseAuth.signOut");
            _usuarioStateService.SetUsuario(null, null);
        }


        public async Task<FirebaseUser?> GetUserAuthenticated()
        {
            var userFirebase= await _jsRuntime.InvokeAsync<FirebaseUser>("appHelpers.firebaseAuth.getUserFirebase");
            //chequeo que el usuario haya verificado su correo
            if (userFirebase != null && userFirebase.EmailVerified)
            {
                var usuario = await _usuarioService.GetUserByEmail(userFirebase.Email);
                _usuarioStateService.SetUsuario(usuario, userFirebase);
                return userFirebase;
            }
            else
            {
                return null;
            }
        }
        public async Task<bool> SendPasswordResetEmail(string email)
        {
            return await _jsRuntime.InvokeAsync<bool>("appHelpers.firebaseAuth.sendPasswordResetEmail", email);
        }

    }
}
