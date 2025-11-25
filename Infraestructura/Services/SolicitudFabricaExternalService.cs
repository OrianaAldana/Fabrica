using System.Text;
using System.Text.Json;
using FabricaNube.Core.DTOs.SolicitudLeche;
using FabricaNube.Core.Interfaces;

namespace FabricaNube.Infraestructura.Servicios
{
    public class SolicitudLecheService : ISolicitudLecheService
    {
        private readonly HttpClient _http;

        public SolicitudLecheService(IHttpClientFactory httpClientFactory)
        {
            _http = httpClientFactory.CreateClient("GranjaService");
        }

        public async Task<bool> EnviarSolicitudLecheAsync(NuevaSolicitudLecheDto dto)
        {
            var json = JsonSerializer.Serialize(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync("/api/SolicitudesFabrica", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<List<object>> ObtenerSolicitudesLecheAsync()
        {
            var response = await _http.GetAsync("/api/SolicitudesFabrica");

            if (!response.IsSuccessStatusCode)
                return new List<object>();

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<object>>(json);
        }
    }
}

