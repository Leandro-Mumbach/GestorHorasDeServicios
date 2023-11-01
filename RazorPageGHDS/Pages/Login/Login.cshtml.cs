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
                Contrase�a = Usuario.Contrase�a
            };

            var jsonPayload = JsonSerializer.Serialize(login);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:7103/api/Auth", content);

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();

                // Aqu� puedes hacer uso del token obtenido, como almacenarlo en una cookie o sesi�n

                return RedirectToPage("/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Credenciales inv�lidas");
                return Page();
            }
        }
    }
}

