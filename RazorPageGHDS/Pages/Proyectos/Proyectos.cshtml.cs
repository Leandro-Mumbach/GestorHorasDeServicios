using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageGHDS.Pages.Proyectos
{
    public class ProyectosModel : PageModel
    {
        public List<GestorHorasDeServicios.Models.Proyectos> proyectos { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }

        public async Task OnGetAsync(int pageNumber = 1, int pageSize = 5)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"https://localhost:7103/api/ProyectosControllers?pageNumber={pageNumber}&pageSize={pageSize}");

                if (response.IsSuccessStatusCode)
                {
                    proyectos = await response.Content.ReadFromJsonAsync<List<GestorHorasDeServicios.Models.Proyectos>>();

                    TotalPages = proyectos.Count;
                    PageNumber = pageNumber;
                    PageSize = pageSize;
                }
                else
                {
                    proyectos = new List<GestorHorasDeServicios.Models.Proyectos>();
                }
            }
        }

        public async Task<IActionResult> OnPostBorrar(int CodProyecto)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync($"https://localhost:7103/api/ProyectosControllers/{CodProyecto}");
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("Proyectos");
                }
                else
                {
                    return Page();
                }
            }
        }
    }
}
