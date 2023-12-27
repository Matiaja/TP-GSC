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
        public DbSet<Usuario> Usuarios { get; set; }

        public ProyectoDBContext(DbContextOptions options) : base(options){ }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=PrestamosDb");
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=PrestamosDb");
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

                u.HasData(
                    new Usuario()
                    {
                        NombreUsuario = "Admin",
                        Clave = "1234",
                    });
            });

            modelBuilder.Entity<Categoria>(c =>
            {
                c.HasIndex(cat => cat.Descripcion).IsUnique();
                c.Property(cat => cat.FechaActual).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Cosa>(c =>
            {
                c.HasIndex(cosa => cosa.Descripcion).IsUnique();
                c.Property(cosa => cosa.FechaActual).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Prestamo>(p =>
            {
                p.Property(pre => pre.Fecha).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

        }
    }
}
