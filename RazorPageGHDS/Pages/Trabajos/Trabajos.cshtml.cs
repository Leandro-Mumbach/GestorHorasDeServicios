using GestorHorasDeServicios.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;

namespace RazorPageGHDS.Pages.Trabajos
{
    public class TrabajosModel : PageModel
    {
        public List<TrabajosDto> Trabajos { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }



//Metodo OnGet
        public async Task OnGetAsync(int pageNumber = 1, int pageSize = 5)
        {
            using (var httpClient = new HttpClient())
            {
                var token = "";
                var response = await httpClient.GetAsync($"https://localhost:7103/api/TrabajosControllers?pageNumber={pageNumber}&pageSize={pageSize}");

                if (response.IsSuccessStatusCode)
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    Trabajos = await response.Content.ReadFromJsonAsync<List<TrabajosDto>>();

                    TotalPages = Trabajos.Count;
                    PageNumber = pageNumber;
                    PageSize = pageSize;
                }
                else
                {
                    Trabajos = new List<TrabajosDto>();
                }
            }
        }



//Metodo OnPost
        public async Task<IActionResult> OnPostBorrar(int CodTrabajo)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync($"https://localhost:7103/api/TrabajosControllers/{CodTrabajo}");
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("Trabajos");
                }
                else
                {
                    return Page();
                }
            }
        }
    }
}
