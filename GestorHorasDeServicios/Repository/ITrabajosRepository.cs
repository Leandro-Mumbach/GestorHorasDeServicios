using GestorHorasDeServicios.Models;

namespace GestorHorasDeServicios.Repository
{
    public interface ITrabajosRepository
    {
        Task<IEnumerable<Trabajos>> GetAll(int pageNumber, int pageSize);
        Task<Trabajos> GetById(int CodTrabajos);
        Task Add(Trabajos Trabajo);
        Task Update(Trabajos Trabajo);
        Task DeleteById(int CodTrabajoId);
    }
}
