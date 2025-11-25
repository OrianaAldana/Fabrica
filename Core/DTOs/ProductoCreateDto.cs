namespace FabricaNube.Core.DTOs
{
    public class ProductoCreateDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public decimal CostoProduccion { get; set; }
        public int StockMinimo { get; set; }
        public string ImagenUrl { get; set; } = string.Empty;
    }
}
