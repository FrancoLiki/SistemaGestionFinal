using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionEntidades.Entidades;
using SistemaGestionNegocio.Servicios;

namespace SistemaGestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosVendidosController : ControllerBase
    {
        private readonly ILogger<ProductosVendidosController> _logger;
        private readonly ProductosVendidosService _productosVendidos;

        public ProductosVendidosController(ILogger<ProductosVendidosController> logger, ProductosVendidosService productosVendidos)
        {
            _logger = logger;
            _productosVendidos = productosVendidos;
        }

        [HttpGet(Name = "Get Productos Vendidos")]
        public ActionResult<List<ProductoVendido>> ListarProductosVendidos()
        {
            return _productosVendidos.ListarProductosVendidos();    
        }
         

        [HttpGet("{id}")]
        public ActionResult<ProductoVendido> ObtenerProductoVendido(int id)
        {
            var producto = _productosVendidos.ObtenerProductoVendido(id);
            if (producto is null) return NotFound();
            return producto;
        }


        [HttpPost]
        public ActionResult<ProductoVendido> CrearProductoVendido([FromBody] ProductoVendido producto)
        {
            var productoCreado = _productosVendidos.CrearProductoVendido(producto);
            return CreatedAtAction(nameof(ObtenerProductoVendido), new { id = productoCreado.Id }, producto);
        }

        [HttpPut("{id}")]
        public ActionResult ModificarProductoVendido([FromBody] ProductoVendido producto)
        {
            _productosVendidos.ModificarProductoVendido(producto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult EliminarProductoVendido([FromRoute(Name = "id")] int id)
        {
            _productosVendidos.EliminarProductoVendido(id);
            return NoContent();
        }
    }
}
