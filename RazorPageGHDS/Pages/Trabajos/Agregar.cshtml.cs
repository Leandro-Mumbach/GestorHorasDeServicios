using GestorHorasDeServicios.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Net.Http;

namespace RazorPageGHDS.Pages.Trabajos
{
    public class AgregarModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AgregarModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = new HttpClient();
            _httpContextAccessor = httpContextAccessor;
        }

        [TempData]
        public string Mensaje { get; set; }

        [BindProperty]
        public TrabajosDto Trabajo { get; set; }



        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            var token = _httpContextAccessor.HttpContext.Session.GetString("NewSession");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.PostAsJsonAsync($"https://localhost:7103/api/TrabajosControllers",Trabajo);
            if (response.IsSuccessStatusCode)
            {
                Mensaje = "Trabajo creado correctamente";
                return RedirectToPage("Trabajos");
            }
            else
            {
                return Page();
            }
        }
    }
}
