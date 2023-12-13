using GestorHorasDeServicios.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Net.Http;


namespace RazorPageGHDS.Pages.Trabajos
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
        public TrabajosDto Trabajo { get; set; }
        [TempData]
        public string Mensaje { get; set; }

        public async Task<IActionResult> OnGetAsync(int CodTrabajo)
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("NewSession");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"https://localhost:7103/api/TrabajosControllers/"+CodTrabajo);
            if (response.IsSuccessStatusCode)
            {
                Trabajo = await response.Content.ReadFromJsonAsync<TrabajosDto>();
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

            var response = await _httpClient.PutAsJsonAsync($"https://localhost:7103/api/TrabajosControllers/{Trabajo.CodTrabajo}", Trabajo);
            if (response.IsSuccessStatusCode)
            {
                Mensaje = "Trabajo editado correctamente";
                return RedirectToPage("Trabajos");
            }
            else
            {
                return Page();
            }
        }
    }
}