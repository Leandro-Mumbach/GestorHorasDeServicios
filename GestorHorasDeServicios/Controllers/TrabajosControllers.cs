using GestorHorasDeServicios.Models;
using GestorHorasDeServicios.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using GestorHorasDeServicios.Models.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace GestorHorasDeServicios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrabajosControllers : Controller
    {
        private readonly ITrabajosRepository _trabajosRepository;
        public readonly IMapper _mapper;

        public TrabajosControllers(ITrabajosRepository trabajosRepository, IMapper mapper)
        {
            _trabajosRepository = trabajosRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get(int pageNumber = 1, int pageSize = 3)
        {
            var trabajos = await _trabajosRepository.GetAllTrabajos(pageNumber, pageSize);
            var trabajoAuxDTO = _mapper.Map<List<TrabajosDto>>(trabajos);
            return Ok(trabajoAuxDTO);
        }

        [HttpGet("{CodTrabajo}")]
        [Authorize]
        public async Task<IActionResult>Get(int CodTrabajo)
        {
            var trabajo = await _trabajosRepository.GetTrabajosById(CodTrabajo);
            if (trabajo == null)
            {
                return NotFound();
            }
            return Ok(trabajo);
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public async Task<IActionResult>Post(Trabajos trabajo)
        {
            await _trabajosRepository.AddTrabajos(trabajo);
            return CreatedAtAction(nameof(Get), new { CodTrabajo = trabajo.CodTrabajo }, trabajo);
        }


        [HttpPut("{CodTrabajo}")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult>Put(int CodTrabajo, Trabajos updatedTrabajo)
        {
            var trabajo = await _trabajosRepository.GetTrabajosById(CodTrabajo);
            if (trabajo == null)
            {
                return NotFound();
            }
            trabajo.Fecha = updatedTrabajo.Fecha;
            trabajo.CantHoras = updatedTrabajo.CantHoras;
            trabajo.ValorHora = updatedTrabajo.ValorHora;
            trabajo.Costo = updatedTrabajo.Costo;
            await _trabajosRepository.UpdateTrabajo(trabajo);
            return NoContent();
        }

        [HttpDelete("{CodTrabajo}")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult>Delete(int CodTrabajo)
        {
            var trabajo = await _trabajosRepository.GetTrabajosById(CodTrabajo);
            if (trabajo == null)
            {
                return NotFound();
            }
            await _trabajosRepository.DeleteTrabajoById(CodTrabajo);
            return NoContent();
        }
    }
}
