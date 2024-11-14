using CommunityToolkit.Mvvm.Messaging;
using Firebase.Auth;
using InstitutoApp.Class;
using InstitutoApp.ViewModels.Commons;
using InstitutoApp.Views;
using InstitutoApp.Views.Commons;
using InstitutoApp.Views.Login;

namespace InstitutoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new InstitutoShell();
        }
        
    }
}
