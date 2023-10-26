using GestorHorasDeServicios.Models;

namespace GestorHorasDeServicios.Services
{
    public interface IProyectosServices
    {
        Task<IEnumerable<Proyectos>> GetAllProyectos(int pageNumber, int pageSize);
        Task<Proyectos> GetProyectosById(int CodProyecto);
        Task<IEnumerable<Proyectos>> GetProyectosByEstado(int Estado);
        Task AddProyecto(Proyectos Proyecto);
        Task UpdateProyecto(Proyectos Proyecto);
        Task DeleteProyectoById(int CodProyectoId);
    }
}
