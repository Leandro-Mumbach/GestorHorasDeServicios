using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageGHDS.Pages.Servicios
{
    public class AgregarModel : PageModel
    {
        private readonly HttpClient _httpClient;
        public AgregarModel()
        {
            _httpClient = new HttpClient();
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
