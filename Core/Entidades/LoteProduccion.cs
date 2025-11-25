using System.ComponentModel.DataAnnotations;

namespace FabricaNube.Core.Entidades
{
    public class LoteProduccion
    {
        [Key]
        public int IdLote { get; set; }
        public int IdOrden { get; set; }
        public int CantidadProducida { get; set; }
        public DateOnly FechaProduccion { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public string Estado { get; set; } = "PENDIENTE";
    }

}
