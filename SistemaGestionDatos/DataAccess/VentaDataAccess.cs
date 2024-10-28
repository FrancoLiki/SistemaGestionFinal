using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SistemaGestionDatos.Contexts;
using SistemaGestionEntidades.Entidades;

namespace SistemaGestionDatos.DataAccess;

public class VentaDataAccess
{
    private readonly ProyectoCoderhouseDbContext _context;

    public VentaDataAccess(ProyectoCoderhouseDbContext context)
    {
        _context = context;
    }

    public Venta? ObtenerVenta(int id)
    {
        return _context.Ventas
            .Include(v => v.Usuario)   // Incluye los usuarios relacionados
            .FirstOrDefault(v => v.Id == id);
    }

    public List<Venta> ListarVentas()
    {
        return _context.Ventas
            .Include(p => p.Usuario)
           .ToList();
    }

    public void CrearVenta(Venta venta)
    {
        try
        {
            // Agrega la venta
            _context.Ventas.Add(venta);
            _context.SaveChanges();
            
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);

        }
    }

    public void ModificarVenta(Venta venta)
    {
        var ventaExistente = _context.Ventas.Find(venta.Id);
        if (ventaExistente != null)
        {
            // Actualizar las propiedades
            ventaExistente.Comentario = venta.Comentario;
            _context.SaveChanges(); // Guardar cambios en la base de datos
        }
    }
}
