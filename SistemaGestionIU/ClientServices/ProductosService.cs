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

    public async Task<List<Producto>?> ListarProductosUsuario(int idUsuario)
    {
        return await _httpClient.GetFromJsonAsync<List<Producto>>($"{idUsuario}");
    }
}
