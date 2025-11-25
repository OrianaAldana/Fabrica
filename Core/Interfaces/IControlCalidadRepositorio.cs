using FabricaNube.Core.DTOs;

namespace FabricaNube.Core.Interfaces
{
    public interface IControlCalidadRepositorio
    {
        Task<List<ControlCalidadReadDto>> GetAllAsync();
        Task<ControlCalidadReadDto?> GetByIdAsync(int id);
        Task<ControlCalidadReadDto> CreateAsync(ControlCalidadCreateDto dto);
        Task<bool> UpdateResultadoAsync(int id, string nuevoResultado);
    }
}
