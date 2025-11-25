using FabricaNube.Core.DTOs;
using FabricaNube.Core.Interfaces;
using FabricaNube.Infraestructura.Data;

namespace FabricaNube.Infraestructura.Repositorio
{
    public class SolicitudDemandaRepositorio : ISolicitudDemandaRepositorio
    {
        private readonly FabricaDbContext _context;

        public SolicitudDemandaRepositorio(FabricaDbContext context)
        {
            _context = context;
        }

        public async Task<List<SolicitudDemandaReadDto>> GetAllAsync()
        {
            return await _context.SolicitudesDemanda
                .Select(s => s.ToSolicitudReadDto())
                .ToListAsync();
        }

        public async Task<SolicitudDemandaReadDto?> GetByIdAsync(int id)
        {
            return await _context.SolicitudesDemanda
                .Where(s => s.IdSolicitud == id)
                .Select(s => s.ToSolicitudReadDto())
                .FirstOrDefaultAsync();
        }

        public async Task<SolicitudDemandaReadDto> CreateAsync(SolicitudDemandaCreateDto dto)
        {
            var entity = dto.ToSolicitud();
            _context.SolicitudesDemanda.Add(entity);
            await _context.SaveChangesAsync();
            return entity.ToSolicitudReadDto();
        }

        public async Task<bool> UpdateEstadoAsync(int id, string nuevoEstado)
        {
            var entity = await _context.SolicitudesDemanda.FindAsync(id);
            if (entity == null) return false;

            entity.Estado = nuevoEstado;
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
