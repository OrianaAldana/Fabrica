namespace FabricaNube.Core.DTOs
{
    public class ControlCalidadReadDto
    {
        public int IdControl { get; set; }
        public int IdLote { get; set; }
        public DateTime FechaControl { get; set; }
        public string Resultado { get; set; } = string.Empty;
        public string? Responsable { get; set; }
        public string? DetalleJson { get; set; }
    }
}
