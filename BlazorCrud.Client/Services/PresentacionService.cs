using BlazorCrud.Shared;
using System.Net.Http.Json;

namespace BlazorCrud.Client.Services
{
    public class PresentacionService : IPresentacionService
    {
        private readonly HttpClient _http;

        public PresentacionService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<PresentacionDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<PresentacionDTO>>>("api/Presentacion/Lista");

            if(result!.EsCorrecto) 
            {
                return result.Valor;
            }
            else
            {
                throw new Exception(result.Mensaje);
            }
        }

        public async Task<PresentacionDTO> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<PresentacionDTO>>($"api/Presentacion/Buscar/{id}");

            if (result!.EsCorrecto)
            {
                return result.Valor;
            }
            else
            {
                throw new Exception(result.Mensaje);
            }
        }

        public async Task<int> Guardar(PresentacionDTO presentacion)
        {
            var result = await _http.PostAsJsonAsync("api/Presentacion/Guardar",presentacion);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
            {
                return response.Valor;
            }
            else
            {
                throw new Exception(response.Mensaje);
            }
        }

        public async Task<int> Editar(PresentacionDTO presentacion)
        {
            var result = await _http.PutAsJsonAsync($"api/Presentacion/Editar/{presentacion.PresentacionId}", presentacion);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
            {
                return response.Valor;
            }
            else
            {
                throw new Exception(response.Mensaje);
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/Presentacion/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
            {
                return response.EsCorrecto;
            }
            else
            {
                throw new Exception(response.Mensaje);
            }
        }

       

    }
}
