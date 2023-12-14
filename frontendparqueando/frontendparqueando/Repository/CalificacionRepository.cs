using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApplicationParqueando.Models.DTO;
using WebApplicationParqueando.Repository.Interfaces;
using WebApplicationParqueando.Utilities;

namespace WebApplicationParqueando.Repository
{
    public class CalificacionRepository : ICalificacionRepository
    {
        private readonly HttpClient _httpClient;

        public CalificacionRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CalificacionDTO>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<CalificacionDTO>>(UrlResources.UrlCalificaciones);
        }

        public async Task<CalificacionDTO> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<CalificacionDTO>($"{UrlResources.UrlCalificaciones}/{id}");
        }

        public async Task<bool> CreateAsync(CalificacionDTO calificacion)
        {
            var response = await _httpClient.PostAsJsonAsync(UrlResources.UrlCalificaciones, calificacion);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, CalificacionDTO calificacion)
        {
            var response = await _httpClient.PutAsJsonAsync($"{UrlResources.UrlCalificaciones}/{id}", calificacion);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{UrlResources.UrlCalificaciones}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
