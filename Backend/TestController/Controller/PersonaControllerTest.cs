using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;
using Backend.API.Domain;
using Backend.API.DataAccess;
using Backend.API.Controllers;
using FluentAssertions.Execution;
using FluentAssertions;


namespace TestController.Controller
{
        public class PersonaControllerTest : IDisposable
        {
            private readonly SqliteConnection connection = new("Filename=:memory:");
            private readonly ProyectoDBContext context;
            private readonly PersonasController personasController;


            public PersonaControllerTest()
            {

            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Testing");

            this.connection.Open();

                var options = new DbContextOptionsBuilder<ProyectoDBContext>()
                    .UseSqlite(this.connection)
                    .Options;

                this.context = new ProyectoDBContext(options);

                this.personasController = new PersonasController(this.context);
            }

            public void Dispose() => this.connection.Dispose();

            public class Metodo_GetAll : PersonaControllerTest
            {
                [Fact]
                public async Task Deberia_retornar_todas_las_cuatro_personas()
                {
                    // arrange
                    await this.InitAsync();

                    // act
                    ActionResult<IEnumerable<Persona>> actual = await this.personasController.GetAll();

                    // assert
                    actual.Value.Should().HaveCount(4);

                }

            }
    

            public class Metodo_GetById : PersonaControllerTest
            {
                [Fact]
                public async Task Deberia_retornar_personas_con_dni_igual_uno()
                {
                    // arrange
                    await this.InitAsync();

                    // act
                    ActionResult<Persona?> actual = await this.personasController.GetById(1);

                    // assert
                    actual.Value.Should().NotBeNull();

                    Persona personaUno = actual.Value!;

                    using (new AssertionScope())
                    {
                        personaUno.Dni.Should().Be(1);
                        personaUno.Nombre.Should().Be("Pedro Gomez");
                        personaUno.Telefono.Should().Be("123456");
                        personaUno.Email.Should().Be("pedro@gmail.com");
                    }

                }

                [Fact]
                public async Task Deberia_retornar_NotFound_cuando_persona_no_existe()
                {
                    // arrange
                    await this.InitAsync();

                    // act
                    ActionResult<Persona?> actual = await this.personasController.GetById(100);

                    // assert
                    actual.Result.Should().BeOfType<NotFoundResult>();
                    actual.Value.Should().BeNull();
                }
            }

            public class Metodo_Delete : PersonaControllerTest
            {
                [Fact]
                public async Task Deberia_borrar_personas_con_dni_igual_dos()
                {
                    // arrange
                    await this.InitAsync();

                    // act
                    ActionResult actual = await this.personasController.Delete(2);

                    // assert
                    actual.Should().BeOfType<NoContentResult>();

                    var PersonaDos = await this.context.FindAsync<Persona>(2);
                    PersonaDos.Should().BeNull();
                }
            }


        public class Metodo_Create : PersonaControllerTest
        {
            [Fact]
            public async Task Deberia_crear_nueva_persona()
            {
                // arrange
                await this.InitAsync();
                var nuevaPersona = new Persona
                {
                    Dni = 5,
                    Nombre = "Nueva Persona",
                    Telefono = "55555555",
                    Email = "nueva@gmail.com"
                };

                // act
                ActionResult<Persona> resultado = await this.personasController.Create(nuevaPersona);

                // assert
                resultado.Result.Should().BeOfType<CreatedAtActionResult>();

                var personaCreada = (CreatedAtActionResult)resultado.Result;
                personaCreada.Value.Should().BeEquivalentTo(nuevaPersona, options => options.ExcludingMissingMembers());
            }
        }

        public class Metodo_Update : PersonaControllerTest
        {
            [Fact]
            public async Task Deberia_actualizar_persona_existente()
            {
                // arrange
                await this.InitAsync();

                var personaExistente = await this.context.Personas.FindAsync(1);
                personaExistente.Nombre = "Nuevo Nombre";

                // act
                ActionResult resultado = await this.personasController.Update(personaExistente);

                // assert
                resultado.Should().BeOfType<NoContentResult>();

                var personaActualizada = await this.context.Personas.FindAsync(1);
                personaActualizada.Should().NotBeNull();
                personaActualizada.Should().BeEquivalentTo(personaExistente, options => options.ExcludingMissingMembers());
            }
        }

        private async Task InitAsync()
            {
                await this.context.Database.EnsureCreatedAsync();

                await this.context.AddRangeAsync(

                    new Persona()
                    {
                        Dni = 1,
                        Nombre = "Pedro Gomez",
                        Telefono = "123456",
                        Email = "pedro@gmail.com"
                    },
                    new Persona()
                    {
                        Dni = 2,
                        Nombre = "Juan Perez",
                        Telefono = "12121212",
                        Email = "juan@gmail.com"
                    },

                    new Persona()
                    {
                        Dni = 3,
                        Nombre = "Maria Lopez",
                        Telefono = "3333333",
                        Email = "maria@gmail.com"
                    },
                    new Persona()
                    {
                        Dni = 4,
                        Nombre = "Julia Fernandez",
                        Telefono = "45454545",
                        Email = "julia@gmail.com"
                    });

                await this.context.SaveChangesAsync();
            }
        }
}