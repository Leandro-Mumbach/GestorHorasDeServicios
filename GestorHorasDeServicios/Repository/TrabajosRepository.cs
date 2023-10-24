using GestorHorasDeServicios.DataAccess;
using GestorHorasDeServicios.Models;
using GestorHorasDeServicios.Services;
using Microsoft.EntityFrameworkCore;

namespace GestorHorasDeServicios.Repository
{
    public class TrabajosRepository : ITrabajosRepository
    {
        private readonly GestorDbContext _dbContext;

        public TrabajosRepository(GestorDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async  Task<IEnumerable<Trabajos>> GetAllTrabajos(int pageNumber, int pageSize)
        {
            return await _dbContext.Trabajos
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<Trabajos>GetTrabajosById(int CodTrabajo)
        {
            return await _dbContext.Trabajos.FirstOrDefaultAsync(p => p.CodTrabajo == CodTrabajo);
        }
        public async Task AddTrabajos(Trabajos trabajo)
        {
            _dbContext.Trabajos.Add(trabajo);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateTrabajo(Trabajos Trabajo)
        {
            _dbContext.Trabajos.Update(Trabajo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteTrabajoById(int CodTrabajo)
        {
            var trabajo = await _dbContext.Trabajos.FirstOrDefaultAsync(p => p.CodTrabajo == CodTrabajo);
            if (trabajo != null)
            {
                _dbContext.Trabajos.Remove(trabajo);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
