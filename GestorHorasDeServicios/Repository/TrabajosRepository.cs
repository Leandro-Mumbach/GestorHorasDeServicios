using GestorHorasDeServicios.DataAccess;
using GestorHorasDeServicios.Models;
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
        public async  Task<IEnumerable<Trabajos>> GetAll(int pageNumber, int pageSize)
        {
            return await _dbContext.Trabajos
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<Trabajos>GetById(int CodTrabajo)
        {
            return await _dbContext.Trabajos.FirstOrDefaultAsync(p => p.CodTrabajo == CodTrabajo);
        }
        public async Task Add(Trabajos trabajo)
        {
            _dbContext.Trabajos.Add(trabajo);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Update(Trabajos Trabajo)
        {
            _dbContext.Trabajos.Update(Trabajo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteById(int CodTrabajo)
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
