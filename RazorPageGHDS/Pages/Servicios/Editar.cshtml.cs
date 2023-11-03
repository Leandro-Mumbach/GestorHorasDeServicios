using GestorHorasDeServicios.Models;
using GestorHorasDeServicios.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageGHDS.Pages.Servicios
{
    public class EditarModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public EditarModel()
        {
            _httpClient = new HttpClient();
        }

        [BindProperty]
        public GestorHorasDeServicios.Models.Servicios Servicios { get; set; }
        [TempData]
        public string Mensaje { get; set; }

        public async Task<IActionResult> OnGetAsync(int CodServicio)
        {
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
