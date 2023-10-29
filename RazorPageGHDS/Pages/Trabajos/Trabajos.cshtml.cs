using AutoMapper;
using GestorHorasDeServicios.Models.Dtos;
using GestorHorasDeServicios.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace RazorPageGHDS.Pages.Trabajos
{
    public class TrabajosModel : PageModel
    {
        private readonly ITrabajosServices _trabajosServices;
        private readonly IMapper _mapper;

        public TrabajosModel(ITrabajosServices trabajosServices, IMapper mapper)
        {
            _trabajosServices = trabajosServices;
            _mapper = mapper;
        }
        public List<TrabajosDto> Trabajos { get; set; }

        public async Task OnGetAsync()
        {
            var trabajos = await _trabajosServices.GetAllTrabajos(1, 10);
            Trabajos = trabajos.Select(t => new TrabajosDto
            {
                CodTrabajo=t.CodTrabajo,
                Fecha = t.Fecha,
                CantHoras = t.CantHoras,
                ValorHora = t.ValorHora,
                Costo = t.Costo
            }).ToList();
        }
    }
}
