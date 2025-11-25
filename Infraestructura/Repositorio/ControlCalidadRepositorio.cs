using FabricaNube.Core.DTOs;
using FabricaNube.Core.Interfaces;
using FabricaNube.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using FabricaNube.Core.Mapeadores;


namespace FabricaNube.Infraestructura.Repositorio
{
    public class ControlCalidadRepositorio : IControlCalidadRepositorio
    {
        private readonly FabricaDbContext _context;

        public ControlCalidadRepositorio(FabricaDbContext context)
        {
            _context = context;
        }

        public async Task<List<ControlCalidadReadDto>> GetAllAsync()
        {
            return await _context.ControlesCalidad
                .Select(c => c.ToControlCalidadReadDto())
                .ToListAsync();
        }

        public async Task<ControlCalidadReadDto?> GetByIdAsync(int id)
        {
            return await _context.ControlesCalidad
                .Where(c => c.IdControl == id)
                .Select(c => c.ToControlCalidadReadDto())
                .FirstOrDefaultAsync();
        }

        public async Task<ControlCalidadReadDto> CreateAsync(ControlCalidadCreateDto dto)
        {
            var entity = dto.ToControlCalidad();
            _context.ControlesCalidad.Add(entity);
            await _context.SaveChangesAsync();
            return entity.ToControlCalidadReadDto();
        }

        public async Task<bool> UpdateResultadoAsync(int id, string nuevoResultado)
        {
            var entity = await _context.ControlesCalidad.FindAsync(id);
            if (entity == null) return false;

            entity.Resultado = nuevoResultado;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
