using GestorHorasDeServicios.Models;
using GestorHorasDeServicios.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestorHorasDeServicios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProyectosControllers : Controller
    {
        private readonly IProyectosRepository _proyectosRepository;

        public ProyectosControllers(IProyectosRepository proyectosRepository)
        {
            _proyectosRepository = proyectosRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult>Get(int pageNumber = 1, int pageSize = 3)
        {
            var proyectos = await _proyectosRepository.GetAllProyectos(pageNumber, pageSize);
            return Ok(proyectos);
        }

        [HttpGet("{CodProyecto}")]
        [Authorize]
        public async Task<IActionResult>Get(int CodProyecto)
        {
            var proyecto = await _proyectosRepository.GetProyectosById(CodProyecto);
            if (proyecto == null)
            {
                return NotFound();
            }
            return Ok(proyecto);
        }

        [HttpGet("estado/{estado}")]
        [Authorize]
        public async Task<IActionResult> GetByEstado(int estado)
        {
            var proyectos = await _proyectosRepository.GetProyectosState(estado);
            return Ok(proyectos);
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public async Task<IActionResult>Post(Proyectos proyecto)
        {
            await _proyectosRepository.AddProyecto(proyecto);
            return CreatedAtAction(nameof(Get), new { CodProyecto = proyecto.CodProyecto }, proyecto);
        }


        [HttpPut("{CodProyecto}")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult>Put(int CodProyecto, Proyectos updatedProyecto)
        {
            var proyecto = await _proyectosRepository.GetProyectosById(CodProyecto);
            if (proyecto == null)
            {
                return NotFound();
            }
            proyecto.Nombre = updatedProyecto.Nombre;
            proyecto.Dirección = updatedProyecto.Dirección;
            proyecto.Estado = updatedProyecto.Estado;
            await _proyectosRepository.UpdateProyecto(proyecto);
            return NoContent();
        }

        [HttpDelete("{CodProyecto}")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult>Delete(int CodProyecto)
        {
            var proyecto = await _proyectosRepository.GetProyectosById(CodProyecto);
            if (proyecto == null)
            {
                return NotFound();
            }
            await _proyectosRepository.DeleteProyectoById(CodProyecto);
            return NoContent();
        }
    }
}
