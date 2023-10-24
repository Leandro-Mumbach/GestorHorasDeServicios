using System.ComponentModel.DataAnnotations.Schema;

namespace GestorHorasDeServicios.Models
{
    public class Login
    {
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
    }
}
