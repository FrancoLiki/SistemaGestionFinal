using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionEntidades.Entidades;
using SistemaGestionNegocio.Servicios;

namespace SistemaGestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ILogger<ProductosController> _logger; //se puede guardar informacion como un tipo de seguimiento.
        private readonly ProductosService _productosService;

        public ProductosController(ILogger<ProductosController> logger, ProductosService productos)
        {
            this._logger  = logger;
            _productosService = productos;
        }

        [HttpGet(Name = "Get Productos")]
        public ActionResult<List<Producto>> ListarProductos([FromQuery(Name = "filtro")] string? filtro)
        {
            if (filtro == null) return _productosService.ListarProductos();
            return _productosService.Filtrar(filtro);
        }




        [HttpGet("{id}")]
        public ActionResult<Producto> ObtenerProducto(int id) 
        {
            _logger.LogInformation("Consultando por el producto con id {id}", id);
            var producto = _productosService.ObtenerProducto(id);
            if (producto is null) return NotFound();
            return producto;
        }


        [HttpPost]
        public ActionResult<Producto> CrearProducto([FromBody] Producto producto)
        {
            var productoCreado = _productosService.CrearProducto(producto);
            return CreatedAtAction(nameof(ObtenerProducto), new { id = productoCreado.Id }, producto);
        }

        [HttpPut("{id}")]
        public ActionResult ModificarProducto([FromBody] Producto producto)
        {
            _productosService.ModificarProducto(producto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult EliminarProducto([FromRoute(Name = "id")] int id)
        {
            _productosService.EliminarProducto(id);
            return NoContent();
        }

    }
}
