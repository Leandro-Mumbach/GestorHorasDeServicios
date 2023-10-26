using GestorHorasDeServicios.DataAccess;
using GestorHorasDeServicios.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorHorasDeServicios.Repository
{
    public class ProyectosRepository : IProyectosRepository
    {
        private readonly GestorDbContext _dbContext;

        public ProyectosRepository(GestorDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Proyectos>>GetAll(int pageNumber, int pageSize)
        {
            var allProyects = await _dbContext.Proyectos
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return allProyects;
        }
        public async Task<Proyectos>GetById(int CodProyecto)
        {
            return await _dbContext.Proyectos.FirstOrDefaultAsync(p => p.CodProyecto == CodProyecto);
        }

        public async Task<IEnumerable<Proyectos>>GetState(int estado)
        {
            return await _dbContext.Proyectos.Where(element => element.Estado == estado).ToListAsync();
        }

        public async Task Add(Proyectos proyecto)
        {
            _dbContext.Proyectos.Add(proyecto);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Update(Proyectos Proyecto)
        {
            _dbContext.Proyectos.Update(Proyecto);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteById(int CodProyecto)
        {
            var proyecto = await _dbContext.Proyectos.FirstOrDefaultAsync(p => p.CodProyecto == CodProyecto);
            if (proyecto != null)
            {
                _dbContext.Proyectos.Remove(proyecto);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
