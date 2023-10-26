using GestorHorasDeServicios.Models;

namespace GestorHorasDeServicios.Repository
{
    public interface IProyectosRepository
    {
        Task<IEnumerable<Proyectos>> GetAll(int pageNumber, int pageSize);
        Task<Proyectos> GetById(int CodProyecto);
        Task<IEnumerable<Proyectos>> GetState(int Estado);
        Task Add(Proyectos Proyecto);
        Task Update(Proyectos Proyecto);
        Task DeleteById(int CodProyectoId);
    }
}
