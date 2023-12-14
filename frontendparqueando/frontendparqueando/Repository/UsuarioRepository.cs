using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApplicationParqueando.Models.DTO;
using WebApplicationParqueando.Repository.Interfaces;
using WebApplicationParqueando.Utilities;

namespace WebApplicationParqueando.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly HttpClient _httpClient;

        public UsuarioRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<UsuarioDTO>> GetAllUsuariosAsync()
        {
            var response = await _httpClient.GetStringAsync(UrlResources.UrlBase + UrlResources.UrlUsuarios);
            return JsonConvert.DeserializeObject<IEnumerable<UsuarioDTO>>(response);
        }

        public async Task<UsuarioDTO> GetUsuarioAsync(int id)
        {
            var response = await _httpClient.GetStringAsync(UrlResources.UrlBase + $"{UrlResources.UrlUsuarios}/{id}");
            return JsonConvert.DeserializeObject<UsuarioDTO>(response);
        }

        public async Task CreateUsuarioAsync(UsuarioDTO usuario)
        {
            var content = new StringContent(JsonConvert.SerializeObject(usuario), System.Text.Encoding.UTF8, "application/json");
            await _httpClient.PostAsync(UrlResources.UrlBase + UrlResources.UrlUsuarios, content);
        }

        public async Task UpdateUsuarioAsync(int id, UsuarioDTO usuario)
        {
            var content = new StringContent(JsonConvert.SerializeObject(usuario), System.Text.Encoding.UTF8, "application/json");
            await _httpClient.PutAsync(UrlResources.UrlBase + $"{UrlResources.UrlUsuarios}/{id}", content);
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            await _httpClient.DeleteAsync(UrlResources.UrlBase + $"{UrlResources.UrlUsuarios}/{id}");
        }
    }
}

