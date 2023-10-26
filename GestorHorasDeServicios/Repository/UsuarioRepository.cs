using GestorHorasDeServicios.DataAccess;
using GestorHorasDeServicios.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorHorasDeServicios.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly GestorDbContext _dbContext;

        public UsuarioRepository(GestorDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task <IEnumerable<Usuario>> ObtenerUsuarios(int pageNumber, int pageSize)
        {
            var usuariosPaginados = await _dbContext.Usuario
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return usuariosPaginados;
        }
        public async Task <Usuario> ObtenerPorId(int CodUsuario)
        {
            return await _dbContext.Usuario.FirstOrDefaultAsync(p => p.CodUsuario == CodUsuario);
        }
        public async Task Agregar(Usuario usuario)
        {
            _dbContext.Usuario.Add(usuario);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Editar(Usuario usuario)
        {
            _dbContext.Usuario.Update(usuario);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Borrar(int CodUsuario)
        {
            var usuario = _dbContext.Usuario.FirstOrDefault(p => p.CodUsuario == CodUsuario);
            if(usuario != null)
            {
                _dbContext.Usuario.Remove(usuario);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<Usuario> UsuarioSesion(string nombre, string contraseña)
        {
            var usuario = await _dbContext.Usuario.FirstOrDefaultAsync(u => u.Nombre == nombre && u.Contraseña == contraseña);
            return usuario;
        }
    }
}
