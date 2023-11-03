using GestorHorasDeServicios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageGHDS.Pages.Proyectos
{
    public class EditarModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public EditarModel()
        {
            _httpClient = new HttpClient();
        }

        [BindProperty]
        public GestorHorasDeServicios.Models.Proyectos Proyecto { get; set; }
        [TempData]
        public string Mensaje { get; set; }

        public async Task<IActionResult> OnGetAsync(int CodProyecto)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7103/api/ProyectosControllers/" + CodProyecto);

            if (response.IsSuccessStatusCode)
            {
                Proyecto = await response.Content.ReadFromJsonAsync<GestorHorasDeServicios.Models.Proyectos>();
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
            var response = await _httpClient.PutAsJsonAsync($"https://localhost:7103/api/ProyectosControllers/{Proyecto.CodProyecto}", Proyecto);

            if (response.IsSuccessStatusCode)
            {
                Mensaje = "Proyecto editado correctamente";
                return RedirectToPage("Proyectos");
            }
            else
            {
                return Page();
            }
        }
    }
}
