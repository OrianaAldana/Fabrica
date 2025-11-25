using System.ComponentModel.DataAnnotations;

namespace FabricaNube.Core.Entidades
{
    public class SolicitudDemanda
    {
        [Key]
        public int IdSolicitud { get; set; }
        public int CodSucursal { get; set; }
        public int CodArticulo { get; set; }
        public int Cantidad { get; set; }
        public DateOnly FechaSolicitud { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public string Estado { get; set; } = "ENVIADA";
    }

}
