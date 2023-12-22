using Backend.API.DataAccess.Generic;
using Backend.API.Domain;

namespace Backend.API.DataAccess.Repositories
{
    public class CategoriaRepository : Repository<Categoria>
    {
        public CategoriaRepository(ProyectoDBContext dbContext) : base(dbContext)
        {
        }
    }
}
