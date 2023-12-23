using System.ComponentModel.DataAnnotations;

namespace Backend.API.Domain
{
    public class Persona
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}
