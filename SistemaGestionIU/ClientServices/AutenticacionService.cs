using SistemaGestionEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionIU.ClientServices;

public class AutenticacionService
{
    private readonly HttpClient _httpClient;

    public AutenticacionService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Usuario?> Autenticar(UsuarioIngreso usuario)
    {
        var response = await _httpClient.PostAsJsonAsync("login", usuario);
        if (response.IsSuccessStatusCode)
        {
            var authResponse = await response.Content.ReadFromJsonAsync<Usuario>();
            return authResponse; // Devuelve el usuario autenticado
        }
        return null; // Usuario no autenticado
    }
}
