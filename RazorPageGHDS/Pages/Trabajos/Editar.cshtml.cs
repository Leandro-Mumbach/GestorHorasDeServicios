using GestorHorasDeServicios.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace RazorPageGHDS.Pages.Trabajos
{
    public class EditarModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public EditarModel()
        {
            _httpClient = new HttpClient();
        }

        [BindProperty]
        public TrabajosDto Trabajo { get; set; }
        [TempData]
        public string Mensaje { get; set; }

        public async Task<IActionResult> OnGetAsync(int CodTrabajo)
        {
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