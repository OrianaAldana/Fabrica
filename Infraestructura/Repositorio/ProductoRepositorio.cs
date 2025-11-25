using FabricaNube.Core.DTOs;
using FabricaNube.Core.Interfaces;
using FabricaNube.Infraestructura.Data;
using FabricaNube.Core.Mapeadores;
using Microsoft.EntityFrameworkCore;

namespace FabricaNube.Infraestructura.Repositorio
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly FabricaDbContext _context;

        public ProductoRepositorio(FabricaDbContext context)
        {
            _context = context;
        }
        private async Task<string> GenerarCodigoProductoAsync()
        {
            var ultimo = await _context.Productos
                .OrderByDescending(p => p.IdProducto)
                .FirstOrDefaultAsync();

            int numero = 1;

            if (ultimo != null && !string.IsNullOrEmpty(ultimo.Codigo))
            {
                var partes = ultimo.Codigo.Split('-');
                if (partes.Length == 2 && int.TryParse(partes[1], out int n))
                {
                    numero = n + 1;
                }
            }

            return $"PRO-{numero:D3}";
        }

        public async Task<List<ProductoReadDto>> GetAllAsync()
        {
            return await _context.Productos
                .Select(p => p.ToProductoReadDto())
                .ToListAsync();
        }

        public async Task<ProductoReadDto?> GetByCodigoAsync(int codigo)
        {
            return await _context.Productos
                .Where(p => p.IdProducto == codigo)
                .Select(p => p.ToProductoReadDto())
                .FirstOrDefaultAsync();
        }

        public async Task<ProductoReadDto> CreateAsync(ProductoCreateDto dto)
        {
            var entity = dto.ToProducto();

            entity.Codigo = await GenerarCodigoProductoAsync();

            _context.Productos.Add(entity);
            await _context.SaveChangesAsync();

            return entity.ToProductoReadDto();
        }

        public async Task<bool> UpdateByCodigoAsync(string codigo, ProductoCreateDto dto)
        {
            var entity = await _context.Productos.FirstOrDefaultAsync(p => p.Codigo == codigo);
            if (entity == null) return false;

            entity.Nombre = dto.Nombre;
            entity.Categoria = dto.Categoria;
            entity.CostoProduccion = dto.CostoProduccion;
            entity.StockMinimo = dto.StockMinimo;
            entity.ImagenUrl = dto.ImagenUrl;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteByCodigoAsync(string codigo)
        {
            var entity = await _context.Productos.FirstOrDefaultAsync(p => p.Codigo == codigo);
            if (entity == null) return false;

            _context.Productos.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
