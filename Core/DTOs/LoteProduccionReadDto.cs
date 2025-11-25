namespace FabricaNube.Core.DTOs
{
    public class LoteProduccionReadDto
    {
        public int IdLote { get; set; }
        public int IdOrden { get; set; }
        public int CantidadProducida { get; set; }
        public DateOnly FechaProduccion { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}
