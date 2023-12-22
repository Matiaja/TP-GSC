namespace Backend.API.Domain
{
    public class Cosa
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaActual { get; set; }
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
    }
}
