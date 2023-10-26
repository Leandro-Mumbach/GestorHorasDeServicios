using GestorHorasDeServicios.Models;

namespace GestorHorasDeServicios.Services
{
    public interface ITrabajosServices
    {
        Task<IEnumerable<Trabajos>> GetAllTrabajos(int pageNumber, int pageSize);
        Task<Trabajos> GetTrabajosById(int CodTrabajos);
        Task AddTrabajos(Trabajos Trabajo);
        Task UpdateTrabajo(Trabajos Trabajo);
        Task DeleteTrabajoById(int CodTrabajoId);
    }
}
