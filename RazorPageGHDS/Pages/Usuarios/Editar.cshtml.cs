using GestorHorasDeServicios.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Net.Http;

namespace RazorPageGHDS.Pages.Usuarios
{
    public class EditarModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EditarModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = new HttpClient();
            _httpContextAccessor = httpContextAccessor;
        }

        [BindProperty]
        public UsuarioDto User { get; set; }
        [TempData]
        public string Mensaje { get; set; }

        public async Task<IActionResult> OnGetAsync(int CodUsuario)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("NewSession");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

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

            var token = _httpContextAccessor.HttpContext.Session.GetString("NewSession");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.PutAsJsonAsync($"https://localhost:7103/api/UsuarioControllers/{User.CodUsuario}", updatedUser);

            if (response.IsSuccessStatusCode)
            {
                Mensaje = "Proyecto editado correctamente";
                return RedirectToPage("Usuarios");
            }
            else
            {
                return Page();
            }
        }
    }
}
