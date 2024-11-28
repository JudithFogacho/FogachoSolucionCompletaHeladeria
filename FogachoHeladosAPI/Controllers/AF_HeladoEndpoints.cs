using Microsoft.EntityFrameworkCore;
using FogachoHeladosAPI.Data;
using FogachoHeladosAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace FogachoHeladosAPI.Controllers;

public static class AF_HeladoEndpoints
{
    public static void MapAF_HeladoEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/AF_Helado").WithTags(nameof(AF_Helado));

        group.MapGet("/", async (FogachoDBContext db) =>
        {
            return await db.AfHelados.ToListAsync();
        })
        .WithName("GetAllAF_Helados")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<AF_Helado>, NotFound>> (int af_idheladeria, FogachoDBContext db) =>
        {
            return await db.AfHelados.AsNoTracking()
                .FirstOrDefaultAsync(model => model.AF_IdHeladeria == af_idheladeria)
                is AF_Helado model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetAF_HeladoById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int af_idheladeria, AF_Helado aF_Helado, FogachoDBContext db) =>
        {
            var affected = await db.AfHelados
                .Where(model => model.AF_IdHeladeria == af_idheladeria)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.AF_IdHeladeria, aF_Helado.AF_IdHeladeria)
                    .SetProperty(m => m.AF_Nombre, aF_Helado.AF_Nombre)
                    .SetProperty(m => m.AF_Sabor, aF_Helado.AF_Sabor)
                    .SetProperty(m => m.AF_Categorias, aF_Helado.AF_Categorias)
                    .SetProperty(m => m.AF_Precio, aF_Helado.AF_Precio)
                    .SetProperty(m => m.AF_Queso, aF_Helado.AF_Queso)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateAF_Helado")
        .WithOpenApi();

        group.MapPost("/", async (AF_Helado aF_Helado, FogachoDBContext db) =>
        {
            db.AfHelados.Add(aF_Helado);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/AF_Helado/{aF_Helado.AF_IdHeladeria}",aF_Helado);
        })
        .WithName("CreateAF_Helado")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int af_idheladeria, FogachoDBContext db) =>
        {
            var affected = await db.AfHelados
                .Where(model => model.AF_IdHeladeria == af_idheladeria)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteAF_Helado")
        .WithOpenApi();
    }
}
