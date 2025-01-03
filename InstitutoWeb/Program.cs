using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using InstitutoWeb;
using InstitutoWeb.Services;
using CurrieTechnologies.Razor.SweetAlert2;
using InstitutoServices.Services.Commons;
using InstitutoServices.Interfaces;
using InstitutoServices.Interfaces.Commons;
using InstitutoServices.Interfaces.Inscripciones;
using InstitutoServices.Interfaces.Horarios;
using InstitutoServices.Services.Horarios;
using InstitutoServices.Interfaces.MesasExamenes;
using InstitutoWeb.Services.Login;
using InstitutoServices.Services.MesasExamenes;
using InstitutoServices.Services.Inscripciones;
using InstitutoWeb.Interfaces;
using Microsoft.Extensions.Logging;
using InstitutoWeb.HtmlToPdf;


var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Logging.SetMinimumLevel(LogLevel.Debug);
string urlApi = builder.Configuration.GetValue<string>("UrlApiLocal");
if (builder.Configuration.GetValue<bool>("Remote")==true)
     urlApi = builder.Configuration.GetValue<string>("UrlApiRemoto");

builder.Services.AddMemoryCache();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(urlApi) });
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<IAnioCarreraService, AnioCarreraService>();
builder.Services.AddScoped<IMateriaService, MateriaService>();
builder.Services.AddScoped<IDetalleInscripcionService, DetalleInscripcionService>();
builder.Services.AddScoped<IMesaExamenService, MesaExamenService>();
builder.Services.AddScoped<IHorarioService, HorarioService>();
builder.Services.AddScoped<IDetalleHorarioService, DetalleHorarioService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<UsuarioService>(); // Añade esta línea

builder.Services.AddScoped<IInscriptoCarreraService, InscriptoCarreraService>();
builder.Services.AddScoped<IJefaturaSeccionService, JefaturaSeccionService>();
builder.Services.AddSingleton<IUsuarioStateService, UsuarioStateService>();
builder.Services.AddSingleton<IMemoryCacheService, MemoryCacheService>();
builder.Services.AddScoped<AuthenticationService>();


builder.Services.AddSweetAlert2();
//HtmlToPdf
builder.Services.AddScoped<RazorRenderer>();
builder.Services.AddScoped<PdfGenerator>();

AppDomain.CurrentDomain.UnhandledException += (sender, eventArgs) =>
{
    var exception = eventArgs.ExceptionObject as Exception;
    // muestro el mensaje, la fuente y la pila de llamada de la excepcion no manejada
    Console.WriteLine($"Excepción no manejada: {exception?.Message}");
    Console.WriteLine($"Origen: {exception?.Source}");
    Console.WriteLine($"Pila de llamadas: {exception?.StackTrace}");
    //si la innerException no es nula, muestro el mensaje, la fuente y la pila de llamada de la innerException  
    if (exception?.InnerException != null)
    {
        Console.WriteLine($"InnerException: {exception.InnerException.Message}");
        Console.WriteLine($"Origen: {exception.InnerException.Source}");
        Console.WriteLine($"Pila de llamadas: {exception.InnerException.StackTrace}");

    }


};
await builder.Build().RunAsync();
