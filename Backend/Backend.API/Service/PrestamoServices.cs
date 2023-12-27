using Backend.API.Domain;
using Grpc.Core;
using Backend.API.Protos;
using Backend.API.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Service
{
    public class PrestamoServices : PrestamoService.PrestamoServiceBase
    {
        private readonly ProyectoDBContext dBContext;

        public PrestamoServices(ProyectoDBContext context)
        {
            dBContext = context;
        }
        public override async Task<PrestamoResponse> CambiarEstado(CambiarEstadoPrestamoRequest request, ServerCallContext context)
        {
            try
            {
                int prestamoId = int.Parse(request.Id);

                Prestamo prestamo = await dBContext.Prestamos.FindAsync(prestamoId);

                if (prestamo == null)
                {
                    return new PrestamoResponse { Message = "Préstamo no encontrado" };
                }

                prestamo.Estado = "Devuelto";

                prestamo.FechaRetorno = DateTime.Now;

                await dBContext.SaveChangesAsync();

                return new PrestamoResponse { Message = "Préstamo marcado como devuelto correctamente" };
            }
            catch (Exception ex)
            {
                return new PrestamoResponse { Message = $"Error: {ex.Message}" };
            }


        }
    }
}
