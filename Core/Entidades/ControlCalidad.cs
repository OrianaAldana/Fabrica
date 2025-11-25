using System.ComponentModel.DataAnnotations;

namespace FabricaNube.Core.Entidades
{
    public class ControlCalidad
    {
        [Key]
        public int IdControl { get; set; }
        public int IdLote { get; set; }
        public DateTime FechaControl { get; set; } = DateTime.UtcNow;
        public string Resultado { get; set; } = "PENDIENTE";
        public string? Responsable { get; set; }
        public string? DetalleJson { get; set; }
    }
}
