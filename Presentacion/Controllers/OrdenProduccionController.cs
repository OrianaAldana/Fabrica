using FabricaNube.Core.DTOs;
using FabricaNube.Core.Interfaces;
using FabricaNube.Infraestructura.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FabricaNube.Core.Mapeadores;
using Microsoft.EntityFrameworkCore;


namespace FabricaNube.Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenProduccionController : ControllerBase
    {
        private readonly IOrdenProduccionRepositorio _repo;

        public OrdenProduccionController(IOrdenProduccionRepositorio repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var orden = await _repo.GetByIdAsync(id);
            return orden == null ? NotFound() : Ok(orden);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrdenProduccionCreateDto dto)
        {
            var nueva = await _repo.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = nueva.IdOrden }, nueva);
        }

        [HttpPatch("{id}/estado")]
        public async Task<IActionResult> UpdateEstado(int id, [FromBody] string nuevoEstado)
        {
            var ok = await _repo.UpdateEstadoAsync(id, nuevoEstado);
            return ok ? NoContent() : NotFound();
        }
    }
}
