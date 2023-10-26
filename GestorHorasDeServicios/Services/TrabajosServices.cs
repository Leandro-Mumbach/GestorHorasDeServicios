using GestorHorasDeServicios.Models;
using GestorHorasDeServicios.Repository;

namespace GestorHorasDeServicios.Services
{
    public class TrabajosServices : ITrabajosServices
    {
        private readonly ITrabajosRepository _trabajosRepository;

        public TrabajosServices(ITrabajosRepository trabajosRepository)
        {
            _trabajosRepository = trabajosRepository;
        }

        public async Task<IEnumerable<Trabajos>>GetAllTrabajos(int pageNumber, int pageSize)
        {
            return await _trabajosRepository.GetAll(pageNumber,  pageSize);
        }
        public async Task<Trabajos> GetTrabajosById(int CodTrabajos)
        {
            return await _trabajosRepository.GetById(CodTrabajos);
        }
        public async Task AddTrabajos(Trabajos trabajo)
        {
             await _trabajosRepository.Add(trabajo);
        }
        public async Task UpdateTrabajo(Trabajos trabajo)
        {
             await _trabajosRepository.Update(trabajo);
        }
        public async Task DeleteTrabajoById(int CodTrabajos)
        {
             await _trabajosRepository.DeleteById(CodTrabajos);
        }

    }
}
