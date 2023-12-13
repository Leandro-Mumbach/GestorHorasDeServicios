using GestorHorasDeServicios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace RazorPageGHDS.Pages.Login
{
    public class LoginModel : PageModel
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _httpContextAccessor.HttpContext.Session.Clear();
        }

        [BindProperty]
        public GestorHorasDeServicios.Models.Login Usuario { get; set; }

        public string AuthToken { get; set; }



        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            else
            {

                var login = new Usuario
                {
                    Nombre = Usuario.Nombre,
                    Contraseña = Usuario.Contraseña
                };

                var content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("https://localhost:7103/api/Auth", content);
                if (response.IsSuccessStatusCode)
                {
                    string authToken = await response.Content.ReadAsStringAsync();
                    TempData["authToken"] = authToken;
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
                    string sessionToken = authToken;
                    _httpContextAccessor.HttpContext.Session.SetString("NewSession", sessionToken);
                    Console.WriteLine("Token guardado en variable local: " + sessionToken);

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
}

