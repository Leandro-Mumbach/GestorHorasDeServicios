namespace GestorHorasDeServicios.Models
{
    public class JWTSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string ExpirationMinutes { get; set; }
    }
}
