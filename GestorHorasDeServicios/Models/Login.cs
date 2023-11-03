using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorHorasDeServicios.Models
{
    public class Login
    {
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Contraseña { get; set; }
    }
}
