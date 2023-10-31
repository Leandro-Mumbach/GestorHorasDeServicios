namespace GestorHorasDeServicios.Models.Dtos
{
    public class UsuarioDto
    {
        public int CodUsuario { get; set; }
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public int Tipo { get; set; } //1 = admin, 2 = consultor
    }
}
