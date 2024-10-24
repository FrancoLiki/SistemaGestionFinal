using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SistemaGestionDatos.Contexts;
using SistemaGestionDatos.DataAccess;

namespace SistemaGestionDatos;
public static class ConfigureServices
{
    public static IServiceCollection ConfigureData(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProyectoCoderhouseDbContext>(
            OptionsBuilder =>
            {
                var connectionString = configuration.GetConnectionString("Coderhouse");
                OptionsBuilder.UseSqlServer(connectionString);
            }
        );
        services.AddScoped<ProductoDataAccess>();
        services.AddScoped<ProductoVendidoDataAccess>();
        services.AddScoped<VentaDataAccess>();
        services.AddScoped<UsuarioDataAccess>();
        services.AddScoped<UsuariosIngresosDataAccess>();
        return services;
    }
}
