using FabricaNube.Core.DTOs;

namespace FabricaNube.Core.Interfaces
{
    public interface IOrdenProduccionRepositorio
    {
        Task<List<OrdenProduccionReadDto>> GetAllAsync();
        Task<OrdenProduccionReadDto?> GetByIdAsync(int id);
        Task<OrdenProduccionReadDto> CreateAsync(OrdenProduccionCreateDto dto);
        Task<bool> UpdateEstadoAsync(int id, string nuevoEstado);
    }
}
