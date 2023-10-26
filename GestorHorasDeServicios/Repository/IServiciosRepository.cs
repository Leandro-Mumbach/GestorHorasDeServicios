using GestorHorasDeServicios.Models;

namespace GestorHorasDeServicios.Repository
{
    public interface IServiciosRepository
    {
        Task<IEnumerable<Servicios>> GetAll(int pageNumber, int pageSize);
        Task<Servicios> GetById(int CodServicio);
        Task<IEnumerable<Servicios>> GetState(bool Estado);
        Task Add(Servicios Servicio);
        Task Update(Servicios Servicio);
        Task DeleteById(int CodServicioId);

    }
}
