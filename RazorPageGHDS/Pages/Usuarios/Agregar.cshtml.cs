using GestorHorasDeServicios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;

namespace RazorPageGHDS.Pages.Usuarios
{
    public class AgregarModel : PageModel
    {
        private readonly HttpClient _httpClient;
        public AgregarModel()
        {
            _httpClient = new HttpClient();
        }

        [BindProperty]
        public GestorHorasDeServicios.Models.Usuario User { get; set; }
        [TempData]
        public string Mensaje { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            var response = await _httpClient.PostAsJsonAsync($"https://localhost:7103/api/UsuarioControllers", User);

            if (response.IsSuccessStatusCode)
            {
                Mensaje = "Proyecto agregado correctamente";
                return RedirectToPage("Usuarios");
            }
            else
            {
                return Page();
            }
        }
    }
}
