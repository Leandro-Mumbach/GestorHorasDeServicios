using System.ComponentModel.DataAnnotations;

namespace GestorHorasDeServicios.Models
{
    public class Servicios
    {
        [Key]
        public int CodServicio { get; set; }
        public string Descr { get; set; }
        public bool Estado { get; set; } //true, false
        public double ValorHora { get; set; }
    }
}
