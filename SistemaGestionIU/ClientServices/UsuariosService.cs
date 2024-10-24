using Microsoft.AspNetCore.WebUtilities;
using SistemaGestionEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionIU.ClientServices;

public class UsuariosService
{
    private readonly HttpClient _httpClient;

    public UsuariosService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Usuario>?> ListarUsuarios()
    {
        return await _httpClient.GetFromJsonAsync<List<Usuario>>("");
    }

    public async Task<Usuario?> ObtenerUsuario(int id)
    {
        return await _httpClient.GetFromJsonAsync<Usuario>($"{id}");
    }

    public async Task<Usuario?> CrearUsuario(Usuario usuario)
    {
        // Realiza la solicitud POST y captura la respuesta
        var response = await _httpClient.PostAsJsonAsync("", usuario);

        // Verifica si la respuesta es exitosa
        if (response.IsSuccessStatusCode)
        {
            // Deserializa la respuesta y devuelve el usuario creado
            return await response.Content.ReadFromJsonAsync<Usuario>();
        }

        // Manejo de errores (puedes lanzar una excepción o devolver null, según lo que prefieras)
        throw new Exception("Error al crear el usuario: " + response.ReasonPhrase);
    }


    public async Task ModificarUsuario(int id, Usuario usuario)
    {
        await _httpClient.PutAsJsonAsync($"{id}", usuario);
    }

    public async Task EliminarUsuario(int id)
    {
        await _httpClient.DeleteAsync($"{id}");
    }

    public async Task<List<Usuario>?> Filtrar(string filtro)
    {
        return await _httpClient.GetFromJsonAsync<List<Usuario>>(
            QueryHelpers.AddQueryString("", new Dictionary<string, string>() { { "filtro", filtro } }));
    }
}
