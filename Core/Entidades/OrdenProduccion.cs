using System.ComponentModel.DataAnnotations;

namespace FabricaNube.Core.Entidades
{
    public class OrdenProduccion
    {
        [Key]
        public int IdOrden { get; set; }

        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public DateOnly FechaInicio { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public DateOnly? FechaFin { get; set; }
        public string Estado { get; set; } = "EN_PROCESO";
    }
}
