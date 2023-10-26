using GestorHorasDeServicios.Models;

namespace GestorHorasDeServicios.Services
{
    public interface IUsuarioServices
    {
        Task<IEnumerable<Usuario>> ObtenerTodosUsuarios(int pageNumber, int pageSize);
        Task<Usuario> ObtenerUsuario(int CodUsuario);
        Task AgregarUsuario(Usuario usuario);
        Task EditarUsuario(Usuario usuario);
        Task BorrarUsuario(int CodUsuario);
        Task<Usuario> UsuarioLogin(string nombre, string contraseña);
    }
}
