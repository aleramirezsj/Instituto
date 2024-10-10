using Firebase.Auth.Providers;
using Firebase.Auth;
using Microsoft.Extensions.Logging;

namespace InstitutoApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = Properties.Resources.apikeyfirebase,
                AuthDomain = Properties.Resources.authdomain,
                Providers = new Firebase.Auth.Providers.FirebaseAuthProvider[]
    {
                new EmailProvider(),
                new GoogleProvider()
    }
            }));
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
