using GestorHorasDeServicios.Models;
using GestorHorasDeServicios.Repository;

namespace GestorHorasDeServicios.Services
{
    public class ProyectosServices : IProyectosServices
    {
        private readonly IProyectosRepository _proyectosRepository;

        public ProyectosServices(IProyectosRepository proyectosRepository)
        {
            _proyectosRepository = proyectosRepository;
        }

        public async Task<IEnumerable<Proyectos>> GetAllProyectos(int pageNumber, int pageSize)
        {
            return await _proyectosRepository.GetAll(pageNumber, pageSize);
        }
        public async Task<Proyectos> GetProyectosById(int CodProyectos)
        {
            return await _proyectosRepository.GetById(CodProyectos);
        }
        public async Task<IEnumerable<Proyectos>> GetProyectosByEstado(int Estado)
        {
            return await _proyectosRepository.GetState(Estado);
        }
        public async Task AddProyecto(Proyectos proyecto)
        {
            await _proyectosRepository.Add(proyecto);
        }
        public async Task UpdateProyecto(Proyectos proyecto)
        {
            await _proyectosRepository.Update(proyecto);
        }
        public async Task DeleteProyectoById(int CodProyectos)
        {
            await _proyectosRepository.DeleteById(CodProyectos);
        }

    }
}
