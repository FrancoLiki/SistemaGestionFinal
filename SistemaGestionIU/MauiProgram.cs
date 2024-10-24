using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SistemaGestionIU.ClientServices;

namespace SistemaGestionIU;

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
            });

        builder.Services.AddMauiBlazorWebView();

        builder.Services.AddTransient<ProductosService>();
        builder.Services.AddTransient<UsuariosService>();
        builder.Services.AddTransient<VentasService>();
        builder.Services.AddTransient<ProductosVendidosService>();

        builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        var baseUrl = builder.Configuration["ApiUrl"];

        builder.Services.AddHttpClient<ProductosService>(
            client => client.BaseAddress = new Uri($"{baseUrl}/api/Productos/")
            );

        builder.Services.AddHttpClient<AutenticacionService>(
           client => client.BaseAddress = new Uri($"{baseUrl}/api/Autorizacion/")
           );

        builder.Services.AddHttpClient<UsuariosService>(
           client => client.BaseAddress = new Uri($"{baseUrl}/api/Usuarios/")
           );

        builder.Services.AddHttpClient<VentasService>(
           client => client.BaseAddress = new Uri($"{baseUrl}/api/Ventas/")
           );

        builder.Services.AddHttpClient<ProductosVendidosService>(
           client => client.BaseAddress = new Uri($"{baseUrl}/api/ProductosVendidos/")
           );


#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
