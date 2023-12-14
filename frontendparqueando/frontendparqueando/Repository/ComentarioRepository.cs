using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApplicationParqueando.Models.DTO;
using WebApplicationParqueando.Repository.Interfaces;
using WebApplicationParqueando.Utilities;

namespace WebApplicationParqueando.Repository
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly HttpClient _httpClient;

        public ComentarioRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ComentarioDTO>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ComentarioDTO>>(UrlResources.UrlComentarios);
        }

        public async Task<ComentarioDTO> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ComentarioDTO>($"{UrlResources.UrlComentarios}/{id}");
        }

        public async Task<bool> CreateAsync(ComentarioDTO comentario)
        {
            var response = await _httpClient.PostAsJsonAsync(UrlResources.UrlComentarios, comentario);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, ComentarioDTO comentario)
        {
            var response = await _httpClient.PutAsJsonAsync($"{UrlResources.UrlComentarios}/{id}", comentario);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{UrlResources.UrlComentarios}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
