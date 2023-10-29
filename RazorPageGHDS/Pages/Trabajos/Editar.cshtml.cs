using GestorHorasDeServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageGHDS.Pages.Trabajos
{
    public class EditarModel : PageModel
    {
        private readonly ITrabajosServices _trabajosServices;
        public EditarModel(ITrabajosServices trabajosServices)
        {
            _trabajosServices = trabajosServices;
        }
        [BindProperty]
        public GestorHorasDeServicios.Models.Trabajos trabajo { get; set; }


        public async Task OnGet(int CodTrabajo)
        {
            trabajo = await _trabajosServices.GetTrabajosById(CodTrabajo);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _trabajosServices.UpdateTrabajo(trabajo);
                return RedirectToPage("Trabajos");
            }

            return RedirectToPage();
        }
    }
}
