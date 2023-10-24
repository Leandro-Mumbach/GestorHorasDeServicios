using GestorHorasDeServicios.Models;

namespace GestorHorasDeServicios.Services
{
    public interface IServiciosRepository
    {
        Task< IEnumerable<Servicios> >GetAllServicios(int pageNumber, int pageSize);
        Task <Servicios> GetServiciosById(int CodServicio);
        Task<IEnumerable<Servicios>> GetServiciosState(bool Estado);
        Task AddServicio(Servicios Servicio);
        Task UpdateServicio(Servicios Servicio);
        Task DeleteServicioById(int CodServicioId);

    }
}
