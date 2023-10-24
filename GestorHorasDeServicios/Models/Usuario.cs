using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorHorasDeServicios.Models
{
    public class Usuario
    {
        [Key]
        public int CodUsuario {  get; set; }
        public string Nombre { get; set; }
        public int Dni {  get; set; }
        public int Tipo { get; set; } //1 = admin, 2 = consultor
        public string Contraseña { get; set; }
    }
}
