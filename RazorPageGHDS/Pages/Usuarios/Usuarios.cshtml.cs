using GestorHorasDeServicios.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;

namespace RazorPageGHDS.Pages
{
    public class UsuariosModel : PageModel
    {
        public List<UsuarioDto> Usuario { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }



        //Metodo OnGet
        public async Task OnGetAsync(int pageNumber = 1, int pageSize = 5)
        {
            using (var httpClient = new HttpClient())
            {
                var token = "";
                var response = await httpClient.GetAsync($"https://localhost:7103/api/UsuarioControllers?pageNumber={pageNumber}&pageSize={pageSize}");

                if (response.IsSuccessStatusCode)
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    Usuario = await response.Content.ReadFromJsonAsync<List<UsuarioDto>>();

                    TotalPages = Usuario.Count;//(int)Math.Ceiling((double)Trabajos.Count / PageSize)
                    PageNumber = pageNumber;
                    PageSize = pageSize;
                }
                else
                {
                    Usuario = new List<UsuarioDto>();
                }
            }
        }



        //Metodo OnPost
        public async Task<IActionResult> OnPostBorrar(int CodUsuario)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync($"https://localhost:7103/api/UsuarioControllers/{CodUsuario}");
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("Usuarios");
                }
                else
                {
                    return Page();
                }
            }
        }
    }
}
