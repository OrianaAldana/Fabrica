namespace FabricaNube.Infraestructura.Services
{
    using System.Net.Http.Json;

    namespace FabricaNube.Infraestructura.Services
    {
        public class SolicitudFabricaExternalService
        {
            private readonly HttpClient _http;

            public SolicitudFabricaExternalService(HttpClient http)
            {
                _http = http;
            }

            // GET externo
            public async Task<IEnumerable<dynamic>> GetSolicitudesAsync()
            {
                return await _http.GetFromJsonAsync<IEnumerable<dynamic>>(
                    "https://proyecto1-production-daf8.up.railway.app/api/SolicitudesFabrica"
                );
            }

            // POST externo
            public async Task<bool> EnviarSolicitudAsync(object solicitud)
            {
                var response = await _http.PostAsJsonAsync(
                    "https://proyecto1-production-daf8.up.railway.app/api/SolicitudesFabrica",
                    solicitud
                );

                return response.IsSuccessStatusCode;
            }
        }
    }

}
