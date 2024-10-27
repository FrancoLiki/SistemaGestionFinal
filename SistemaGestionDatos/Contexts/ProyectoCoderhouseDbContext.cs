using SistemaGestionEntidades.Entidades;
using Microsoft.EntityFrameworkCore;



namespace SistemaGestionDatos.Contexts;

public class ProyectoCoderhouseDbContext : DbContext
{
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<UsuarioIngreso> UsuariosIngresos { get; set; }
    public DbSet<Venta> Ventas { get; set; }
    public ProyectoCoderhouseDbContext(DbContextOptions<ProyectoCoderhouseDbContext> options) : base(options)
    { }

    public ProyectoCoderhouseDbContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-16EVV0E; Initial Catalog=ProyectoFinalCoderDB; Integrated Security=True; Encrypt=True; TrustServerCertificate=True");
        }
    }
}
