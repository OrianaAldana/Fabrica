using FabricaNube.Core.DTOs;

namespace FabricaNube.Core.Interfaces
{
    public interface ISolicitudDemandaRepositorio
    {
        Task<List<SolicitudDemandaReadDto>> GetAllAsync();
        Task<SolicitudDemandaReadDto?> GetByIdAsync(int id);
        Task<SolicitudDemandaReadDto> CreateAsync(SolicitudDemandaCreateDto dto);
        Task<bool> UpdateEstadoAsync(int id, string nuevoEstado);
    }

}
