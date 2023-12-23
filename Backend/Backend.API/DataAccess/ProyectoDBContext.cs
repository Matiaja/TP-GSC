using Backend.API.Domain;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Backend.API.DataAccess
{
    public class ProyectoDBContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cosa> Cosas { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }

        public ProyectoDBContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocaldb;Database=PrestamosDb;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>(p =>
            {
                p.HasKey(p => p.Dni);
                p.Property(p => p.Dni).ValueGeneratedNever();
            });

            modelBuilder.Entity<Usuario>(u =>
            {
                u.HasKey(u => u.NombreUsuario);
                u.Property(u => u.NombreUsuario).ValueGeneratedNever();
            });
        }
    }
}
