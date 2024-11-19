using Firebase.Auth.Providers;
using Firebase.Auth;
using Microsoft.Extensions.Logging;
using InstitutoServices.Services.Commons;
using InstitutoApp.ViewModels.Commons;
using InstitutoApp.Views.Commons;

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
                ApiKey = InstitutoServices.Properties.Resources.ApiKeyFirebase,
                AuthDomain = InstitutoServices.Properties.Resources.AuthDomainFirebase,
                Providers = new Firebase.Auth.Providers.FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            }));
            builder.Services.AddMemoryCache();
            builder.Services.AddSingleton<IMemoryCacheService, MemoryCacheService>();
            builder.Services.AddTransient<CarrerasView>();
            builder.Services.AddTransient<AddEditCarreraView>();
#if DEBUG



            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
