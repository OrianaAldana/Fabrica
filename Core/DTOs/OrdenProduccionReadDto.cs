namespace FabricaNube.Core.DTOs
{
    public class OrdenProduccionReadDto
    {
        public int IdOrden { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly? FechaFin { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}
