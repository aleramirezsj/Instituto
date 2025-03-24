using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Login;
using InstitutoWeb.Interfaces;

namespace InstitutoWeb.Services.Login
{
    public class UsuarioStateService : IUsuarioStateService
    {
        public Usuario? Usuario { get; private set; }
        public FirebaseUser? FirebaseUser { get; private set; }

        public event Action OnChange;

        public void SetUsuario(Usuario? usuario, FirebaseUser? firebaseUser)
        {
            Usuario = usuario;
            FirebaseUser = firebaseUser;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
