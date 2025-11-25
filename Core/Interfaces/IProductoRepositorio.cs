using FabricaNube.Core.DTOs;

namespace FabricaNube.Core.Interfaces
{
    public interface IProductoRepositorio
    {
        Task<List<ProductoReadDto>> GetAllAsync();
        Task<ProductoReadDto?> GetByCodigoAsync(int codigo);
        Task<ProductoReadDto> CreateAsync(ProductoCreateDto dto);
        Task<bool> UpdateByCodigoAsync(string codigo, ProductoCreateDto dto);
        Task<bool> DeleteByCodigoAsync(string codigo);
    }
}
