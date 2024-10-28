using SistemaGestionEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionIU.ClientServices;

public class VentasService
{
    private readonly HttpClient _httpClient;

    public VentasService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Venta>?> ListarVentas()
    {
        return await _httpClient.GetFromJsonAsync<List<Venta>>("");
    }

    public async Task<Venta?> ObtenerVenta(int id)
    {
        return await _httpClient.GetFromJsonAsync<Venta>($"{id}");
    }

    public async Task CrearVenta(Venta venta)
    {
        try
        {
            await _httpClient.PostAsJsonAsync("", venta);
        }
        catch (HttpRequestException e)
        {
            throw new Exception($"Error al crear la venta: {e.Message}");
        }
    }

    public async Task ModificarVenta(int id, Venta venta)
    {
        try
        {
            await _httpClient.PutAsJsonAsync($"{id}", venta);
        }
        catch(Exception e)
        {
            throw new Exception($"{e}");
        }
    }
}
