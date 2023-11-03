using GestorHorasDeServicios.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageGHDS.Pages.Usuarios
{
    public class EditarModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public EditarModel()
        {
            _httpClient = new HttpClient();
        }

        [BindProperty]
        public UsuarioDto User { get; set; }

        public async Task<IActionResult> OnGetAsync(int CodUsuario)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7103/api/UsuarioControllers/" + CodUsuario);

            if (response.IsSuccessStatusCode)
            {
                User = await response.Content.ReadFromJsonAsync<UsuarioDto>();
                return Page();
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            var updatedUser = new UsuarioDto
            {
                CodUsuario = User.CodUsuario,
                Nombre = User.Nombre,
                Dni = User.Dni,
                Tipo = User.Tipo
            };

            var response = await _httpClient.PutAsJsonAsync($"https://localhost:7103/api/UsuarioControllers/{User.CodUsuario}", updatedUser);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("Usuarios");
            }
            else
            {
                return Page();
            }
        }
    }
}
