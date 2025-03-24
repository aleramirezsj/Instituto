using InstitutoServices.Interfaces.Commons;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Login;
using InstitutoWeb.Interfaces;
using Microsoft.JSInterop;

namespace InstitutoWeb.Services.Login
{
    public class UsuarioStateService(IJSRuntime jsRuntime, IUsuarioService usuarioService) : IUsuarioStateService
    {
        private readonly IJSRuntime _jsRuntime = jsRuntime;
        IUsuarioService _usuarioService = usuarioService;
        public Usuario? Usuario { get; private set; }
        public FirebaseUser? FirebaseUser { get; private set; }

        public event Action? OnChange;

        public async Task InitializeAsync()
        {
            // Lógica de inicialización, por ejemplo, obtener el usuario autenticado
            var userFirebase = await _jsRuntime.InvokeAsync<FirebaseUser>("firebaseAuth.getUserFirebase");
            if (userFirebase != null && userFirebase.EmailVerified)
            {
                var usuario = await _usuarioService.GetUserByEmail(userFirebase.Email);
                SetUsuario(usuario, userFirebase);
            }
        }

        public void SetUsuario(Usuario? usuario, FirebaseUser? firebaseUser)
        {
            Usuario = usuario;
            FirebaseUser = firebaseUser;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
