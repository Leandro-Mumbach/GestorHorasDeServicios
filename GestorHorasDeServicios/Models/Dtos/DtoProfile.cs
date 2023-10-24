using AutoMapper;

namespace GestorHorasDeServicios.Models.Dtos
{
    public class DtoProfile : Profile
    {
        public DtoProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<Trabajos, TrabajosDto>();
        }
    }
}
