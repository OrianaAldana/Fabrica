using FabricaNube.Core.DTOs.SolicitudLeche;
using FabricaNube.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FabricaNube.Presentacion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolicitudLecheController : ControllerBase
    {
        private readonly ISolicitudLecheService _service;

        public SolicitudLecheController(ISolicitudLecheService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get() =>
            Ok(await _service.ObtenerSolicitudesLecheAsync());

        [HttpPost]
        public async Task<IActionResult> Post(NuevaSolicitudLecheDto dto)
        {
            var ok = await _service.EnviarSolicitudLecheAsync(dto);
            return ok ? Ok("Solicitud de leche enviada") : BadRequest("Error enviando solicitud");
        }
    }
}
