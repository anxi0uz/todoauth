using Microsoft.AspNetCore.Mvc;
using todoapi.Dto;
using todoapi.Repositories;

namespace todoapi.Endpoints;

public static class TodoEndpoints
{
    public static IEndpointRouteBuilder MapTodoEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/todo");
        group.MapGet("/{id:int}", async (ITodoRepository repo, int id) => await repo.GetAllAsync(id)).RequireAuthorization();
        group.MapPost("/", async (ITodoRepository repo, [FromBody] TodoRequest request) => await repo.CreateTodoAsync(request)).RequireAuthorization();
        group.MapPut("/{id:int}", async (ITodoRepository repo, int id, [FromBody] TodoRequest request) => await repo.UpdateTodoAsync(request, id)).RequireAuthorization();
        group.MapDelete("/{id:int}",async(ITodoRepository repo, int id) => await repo.DeleteTodoAsync(id)).RequireAuthorization();
        return group;
    }
}