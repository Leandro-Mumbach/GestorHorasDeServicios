using GestorHorasDeServicios.Models;

namespace GestorHorasDeServicios.Repository
{
    public interface IProyectosRepository
    {
        Task<IEnumerable<Proyectos>> GetAllProyectos(int pageNumber, int pageSize);
        Task<Proyectos> GetProyectosById(int CodProyecto);
        Task<IEnumerable<Proyectos>> GetProyectosState(int Estado);
        Task AddProyecto(Proyectos Proyecto);
        Task UpdateProyecto(Proyectos Proyecto);
        Task DeleteProyectoById(int CodProyectoId);
    }
}
