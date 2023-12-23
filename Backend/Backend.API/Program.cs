using Backend.API.DataAccess;
using Backend.API.Domain;
using Microsoft.EntityFrameworkCore;

//using hace que se llame automaticamente al dispose
using var context = new ProyectoDBContext();

var categorias = await context.Categorias.ToListAsync();

/*

WriteToConsole(categorias);

static void WriteToConsole(IEnumerable<Categoria> categorias)
{
    foreach (Categoria categoria in categorias)
    {
        string json = System.Text.Json.JsonSerializer.Serialize(categoria);
        Console.WriteLine(json);
    }
}

*/