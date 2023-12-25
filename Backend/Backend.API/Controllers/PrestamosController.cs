using Backend.API.DataAccess;
using Backend.API.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrestamosController : ControllerBase
    {
        private readonly ProyectoDBContext context;

        public PrestamosController(ProyectoDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prestamo>>> GetAll()
        {
            return await this.context.Prestamos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Prestamo>> GetById(int id)
        {
            var prestamo = await this.context.FindAsync<Prestamo>(id);
            if (prestamo == null)
            {
                return this.NotFound();
            }
            return prestamo;
        }

        [HttpPost]
        public async Task<ActionResult<Prestamo>> Create(Prestamo prestamo)
        {

            Cosa cosa = await this.context.Cosas.FindAsync(prestamo.IdCosa);

            Persona persona = await this.context.Personas.FindAsync(prestamo.IdPersona);

            if (cosa == null || persona == null)
            {
                return BadRequest("No se encontró la Cosa o la Persona.");
            }

            prestamo.Persona = persona;
            prestamo.Cosa = cosa;

            this.context.Add(prestamo);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction(nameof(GetById), new { id = prestamo.Id }, prestamo);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Prestamo prestamo)
        {
            Cosa cosa = await this.context.Cosas.FindAsync(prestamo.IdCosa);

            Persona persona = await this.context.Personas.FindAsync(prestamo.IdPersona);

            if (cosa == null || persona == null)
            {
                return BadRequest("No se encontró la Cosa o la Persona.");
            }

            prestamo.Persona = persona;
            prestamo.Cosa = cosa;

            this.context.Update(prestamo);
            await this.context.SaveChangesAsync();
            return this.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var prestamo = await this.context.FindAsync<Prestamo>(id);

            if (prestamo == null)
            {
                return this.NotFound();
            }

            this.context.Remove(prestamo);
            await this.context.SaveChangesAsync();

            return this.NoContent();
        }
    }
}
