using GestorHorasDeServicios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageGHDS.Pages.Proyectos
{
    public class AgregarModel : PageModel
    {
        private readonly HttpClient _httpClient;
        public AgregarModel()
        {
            _httpClient = new HttpClient();
        }

        [BindProperty]
        public GestorHorasDeServicios.Models.Proyectos Proyecto { get; set; }
        [TempData]
        public string Mensaje { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            var response = await _httpClient.PostAsJsonAsync($"https://localhost:7103/api/ProyectosControllers", Proyecto);

            if (response.IsSuccessStatusCode)
            {
                Mensaje = "Proyecto agregado correctamente";
                return RedirectToPage("Proyectos");
            }
            else
            {
                return Page();
            }
        }
    }
}
