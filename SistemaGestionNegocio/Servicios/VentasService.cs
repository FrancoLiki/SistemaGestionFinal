using SistemaGestionDatos.DataAccess;
using SistemaGestionEntidades.Entidades;
namespace SistemaGestionNegocio.Servicios;

public class VentasService
{
    private VentaDataAccess _ventaDataAccess;

    public VentasService(VentaDataAccess ventaDataAccess)
    {
        _ventaDataAccess = ventaDataAccess;
    }

    public Venta ObtenerVenta(int id)
    {
        Venta venta = _ventaDataAccess.ObtenerVenta(id);
        if (venta == null) throw new Exception("La venta solicitada no existe");
        return venta;
    }

    public List<Venta> ListarVentas()
    {
        return _ventaDataAccess.ListarVentas();
    }

    public void CrearVenta(Venta venta)
    {
        try
        {
            _ventaDataAccess.CrearVenta(venta);    
        }
        catch (Exception e)
        {
            throw new Exception($"{e}");
        }
    }

    public void ModificarVenta(Venta venta)
    {
        try
        {
            _ventaDataAccess.ModificarVenta(venta);
        }
        catch (Exception e)
        {
            throw new Exception($"{e}");
        }

    }
}
