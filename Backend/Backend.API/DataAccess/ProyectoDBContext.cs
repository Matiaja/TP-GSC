using Backend.API.Domain;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.DataAccess
{
    public class ProyectoDBContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cosa> Cosas { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }

        public ProyectoDBContext() => this.Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocaldb;Database=PrestamosDb;Integrated Security=True;");
        }
    }
}
