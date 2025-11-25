using FabricaNube.Core.DTOs;
using FabricaNube.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FabricaNube.Presentacion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolicitudDemandaController : ControllerBase
    {
        private readonly ISolicitudDemandaRepositorio _repo;

        public SolicitudDemandaController(ISolicitudDemandaRepositorio repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var solicitud = await _repo.GetByIdAsync(id);
            return solicitud == null ? NotFound() : Ok(solicitud);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SolicitudDemandaCreateDto dto)
        {
            var nueva = await _repo.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = nueva.IdSolicitud }, nueva);
        }

        [HttpPatch("{id}/estado")]
        public async Task<IActionResult> UpdateEstado(int id, [FromBody] string nuevoEstado)
        {
            var ok = await _repo.UpdateEstadoAsync(id, nuevoEstado);
            return ok ? NoContent() : NotFound();
        }
    }

}
