using GestorHorasDeServicios.DataAccess;
using GestorHorasDeServicios.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorHorasDeServicios.Repository
{
    public class ServiciosRepository : IServiciosRepository
    {
        private readonly GestorDbContext _dbContext;

        public ServiciosRepository(GestorDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task< IEnumerable<Servicios> >GetAll(int pageNumber, int pageSize)
        {
            return await _dbContext.Servicio
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task <Servicios> GetById(int CodServicio)
        {
            return await _dbContext.Servicio.FirstOrDefaultAsync(p => p.CodServicio == CodServicio);
        }
        public async Task<IEnumerable<Servicios>> GetState(bool Estado)
        {
            return await _dbContext.Servicio.Where(element => element.Estado == Estado).ToListAsync();
        }
        public async Task Add( Servicios servicio)
        {
            _dbContext.Servicio.Add(servicio);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Update(Servicios Servicio)
        {
            _dbContext.Servicio.Update(Servicio);
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task DeleteById(int CodServicio)
        {
            var servicio = _dbContext.Servicio.FirstOrDefault(p => p.CodServicio == CodServicio);
            if(servicio != null)
            {
                _dbContext.Servicio.Remove(servicio);
                await _dbContext.SaveChangesAsync() ;
            }
        }
    }
}
