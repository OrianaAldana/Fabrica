using FabricaNube.Core.DTOs.SolicitudLeche;

namespace FabricaNube.Core.Interfaces
{
    public interface ISolicitudLecheService
    {
        Task<bool> EnviarSolicitudLecheAsync(NuevaSolicitudLecheDto dto);
        Task<List<object>> ObtenerSolicitudesLecheAsync();
    }
}
