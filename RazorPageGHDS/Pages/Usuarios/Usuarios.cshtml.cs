using AutoMapper;
using GestorHorasDeServicios.Models.Dtos;
using GestorHorasDeServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageGHDS.Pages
{
    public class UsuariosModel : PageModel
    {
        private readonly IUsuarioServices _usuarioServices;
        private readonly IMapper _mapper;

        public UsuariosModel(IUsuarioServices usuarioServices, IMapper mapper)
        {
            _usuarioServices = usuarioServices;
            _mapper = mapper;
        }
        public List<UsuarioDto> Usuario { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }

        public async Task OnGetAsync(int pageNumber = 1, int pageSize = 3)
        {
            var usuario = await _usuarioServices.ObtenerTodosUsuarios(pageNumber, pageSize);
            Usuario = usuario.Select(t => new UsuarioDto
            {
                CodUsuario = t.CodUsuario,
                Nombre = t.Nombre,
                Dni = t.Dni,
                Tipo = t.Tipo,
            }).ToList();

            // Obtener el total de trabajos
            TotalPages = Usuario.Count;

            // Actualizar los valores de la paginación
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public async Task<IActionResult> OnPostBorrar(int CodUsuario)
        {
            await _usuarioServices.BorrarUsuario(CodUsuario);
            return RedirectToPage("Usuario");
        }
    }
}
