using GestorHorasDeServicios.Models;
using GestorHorasDeServicios.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestorHorasDeServicios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProyectosControllers : Controller
    {
        private readonly IProyectosServices _proyectosServices;

        public ProyectosControllers(IProyectosServices proyectosServices)
        {
            _proyectosServices = proyectosServices;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult>Get(int pageNumber = 1, int pageSize = 3)
        {
            var proyectos = await _proyectosServices.GetAllProyectos(pageNumber, pageSize);
            return Ok(proyectos);
        }

        [HttpGet("{CodProyecto}")]
        [Authorize]
        public async Task<IActionResult>Get(int CodProyecto)
        {
            var proyecto = await _proyectosServices.GetProyectosById(CodProyecto);
            if (proyecto == null)
            {
                return NotFound();
            }
            return Ok(proyecto);
        }

        [HttpGet("estado/{estado}")]
        [Authorize]
        public async Task<IActionResult> GetProyectosEstado(int estado)
        {
            var proyectos = await _proyectosServices.GetProyectosByEstado(estado);
            return Ok(proyectos);
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public async Task<IActionResult>Post(Proyectos proyecto)
        {
            await _proyectosServices.AddProyecto(proyecto);
            return CreatedAtAction(nameof(Get), new { CodProyecto = proyecto.CodProyecto }, proyecto);
        }


        [HttpPut("{CodProyecto}")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult>Put(int CodProyecto, Proyectos updatedProyecto)
        {
            var proyecto = await _proyectosServices.GetProyectosById(CodProyecto);
            if (proyecto == null)
            {
                return NotFound();
            }
            proyecto.Nombre = updatedProyecto.Nombre;
            proyecto.Dirección = updatedProyecto.Dirección;
            proyecto.Estado = updatedProyecto.Estado;
            await _proyectosServices.UpdateProyecto(proyecto);
            return NoContent();
        }

        [HttpDelete("{CodProyecto}")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult>Delete(int CodProyecto)
        {
            var proyecto = await _proyectosServices.GetProyectosById(CodProyecto);
            if (proyecto == null)
            {
                return NotFound();
            }
            await _proyectosServices.DeleteProyectoById(CodProyecto);
            return NoContent();
        }
    }
}
