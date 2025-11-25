using FabricaNube.Core.DTOs;
using FabricaNube.Core.Interfaces;
using FabricaNube.Infraestructura.Data;
using FabricaNube.Core.Mapeadores;
using Microsoft.EntityFrameworkCore;


namespace FabricaNube.Infraestructura.Repositorio
{
    public class LoteProduccionRepositorio : ILoteProduccionRepositorio
    {
        private readonly FabricaDbContext _context;

        public LoteProduccionRepositorio(FabricaDbContext context)
        {
            _context = context;
        }

        public async Task<List<LoteProduccionReadDto>> GetAllAsync()
        {
            return await _context.LotesProduccion
                .Select(l => l.ToLoteReadDto())
                .ToListAsync();
        }

        public async Task<LoteProduccionReadDto?> GetByIdAsync(int id)
        {
            return await _context.LotesProduccion
                .Where(l => l.IdLote == id)
                .Select(l => l.ToLoteReadDto())
                .FirstOrDefaultAsync();
        }

        public async Task<LoteProduccionReadDto> CreateAsync(LoteProduccionCreateDto dto)
        {
            var entity = dto.ToLote();
            _context.LotesProduccion.Add(entity);
            await _context.SaveChangesAsync();
            return entity.ToLoteReadDto();
        }

        public async Task<bool> UpdateEstadoAsync(int id, string nuevoEstado)
        {
            var entity = await _context.LotesProduccion.FindAsync(id);
            if (entity == null) return false;

            entity.Estado = nuevoEstado;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
