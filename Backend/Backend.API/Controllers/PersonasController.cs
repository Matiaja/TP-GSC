using Backend.API.DataAccess;
using Backend.API.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly ProyectoDBContext context;

        public PersonasController(ProyectoDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> GetAll()
        {
            return await this.context.Personas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> GetById(int id)
        {
            var persona = await this.context.FindAsync<Persona>(id);
            if (persona == null)
            {
                return this.NotFound();
            }
            return persona;
        }

        [HttpPost]
        public async Task<ActionResult<Persona>> Create(Persona persona)
        {
            this.context.Add(persona);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction(nameof(GetById), new { id = persona.Dni }, persona);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Persona persona)
        {
            this.context.Update(persona);
            await this.context.SaveChangesAsync();
            return this.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var persona = await this.context.FindAsync<Persona>(id);

            if (persona == null)
            {
                return this.NotFound();
            }

            this.context.Remove(persona);
            await this.context.SaveChangesAsync();

            return this.NoContent();
        }
    }
}
