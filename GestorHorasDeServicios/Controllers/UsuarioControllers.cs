using AutoMapper;
using GestorHorasDeServicios.Models;
using GestorHorasDeServicios.Models.Dtos;
using GestorHorasDeServicios.Repository;
using GestorHorasDeServicios.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GestorHorasDeServicios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioControllers : Controller
    {
        private readonly IUsuarioServices _usuarioServices;
        public readonly IMapper _mapper;

        public UsuarioControllers(IUsuarioServices usuarioServices, IMapper mapper)
        {
            _usuarioServices = usuarioServices;
            _mapper = mapper;
        }
        

        [HttpGet]
        [Authorize]
        public async Task <IActionResult> Get(int pageNumber = 1, int pageSize = 5)
        {
            var usuarios =await _usuarioServices.ObtenerTodosUsuarios(pageNumber, pageSize);
            var userAuxDTO = _mapper.Map<List<UsuarioDto>>(usuarios); 
            return Ok(userAuxDTO);
        }

        [HttpGet("{CodUsuario}")]
        [Authorize]
        public async Task<IActionResult> Get(int CodUsuario)
        {
            var usuario =await _usuarioServices.ObtenerUsuario(CodUsuario);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            await _usuarioServices.AgregarUsuario(usuario);
            return CreatedAtAction(nameof(Get), new { CodUsuario = usuario.CodUsuario }, usuario);
        }


        [HttpPut("{CodUsuario}")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> Put(int CodUsuario, Usuario updatedUsuario)
        {
            var usuario = await _usuarioServices.ObtenerUsuario(CodUsuario);
            if (usuario == null)
            {
                return NotFound();
            }
            usuario.Nombre = updatedUsuario.Nombre;
            usuario.Dni = updatedUsuario.Dni;
            usuario.Tipo = updatedUsuario.Tipo;
            usuario.Contraseña = updatedUsuario.Contraseña;
            await _usuarioServices.EditarUsuario(usuario);
            return NoContent();
        }

        [HttpDelete("{CodUsuario}")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> Delete(int CodUsuario)
        {
            var usuario = await _usuarioServices.ObtenerUsuario(CodUsuario);
            if (usuario == null)
            {
                return NotFound();
            }
            else if (usuario.Tipo == 1)
            {
                await _usuarioServices.BorrarUsuario(CodUsuario);
            }
            return NoContent();
        }
    }
}
