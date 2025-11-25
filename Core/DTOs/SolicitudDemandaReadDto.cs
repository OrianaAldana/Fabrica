namespace FabricaNube.Core.DTOs
{
    public class SolicitudDemandaReadDto
    {
        public int IdSolicitud { get; set; }
        public int CodSucursal { get; set; }
        public int CodArticulo { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}
