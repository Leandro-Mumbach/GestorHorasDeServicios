using GestorHorasDeServicios.Models;
using GestorHorasDeServicios.Repository;

namespace GestorHorasDeServicios.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioServices(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodosUsuarios(int pageNumber, int pageSize)
        {
            return await _usuarioRepository.ObtenerUsuarios(pageNumber, pageSize);
        }
        public async Task<Usuario> ObtenerUsuario(int CodUsuario)
        {
            return await _usuarioRepository.ObtenerPorId(CodUsuario);
        }
        public async Task AgregarUsuario(Usuario usuario)
        {
            await _usuarioRepository.Agregar(usuario);
        }
        public async Task EditarUsuario(Usuario usuario)
        {
            await _usuarioRepository.Editar(usuario);
        }
        public async Task BorrarUsuario(int CodUsuario)
        {
            await _usuarioRepository.Borrar(CodUsuario);
        }
        public async Task<Usuario> UsuarioLogin(string nombre, string contraseña)
        {
            return await _usuarioRepository.UsuarioSesion(nombre, contraseña);
        }
    }
}
