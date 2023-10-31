using GestorHorasDeServicios.Models;
using GestorHorasDeServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageGHDS.Pages
{
    public class ServiciosModel : PageModel
    {
        private readonly IServiciosServices _serviciosServices;
        public ServiciosModel(IServiciosServices proyectosServices)
        {
            _serviciosServices = proyectosServices;
        }
        public List<GestorHorasDeServicios.Models.Servicios> Servicios { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }

        public async Task OnGetAsync(int pageNumber = 1, int pageSize = 2)
        {
            var servicios = await _serviciosServices.GetAllServicios(pageNumber, pageSize);
            Servicios = servicios.ToList();

            TotalPages = Servicios.Count;

            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public async Task<IActionResult> OnPostBorrar(int CodTrabajo)
        {
            await _serviciosServices.DeleteServicioById(CodTrabajo);
            return RedirectToPage("Servicios");
        }
    }
}
