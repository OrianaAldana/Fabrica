using FabricaNube.Core.DTOs;
using FabricaNube.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FabricaNube.Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControlCalidadController : ControllerBase
    {
        private readonly IControlCalidadRepositorio _repo;

        public ControlCalidadController(IControlCalidadRepositorio repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var control = await _repo.GetByIdAsync(id);
            return control == null ? NotFound() : Ok(control);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ControlCalidadCreateDto dto)
        {
            var nuevo = await _repo.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = nuevo.IdControl }, nuevo);
        }

        [HttpPatch("{id}/resultado")]
        public async Task<IActionResult> UpdateResultado(int id, [FromBody] string nuevoResultado)
        {
            var ok = await _repo.UpdateResultadoAsync(id, nuevoResultado);
            return ok ? NoContent() : NotFound();
        }
    }
}
