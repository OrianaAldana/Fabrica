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
    public class OrdenProduccionController : IOrdenProduccionRepositorio
    {
        private readonly FabricaDbContext _context;

        public OrdenProduccionController(FabricaDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrdenProduccionReadDto>> GetAllAsync()
        {
            return await _context.OrdenesProduccion
                .Select(o => o.ToOrdenReadDto())
                .ToListAsync();
        }

        public async Task<OrdenProduccionReadDto?> GetByIdAsync(int id)
        {
            return await _context.OrdenesProduccion
                .Where(o => o.IdOrden == id)
                .Select(o => o.ToOrdenReadDto())
                .FirstOrDefaultAsync();
        }

        public async Task<OrdenProduccionReadDto> CreateAsync(OrdenProduccionCreateDto dto)
        {
            var entity = dto.ToOrden();
            _context.OrdenesProduccion.Add(entity);
            await _context.SaveChangesAsync();
            return entity.ToOrdenReadDto();
        }

        public async Task<bool> UpdateEstadoAsync(int id, string nuevoEstado)
        {
            var entity = await _context.OrdenesProduccion.FindAsync(id);
            if (entity == null) return false;

            entity.Estado = nuevoEstado;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
