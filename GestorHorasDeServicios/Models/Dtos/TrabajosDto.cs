namespace GestorHorasDeServicios.Models.Dtos
{
    public class TrabajosDto
    {
        public DateTime Fecha { get; set; }
        public int CantHoras { get; set; }
        public double ValorHora { get; set; }
        public double Costo { get; set; }
    }
}
