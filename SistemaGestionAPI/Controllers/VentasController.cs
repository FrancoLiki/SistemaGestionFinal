﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionEntidades.Entidades;
using SistemaGestionNegocio.Servicios;

namespace SistemaGestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly ILogger<VentasController> _logger; //se puede guardar informacion como un tipo de seguimiento.
        private readonly VentasService _ventasService;

        public VentasController(ILogger<VentasController> logger, VentasService ventasService)
        {
            this._logger = logger;
            _ventasService = ventasService;
        }

        [HttpGet(Name = "Get Ventas")]
        public ActionResult<List<Venta>> ListarVentas()
        {
            return _ventasService.ListarVentas();
        }


        [HttpGet("{id}")]
        public ActionResult<Venta> ObtenerVenta(int id)
        {
            _logger.LogInformation("Consultando por la venta con id {id}", id);
            var venta = _ventasService.ObtenerVenta(id);
            if (venta is null) return NotFound();
            return venta;
        }

        [HttpPost]
        public ActionResult CrearVenta([FromBody] Venta venta)
        {
            _ventasService.CrearVenta(venta);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult ModificarVenta([FromBody] Venta venta)
        {
            _ventasService.ModificarVenta(venta);
            return NoContent();
        }
    }
}
