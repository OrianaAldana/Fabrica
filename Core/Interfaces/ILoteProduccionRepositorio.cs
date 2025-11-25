using FabricaNube.Core.DTOs;

namespace FabricaNube.Core.Interfaces
{
    public interface ILoteProduccionRepositorio
    {
        Task<List<LoteProduccionReadDto>> GetAllAsync();
        Task<LoteProduccionReadDto?> GetByIdAsync(int id);
        Task<LoteProduccionReadDto> CreateAsync(LoteProduccionCreateDto dto);
        Task<bool> UpdateEstadoAsync(int id, string nuevoEstado);
    }
}
