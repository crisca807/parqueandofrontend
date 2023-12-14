using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApplicationParqueando.Models.DTO;
using WebApplicationParqueando.Repository.Interfaces;
using WebApplicationParqueando.Utilities;

namespace WebApplicationParqueando.Repository
{
    public class EstablecimientoRepository : IEstablecimientoRepository
    {
        private readonly HttpClient _httpClient;

        public EstablecimientoRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<EstablecimientoDTO>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<EstablecimientoDTO>>(UrlResources.UrlEstablecimientos);
        }

        public async Task<EstablecimientoDTO> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<EstablecimientoDTO>($"{UrlResources.UrlEstablecimientos}/{id}");
        }

        public async Task<bool> CreateAsync(EstablecimientoDTO establecimiento)
        {
            var response = await _httpClient.PostAsJsonAsync(UrlResources.UrlEstablecimientos, establecimiento);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, EstablecimientoDTO establecimiento)
        {
            var response = await _httpClient.PutAsJsonAsync($"{UrlResources.UrlEstablecimientos}/{id}", establecimiento);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{UrlResources.UrlEstablecimientos}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}

