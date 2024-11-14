using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using InstitutoApp.Class;

namespace InstitutoApp.ViewModels.Login
{
    public class IniciarSesionViewModel : NotificationObject
    {
        public readonly FirebaseAuthClient _clientAuth;
        private FileUserRepository _userRepository;
        private UserInfo _userInfo;
        private FirebaseCredential _firebaseCredential;


        private string email;
		public string Email
		{
			get { return email; }
			set { email = value;
				OnPropertyChanged();
				IniciarSesionCommand.ChangeCanExecute();
            }
		}

		private string password;
		public string Password
		{
			get { return password; }
			set { password = value;
				OnPropertyChanged();
                IniciarSesionCommand.ChangeCanExecute();
            }
		}

		private bool recordarContraseña;
		public bool RecordarContraseña
		{
			get { return recordarContraseña; }
			set { recordarContraseña = value;
				OnPropertyChanged();
			}
		}

        public Command IniciarSesionCommand { get; }
        public Command RegistrarseCommand { get; }

        public IniciarSesionViewModel()
        {
            
            _clientAuth = new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyBmHgrN0BoHgd0ZlDqY9f_BygkzOfhuP_E",
                AuthDomain = "instituto20-435114.firebaseapp.com",
                Providers = new Firebase.Auth.Providers.FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            });
            _userRepository = new FileUserRepository("InstitutoApp");
            ChequearSiHayUsuarioAlmacenado();
            IniciarSesionCommand = new Command(IniciarSesion,PermitirIniciarSesion);
            RegistrarseCommand = new Command(Registrarse);
        }

        private async void Registrarse(object obj)
        {
            await Shell.Current.GoToAsync("Registrarse");
        }

        private async void ChequearSiHayUsuarioAlmacenado()
        {
            if (_userRepository.UserExists())
            {
                (_userInfo, _firebaseCredential) = _userRepository.ReadUser();

                var institutoShell = (InstitutoShell)App.Current.MainPage;
                institutoShell.EnableAppAfterLogin();
            }
        }

        private bool PermitirIniciarSesion(object arg)
        {
            return !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password);
        }

        private async void IniciarSesion(object obj)
        {
            try
            {

                var userCredential = await _clientAuth.SignInWithEmailAndPasswordAsync(email, password);
                if(userCredential.User.Info.IsEmailVerified == false)
                {
                    await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "Debe verificar su correo electrónico", "Ok");
                    return;
                }

                if (recordarContraseña)
                {
                    _userRepository.SaveUser(userCredential.User);
                }
                else
                {
                    _userRepository.DeleteUser();
                }

                var institutoShell = (InstitutoShell)App.Current.MainPage;
                institutoShell.EnableAppAfterLogin();

            }
            catch (FirebaseAuthException error)
            {
                await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "Ocurrió un problema:" + error.Reason, "Ok");

            }

        }
    }
}
