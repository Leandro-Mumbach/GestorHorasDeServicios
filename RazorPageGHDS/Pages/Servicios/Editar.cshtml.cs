using GestorHorasDeServicios.Models;
using GestorHorasDeServicios.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Net.Http;

namespace RazorPageGHDS.Pages.Servicios
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
        public GestorHorasDeServicios.Models.Servicios Servicios { get; set; }
        [TempData]
        public string Mensaje { get; set; }

        public async Task<IActionResult> OnGetAsync(int CodServicio)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("NewSession");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"https://localhost:7103/api/ServiciosControllers/" + CodServicio);

            if (response.IsSuccessStatusCode)
            {
                Servicios = await response.Content.ReadFromJsonAsync<GestorHorasDeServicios.Models.Servicios>();
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
            var token = _httpContextAccessor.HttpContext.Session.GetString("NewSession");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.PutAsJsonAsync($"https://localhost:7103/api/ServiciosControllers/{Servicios.CodServicio}", Servicios);

            if (response.IsSuccessStatusCode)
            {
                Mensaje = "Proyecto editado correctamente";
                return RedirectToPage("Servicios");
            }
            else
            {
                return Page();
            }
        }
    }
}
