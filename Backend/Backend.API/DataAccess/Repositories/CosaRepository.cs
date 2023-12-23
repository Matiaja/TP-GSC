using Backend.API.Domain;

namespace Backend.API.DataAccess.Repositories
{
    public class CosaRepository : Repository<Cosa>
    {
        public CosaRepository(ProyectoDBContext dbContext) : base(dbContext)
        {
        }
    }
}
