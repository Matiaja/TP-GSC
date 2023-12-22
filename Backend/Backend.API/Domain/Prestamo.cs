namespace Backend.API.Domain
{
    public class Prestamo
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime? FechaRetorno { get; set; }
        public string Estado { get; set; }
        public int IdPersona { get; set; }
        public int IdCosa { get; set; }
        public Persona Persona { get; set; }
        public Cosa Cosa { get; set; }
    }
}
