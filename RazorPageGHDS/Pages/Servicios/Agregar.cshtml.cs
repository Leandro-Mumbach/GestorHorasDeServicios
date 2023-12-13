using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Net.Http;

namespace RazorPageGHDS.Pages.Servicios
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

        [BindProperty]
        public GestorHorasDeServicios.Models.Servicios Servicio { get; set; }
        [TempData]
        public string Mensaje { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            var token = _httpContextAccessor.HttpContext.Session.GetString("NewSession");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.PostAsJsonAsync($"https://localhost:7103/api/ServiciosControllers", Servicio);

            if (response.IsSuccessStatusCode)
            {
                Mensaje = "Proyecto agregado correctamente";
                return RedirectToPage("Servicios");
            }
            else
            {
                return Page();
            }
        }
    }
}
