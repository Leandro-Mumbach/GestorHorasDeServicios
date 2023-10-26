using GestorHorasDeServicios.Models;

namespace GestorHorasDeServicios.Repository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> ObtenerUsuarios(int pageNumber, int pageSize);
        Task<Usuario> ObtenerPorId(int CodUsuario);
        Task Agregar(Usuario usuario);
        Task Editar(Usuario usuario);
        Task Borrar(int CodUsuario);
        Task<Usuario> UsuarioSesion(string nombre, string contraseña);
    }
}
