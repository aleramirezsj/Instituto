using InstitutoBack.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Detectar si estamos en un contenedor
string password = Environment.GetEnvironmentVariable("PASSWORD")??InstitutoBack.Properties.Resources.pass;
bool isContainer = Environment.GetEnvironmentVariable("IS_CONTAINER") == "true"; /*||
                   File.Exists("/.dockerenv") || // Algunos contenedores crean este archivo
                   File.ReadAllText("/proc/1/cgroup").Contains("docker");*/

// Configurar las rutas de los certificados dinámicamente
//string certPath = isContainer ? "/app/certs/instituto.crt" : "../Certs/instituto.crt";
//string keyPath = isContainer ? "/app/certs/instituto.key" : "../Certs/instituto.key";
string certPath = isContainer ? "/app/certs/instituto.pfx" : "../Certs/instituto.pfx";


//string certPath = "/app/certs/instituto.crt";
string keyPath = "/app/certs/instituto.key";

//string certPath = "/app/certs/instituto.pfx";

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(80); // HTTP
    options.ListenAnyIP(443, listenOptions =>
    {
        if (!File.Exists(certPath))
        {
            throw new FileNotFoundException($"Certificados no encontrados. Verifica las rutas: {certPath}, {keyPath}");
        }
        listenOptions.UseHttps(certPath, password);
    });
});

var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();
string cadenaConexion = configuration.GetConnectionString("mysqlremoto");

// Add services to the container.

builder.Services.AddControllers();

//configuración de inyección de dependencias del DBContext
builder.Services.AddDbContext<InstitutoContext>(
    options => options.UseMySql(cadenaConexion,
                                ServerVersion.AutoDetect(cadenaConexion),
                    options => options.EnableRetryOnFailure(
                                        maxRetryCount: 5,
                                        maxRetryDelay: System.TimeSpan.FromSeconds(30),
                                       errorNumbersToAdd: null)
                                ));
// Configura el serializador JSON para manejar referencias cíclicas
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar una política de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins",
        builder => builder
            .WithOrigins("https://institutoweb.azurewebsites.net", "https://localhost:7189","http://localhost:8080","http://localhost:80","https://localhost:443")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
