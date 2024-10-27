using SistemaGestionEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionIU.ClientServices;

public class ProductosService
{
    private readonly HttpClient _httpClient;

    public ProductosService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    

    public async Task<Producto?> ObtenerProducto(int id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<Producto>($"{id}");
        }
        catch (HttpRequestException e)
        {
            throw new Exception($"Error al obtener el producto: {e.Message}");
        }
    }

    public async Task<List<Producto>?> ListarProductos()
    {
        return await _httpClient.GetFromJsonAsync<List<Producto>>("");
    }

    public async Task<Producto?> CrearProducto(Producto producto)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("", producto);

            if (response.IsSuccessStatusCode) 
            { 
                return await response.Content.ReadFromJsonAsync<Producto>();
            }
            throw new Exception("Error al crear el producto: " + response.ReasonPhrase);
        }
        catch (HttpRequestException e)
        {
            throw new Exception($"Error al crear el producto: {e.Message}");
        }
    }

    public async Task ModificarProducto(int id, Producto producto)
    {
        try
        {
            await _httpClient.PutAsJsonAsync($"{id}", producto);
        }
        catch (HttpRequestException e)
        {
            throw new Exception($"Error al modificar el producto: {e.Message}");
        }
    }

    public async Task EliminarProducto(int id)
    {
        try
        {
            await _httpClient.DeleteAsync($"{id}");
        }
        catch (HttpRequestException e) 
        {
            throw new Exception($"Error al eliminar el producto: {e.Message}");
        }
    }
}
