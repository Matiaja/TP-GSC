using Backend.API.DataAccess;
using Backend.API.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ProyectoDBContext context;

        public CategoriasController(ProyectoDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetAll()
        {
            return await this.context.Categorias.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetById(int id)
        {
            var categoria = await this.context.FindAsync<Categoria>(id);
            if (categoria == null)
            {
                return this.NotFound();
            }
            return categoria;
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> Create(Categoria categoria)
        {
            this.context.Add(categoria);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction(nameof(GetById), new { id = categoria.Id }, categoria);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Categoria categoria)
        {
            this.context.Update(categoria);
            await this.context.SaveChangesAsync();
            return this.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var categoria = await this.context.FindAsync<Categoria>(id);

            if (categoria == null)
            {
                return this.NotFound();
            }

            this.context.Remove(categoria);
            await this.context.SaveChangesAsync();

            return this.NoContent();
        }

    }
}
