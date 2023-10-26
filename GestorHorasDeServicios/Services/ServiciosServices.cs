using GestorHorasDeServicios.Models;
using GestorHorasDeServicios.Repository;

namespace GestorHorasDeServicios.Services
{
    public class ServiciosServices : IServiciosServices
    {
        private readonly IServiciosRepository _serviciosRepository;

        public ServiciosServices(IServiciosRepository serviciosRepository)
        {
            _serviciosRepository = serviciosRepository;
        }

        public async Task<IEnumerable<Servicios>> GetAllServicios(int pageNumber, int pageSize)
        {
            return await _serviciosRepository.GetAll(pageNumber, pageSize);
        }
        public async Task<Servicios> GetServiciosById(int CodServicio)
        {
            return await _serviciosRepository.GetById(CodServicio);
        }
        public async Task<IEnumerable<Servicios>> GetServiciosState(bool Estado)
        {
            return await _serviciosRepository.GetState(Estado);
        }
        public async Task AddServicio(Servicios Servicio)
        {
            await _serviciosRepository.Add(Servicio);
        }
        public async Task UpdateServicio(Servicios Servicio)
        {
            await _serviciosRepository.Update(Servicio);
        }
        public async Task DeleteServicioById(int CodServicioId)
        {
            await _serviciosRepository.DeleteById(CodServicioId);
        }
    }
}
