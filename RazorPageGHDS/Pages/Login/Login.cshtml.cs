using GestorHorasDeServicios.Models;
using GestorHorasDeServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageGHDS.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly IUsuarioServices _usuarioServices;
        public LoginModel(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }
        [BindProperty]
        public GestorHorasDeServicios.Models.Login usuario { get; set; }


        public async Task<IActionResult> OnPost(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var usuarioAutenticado = await _usuarioServices.UsuarioLogin(usuario.Nombre, usuario.Contraseña);
                if (usuarioAutenticado != null)
                {
                    return RedirectToPage("/Index");  
                }
            }
            ModelState.AddModelError(string.Empty, "Credenciales inválidas.");
            return Page();
        }
    }
}
