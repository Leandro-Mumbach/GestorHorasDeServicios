using GestorHorasDeServicios.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageGHDS.Pages.Trabajos
{
    public class AgregarModel : PageModel
    {
        private readonly HttpClient _httpClient;
        public AgregarModel()
        {
            _httpClient = new HttpClient();
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
