using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FabricaNube.Core.Entidades;
using FabricaNube.Infraestructura.Data;
using FabricaNube.Core.DTOs;
using FabricaNube.Core.Interfaces;


namespace FabricaNube.Presentacion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoteProduccionController : ControllerBase
    {
        private readonly ILoteProduccionRepositorio _repo;

        public LoteProduccionController(ILoteProduccionRepositorio repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var lote = await _repo.GetByIdAsync(id);
            return lote == null ? NotFound() : Ok(lote);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LoteProduccionCreateDto dto)
        {
            var nuevo = await _repo.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = nuevo.IdLote }, nuevo);
        }

        [HttpPatch("{id}/estado")]
        public async Task<IActionResult> UpdateEstado(int id, [FromBody] string nuevoEstado)
        {
            var ok = await _repo.UpdateEstadoAsync(id, nuevoEstado);
            return ok ? NoContent() : NotFound();
        }
    }
}
