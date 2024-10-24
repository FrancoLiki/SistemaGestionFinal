using Microsoft.Extensions.DependencyInjection;
using SistemaGestionDatos;
using SistemaGestionNegocio.Servicios;
using Microsoft.Extensions.Configuration;

namespace SistemaGestionNegocio;

public static class ConfigureServices
{
    public static IServiceCollection ConfigureNegocio(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureData(configuration);
        services.AddScoped<ProductosService>();
        services.AddScoped<ProductosVendidosService>();
        services.AddScoped<UsuariosServices>();
        services.AddScoped<VentasService>(); 
        return services;
    }
}
