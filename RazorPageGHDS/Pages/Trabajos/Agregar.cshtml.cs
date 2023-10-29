using GestorHorasDeServicios.Models;
using GestorHorasDeServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutoMapper;

namespace RazorPageGHDS.Pages.Trabajos
{
    public class AgregarModel : PageModel
    {
        private readonly ITrabajosServices _trabajosServices;

        [BindProperty]
        public GestorHorasDeServicios.Models.Trabajos trabajo { get; set; }

        public AgregarModel(ITrabajosServices trabajosServices)
        {
            _trabajosServices = trabajosServices;
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _trabajosServices.AddTrabajos(trabajo);
                return RedirectToPage("Trabajos");
            }

            return Page();
        }
    }
}
