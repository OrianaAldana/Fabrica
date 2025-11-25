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
    public class ProductosController : ControllerBase
    {
        private readonly IProductoRepositorio _repo;

        public ProductosController(IProductoRepositorio repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productos = await _repo.GetAllAsync();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByCodigo(int id)
        {
            var producto = await _repo.GetByCodigoAsync(id);
            if (producto == null) return NotFound();
            return Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductoCreateDto dto)
        {
            var nuevo = await _repo.CreateAsync(dto);
            return CreatedAtAction(nameof(GetByCodigo), new { id = nuevo.IdProducto }, nuevo);

        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> Update(string codigo, ProductoCreateDto dto)
        {
            var ok = await _repo.UpdateByCodigoAsync(codigo, dto);
            if (!ok) return NotFound();
            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<IActionResult> Delete(string codigo)
        {
            var ok = await _repo.DeleteByCodigoAsync(codigo);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}

