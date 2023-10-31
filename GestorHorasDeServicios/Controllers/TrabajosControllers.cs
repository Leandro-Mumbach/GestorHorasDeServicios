using GestorHorasDeServicios.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using GestorHorasDeServicios.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using GestorHorasDeServicios.Services;

namespace GestorHorasDeServicios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrabajosControllers : Controller
    {
        private readonly ITrabajosServices _trabajosServices;
        public readonly IMapper _mapper;

        public TrabajosControllers(ITrabajosServices trabajosServices, IMapper mapper)
        {
            _trabajosServices = trabajosServices;
            _mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Get([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var trabajos = await _trabajosServices.GetAllTrabajos(pageNumber, pageSize);
            var trabajoAuxDTO = _mapper.Map<List<TrabajosDto>>(trabajos);
            return Ok(trabajoAuxDTO);
        }

        [HttpGet("{CodTrabajo}")]
        //[Authorize]
        public async Task<IActionResult> GetById(int CodTrabajo)
        {
            var trabajo = await _trabajosServices.GetTrabajosById(CodTrabajo);
            if (trabajo == null)
            {
                return NotFound();
            }
            return Ok(trabajo);
        }

        [HttpPost]
        //[Authorize(Roles = "1")]
        public async Task<IActionResult>Post(Trabajos trabajo)
        {
            await _trabajosServices.AddTrabajos(trabajo);
            return CreatedAtAction(nameof(Get), new { CodTrabajo = trabajo.CodTrabajo }, trabajo);
        }


        [HttpPut("{CodTrabajo}")]
        //[Authorize(Roles = "1")]
        public async Task<IActionResult>Put(int CodTrabajo, Trabajos updatedTrabajo)
        {
            var trabajo = await _trabajosServices.GetTrabajosById(CodTrabajo);
            if (trabajo == null)
            {
                return NotFound();
            }
            trabajo.Fecha = updatedTrabajo.Fecha;
            trabajo.CantHoras = updatedTrabajo.CantHoras;
            trabajo.ValorHora = updatedTrabajo.ValorHora;
            trabajo.Costo = updatedTrabajo.Costo;
            await _trabajosServices.UpdateTrabajo(trabajo);
            return NoContent();
        }

        [HttpDelete("{CodTrabajo}")]
        //[Authorize(Roles = "1")]
        public async Task<IActionResult>Delete(int CodTrabajo)
        {
            var trabajo = await _trabajosServices.GetTrabajosById(CodTrabajo);
            if (trabajo == null)
            {
                return NotFound();
            }
            await _trabajosServices.DeleteTrabajoById(CodTrabajo);
            return NoContent();
        }
    }
}
