using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Login;

namespace InstitutoWeb.Interfaces
{
    public interface IUsuarioStateService
    {
        public Usuario? Usuario { get; }
        public FirebaseUser? FirebaseUser { get; }

        event Action OnChange;

        void SetUsuario(Usuario? usuario, FirebaseUser? firebaseUser);
    }
}