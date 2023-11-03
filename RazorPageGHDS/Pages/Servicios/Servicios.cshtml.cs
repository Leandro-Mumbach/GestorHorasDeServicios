using GestorHorasDeServicios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;

namespace RazorPageGHDS.Pages
{
    public class ServiciosModel : PageModel
    {
        public List<GestorHorasDeServicios.Models.Servicios> Servicios { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }

        [TempData]
        public string Mensaje { get; set; }



        //Metodo OnGet
        public async Task OnGetAsync(int pageNumber = 1, int pageSize = 5)
        {
            using (var httpClient = new HttpClient())
            {
                var token = "";
                var response = await httpClient.GetAsync($"https://localhost:7103/api/ServiciosControllers?pageNumber={pageNumber}&pageSize={pageSize}");

                if (response.IsSuccessStatusCode)
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    Servicios = await response.Content.ReadFromJsonAsync<List<GestorHorasDeServicios.Models.Servicios>>();

                    TotalPages = Servicios.Count;//(int)Math.Ceiling((double)Trabajos.Count / PageSize)
                    PageNumber = pageNumber;
                    PageSize = pageSize;
                }
                else
                {
                    Servicios = new List<GestorHorasDeServicios.Models.Servicios>();
                }
            }
        }



        //Metodo OnPost
        public async Task<IActionResult> OnPostBorrar(int CodServicio)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync($"https://localhost:7103/api/ServiciosControllers/{CodServicio}");
                if (response.IsSuccessStatusCode)
                {
                    Mensaje = "Proyecto eliminado correctamente";
                    return RedirectToPage("Servicios");
                }
                else
                {
                    return Page();
                }
            }
        }
    }
}
