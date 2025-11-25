namespace FabricaNube.Core.DTOs
{
    public class ProductoReadDto
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public decimal CostoProduccion { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public string ImagenUrl { get; set; } = string.Empty;
    }
}
