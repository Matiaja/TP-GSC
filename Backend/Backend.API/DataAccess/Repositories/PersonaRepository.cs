using Backend.API.Domain;

namespace Backend.API.DataAccess.Repositories
{
    public class PersonaRepository : Repository<Persona>
    {
        public PersonaRepository(ProyectoDBContext dbContext) : base(dbContext)
        {
        }
    }
}
