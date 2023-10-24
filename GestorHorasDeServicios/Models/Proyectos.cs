using System.ComponentModel.DataAnnotations;

namespace GestorHorasDeServicios.Models
{
    public class Proyectos
    {
        [Key]
        public int CodProyecto { get; set; }
        public string Nombre { get; set; }
        public string Dirección { get; set;}
        public int Estado { get; set; } //1–Pendiente, 2–Confirmado, 3–Terminado)
    }
}
