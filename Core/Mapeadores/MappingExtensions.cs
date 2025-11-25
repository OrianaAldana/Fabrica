using FabricaNube.Core.DTOs;
using FabricaNube.Core.Entidades;

namespace FabricaNube.Core.Mapeadores
{
    public static class MappingExtensions
    {
        // Producto
        public static ProductoReadDto ToProductoReadDto(this Producto p)
            => new ProductoReadDto
            {
                IdProducto = p.IdProducto,
                Codigo = p.Codigo,
                Nombre = p.Nombre,
                Categoria = p.Categoria,
                CostoProduccion = p.CostoProduccion,
                StockActual = p.StockActual,
                StockMinimo = p.StockMinimo,
                ImagenUrl = p.ImagenUrl
            };

        public static Producto ToProducto(this ProductoCreateDto dto)
            => new Producto
            {
                Nombre = dto.Nombre,
                Categoria = dto.Categoria,
                CostoProduccion = dto.CostoProduccion,
                StockMinimo = dto.StockMinimo,
                ImagenUrl = dto.ImagenUrl,
                StockActual = 0
            };

        // OrdenProduccion
        public static OrdenProduccionReadDto ToOrdenReadDto(this OrdenProduccion o)
            => new OrdenProduccionReadDto
            {
                IdOrden = o.IdOrden,
                IdProducto = o.IdProducto,
                Cantidad = o.Cantidad,
                FechaInicio = o.FechaInicio,
                FechaFin = o.FechaFin,
                Estado = o.Estado
            };

        public static OrdenProduccion ToOrden(this OrdenProduccionCreateDto dto)
            => new OrdenProduccion
            {
                IdProducto = dto.IdProducto,
                Cantidad = dto.Cantidad,
                FechaInicio = DateOnly.FromDateTime(DateTime.UtcNow),
                Estado = "PENDIENTE"
            };

        // LoteProduccion
        public static LoteProduccionReadDto ToLoteReadDto(this LoteProduccion l)
            => new LoteProduccionReadDto
            {
                IdLote = l.IdLote,
                IdOrden = l.IdOrden,
                CantidadProducida = l.CantidadProducida,
                FechaProduccion = l.FechaProduccion,
                Estado = l.Estado
            };

        public static LoteProduccion ToLote(this LoteProduccionCreateDto dto)
            => new LoteProduccion
            {
                IdOrden = dto.IdOrden,
                CantidadProducida = dto.CantidadProducida,
                FechaProduccion = DateOnly.FromDateTime(DateTime.UtcNow),
                Estado = "PENDIENTE"
            };

        // ControlCalidad
        public static ControlCalidadReadDto ToControlCalidadReadDto(this ControlCalidad c)
            => new ControlCalidadReadDto
            {
                IdControl = c.IdControl,
                IdLote = c.IdLote,
                FechaControl = c.FechaControl,
                Resultado = c.Resultado,
                Responsable = c.Responsable,
                DetalleJson = c.DetalleJson
            };

        public static ControlCalidad ToControlCalidad(this ControlCalidadCreateDto dto)
            => new ControlCalidad
            {
                IdLote = dto.IdLote,
                FechaControl = DateOnly.FromDateTime(DateTime.UtcNow),
                Resultado = "PENDIENTE",
                Responsable = dto.Responsable,
                DetalleJson = dto.DetalleJson
            };

        // SolicitudDemanda
        public static SolicitudDemandaReadDto ToSolicitudReadDto(this SolicitudDemanda s)
            => new SolicitudDemandaReadDto
            {
                IdSolicitud = s.IdSolicitud,
                CodSucursal = s.CodSucursal,
                CodArticulo = s.CodArticulo,
                Cantidad = s.Cantidad,
                FechaSolicitud = s.FechaSolicitud,
                Estado = s.Estado
            };

        public static SolicitudDemanda ToSolicitud(this SolicitudDemandaCreateDto dto)
            => new SolicitudDemanda
            {
                CodSucursal = dto.CodSucursal,
                CodArticulo = dto.CodArticulo,
                Cantidad = dto.Cantidad,
                FechaSolicitud = DateOnly.FromDateTime(DateTime.UtcNow),
                Estado = "ENVIADA"
            };

        // helpers para enumerables
        public static IEnumerable<ProductoReadDto> ToProductoReadDtos(this IEnumerable<Producto> items)
            => items.Select(i => i.ToProductoReadDto());

        public static IEnumerable<OrdenProduccionReadDto> ToOrdenReadDtos(this IEnumerable<OrdenProduccion> items)
            => items.Select(i => i.ToOrdenReadDto());

        public static IEnumerable<LoteProduccionReadDto> ToLoteReadDtos(this IEnumerable<LoteProduccion> items)
            => items.Select(i => i.ToLoteReadDto());

        public static IEnumerable<ControlCalidadReadDto> ToControlCalidadReadDtos(this IEnumerable<ControlCalidad> items)
            => items.Select(i => i.ToControlCalidadReadDto());

        public static IEnumerable<SolicitudDemandaReadDto> ToSolicitudReadDtos(this IEnumerable<SolicitudDemanda> items)
            => items.Select(i => i.ToSolicitudReadDto());
    }
}
