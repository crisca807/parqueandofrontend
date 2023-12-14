using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApplicationParqueando.Models.DTO;
using WebApplicationParqueando.Repository.Interfaces;
using WebApplicationParqueando.Utilities;

namespace WebApplicationParqueando.Repository
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly HttpClient _httpClient;

        public ReservaRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ReservaDTO>> GetAllAsync()
        {
            var reservas = await _httpClient.GetFromJsonAsync<IEnumerable<ReservaDTO>>(UrlResources.UrlReservas);
            return reservas;
        }

        public async Task<ReservaDTO> GetByIdAsync(int id)
        {
            var reserva = await _httpClient.GetFromJsonAsync<ReservaDTO>($"{UrlResources.UrlReservas}/{id}");
            return reserva;
        }

        public async Task PostAsync(ReservaDTO reserva)
        {
            await _httpClient.PostAsJsonAsync(UrlResources.UrlReservas, reserva);
        }

        public async Task PutAsync(int id, ReservaDTO reserva)
        {
            await _httpClient.PutAsJsonAsync($"{UrlResources.UrlReservas}/{id}", reserva);
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"{UrlResources.UrlReservas}/{id}");
        }
    }
}
