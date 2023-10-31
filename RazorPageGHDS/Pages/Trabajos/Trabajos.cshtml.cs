using GestorHorasDeServicios.Models.Dtos;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace RazorPageGHDS.Pages.Trabajos
{
    public class TrabajosModel : PageModel
    {
        public List<TrabajosDto> Trabajos { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public async Task OnGetAsync(int pageNumber = 1, int pageSize = 2)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"https://localhost:7103/api/TrabajosControllers?pageNumber={pageNumber}&pageSize={pageSize}");

                if (response.IsSuccessStatusCode)
                {
                    Trabajos = await response.Content.ReadFromJsonAsync<List<TrabajosDto>>();

                    TotalPages = Trabajos.Count;//(int)Math.Ceiling((double)Trabajos.Count / PageSize)
                    PageNumber = pageNumber;
                    PageSize = pageSize;
                }
                else
                {
                    Trabajos = new List<TrabajosDto>();
                }
            }
        }
    }
}
