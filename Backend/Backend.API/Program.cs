using Backend.API.DataAccess;
using Backend.API.Domain;
using Microsoft.EntityFrameworkCore;

var context = new ProyectoDBContext();

var categorias = await context.Categorias.ToListAsync();

WriteToConsole(categorias);

context.Dispose();

static void WriteToConsole(IEnumerable<Categoria> categorias)
{
    foreach (Categoria categoria in categorias)
    {
        string json = System.Text.Json.JsonSerializer.Serialize(categoria);
        Console.WriteLine();
    }
}