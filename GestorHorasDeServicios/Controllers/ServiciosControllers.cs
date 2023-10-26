using GestorHorasDeServicios.Models;
using GestorHorasDeServicios.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestorHorasDeServicios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiciosControllers : Controller
    {
        private readonly IServiciosRepository _serviciosRepository;

        public ServiciosControllers(IServiciosRepository serviciosRepository)
        {
            _serviciosRepository = serviciosRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get(int pageNumber = 1, int pageSize = 5)
        {
            var servicios = await _serviciosRepository.GetAllServicios(pageNumber, pageSize);
            return Ok(servicios);
        }

        [HttpGet("{CodServicio}")]
        [Authorize]
        public async Task <IActionResult> Get(int CodServicio)
        {
            var servicio = await _serviciosRepository.GetServiciosById(CodServicio);
            if(servicio == null)
            {
                return NotFound();
            }
            return Ok(servicio);
        }

        [HttpGet("estado/{Estado}")]
        [Authorize]
        public async Task<IActionResult> Get(bool Estado)
        {
            var servicios = await _serviciosRepository.GetServiciosState(Estado);
            return Ok(servicios);
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public async Task <IActionResult> Post(Servicios servicio)
        {
            await _serviciosRepository.AddServicio(servicio);
            return CreatedAtAction(nameof(Get), new { CodServicio = servicio.CodServicio }, servicio);
        }


        [HttpPut("{CodServicio}")]
        [Authorize(Roles = "1")]
        public async Task <IActionResult> Put(int CodServicio, Servicios updatedServicio)
        {
            var servicio = await _serviciosRepository.GetServiciosById(CodServicio);
            if(servicio == null)
            {
                return NotFound();
            }
            servicio.Descr = updatedServicio.Descr;
            servicio.Estado = updatedServicio.Estado;
            servicio.ValorHora = updatedServicio.ValorHora;
            await _serviciosRepository.UpdateServicio(servicio);
            return NoContent();
        }

        [HttpDelete("{CodServicio}")]
        [Authorize(Roles = "1")]
        public async Task <IActionResult> Delete(int CodServicio)
        {
            var servicio = await _serviciosRepository.GetServiciosById(CodServicio);
            if(servicio == null)
            {
                return NotFound();
            }
            await _serviciosRepository.DeleteServicioById(CodServicio);
            return NoContent();
        }
    }
}
