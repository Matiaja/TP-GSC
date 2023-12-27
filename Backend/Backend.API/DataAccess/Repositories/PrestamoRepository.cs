using Backend.API.Domain;

namespace Backend.API.DataAccess.Repositories
{
    public class PrestamoRepository : Repository<Prestamo>
    {
        public PrestamoRepository(ProyectoDBContext dbContext) : base(dbContext)
        {
        }

        public async Task CambiarEstado(Prestamo prestamo) { }
    }
}
