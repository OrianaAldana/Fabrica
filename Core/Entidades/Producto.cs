using System.ComponentModel.DataAnnotations;

namespace FabricaNube.Core.Entidades
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        [Required, MaxLength(20)]
        public string Codigo { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Categoria { get; set; } = string.Empty;

        public decimal CostoProduccion { get; set; }

        public int StockActual { get; set; } = 0;

        public int StockMinimo { get; set; } = 10;
        [Required, MaxLength(500)]
        public string ImagenUrl { get; set; } = string.Empty;
    }

}
