using Backend.API.DataAccess;
using Backend.API.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CosasController : ControllerBase
    {
        private readonly ProyectoDBContext context;

        public CosasController(ProyectoDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cosa>>> GetAll()
        {
            return await this.context.Cosas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cosa>> GetById(int id)
        {
            var cosa = await this.context.FindAsync<Cosa>(id);
            if (cosa == null)
            {
                return this.NotFound();
            }
            return cosa;
        }

        [HttpPost]
        public async Task<ActionResult<Cosa>> Create(Cosa cosa)
        {
            Categoria categoria = await this.context.Categorias.FindAsync(cosa.IdCategoria);


            if (categoria == null)
            {
                return BadRequest("No se encontró la Categoria");
            }

            cosa.Categoria = categoria;

            this.context.Add(cosa);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction(nameof(GetById), new { id = cosa.Id }, cosa);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Cosa cosa)
        {
            Categoria categoria = await this.context.Categorias.FindAsync(cosa.IdCategoria);


            if (categoria == null)
            {
                return BadRequest("No se encontró la Categoria");
            }

            cosa.Categoria = categoria;
            

            this.context.Update(cosa);
            await this.context.SaveChangesAsync();
            return this.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var cosa = await this.context.FindAsync<Cosa>(id);

            if (cosa == null)
            {
                return this.NotFound();
            }

            this.context.Remove(cosa);
            await this.context.SaveChangesAsync();

            return this.NoContent();
        }
    }
}
