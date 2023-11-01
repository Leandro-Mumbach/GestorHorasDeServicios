using GestorHorasDeServicios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace RazorPageGHDS.Pages.Login
{
    public class LoginModel : PageModel
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        [BindProperty]
        public GestorHorasDeServicios.Models.Login Usuario { get; set; }




        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }

            var login = new Usuario
            {
                Nombre = Usuario.Nombre,
                Contraseña = Usuario.Contraseña
            };

            var jsonPayload = JsonSerializer.Serialize(login);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7103/api/Auth", content);

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();

                // Aquí puedes hacer uso del token obtenido, como almacenarlo en una cookie o sesión

                return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Credenciales inválidas");
                return Page();
            }
        }
    }
}

