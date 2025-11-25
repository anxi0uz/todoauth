using Microsoft.AspNetCore.Mvc;
using todoapi.Dto;
using todoapi.Models;
using todoapi.Repositories;
using todoapi.Services;

namespace todoapi.Endpoints;

public static class UserEndpoints
{
    public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/user");
        group.MapGet("/", async (IUserRepository repository) => await repository.GetAllUsers());
        group.MapPost("/login", async (IAuthService service, [FromBody] User user) => await service.Login(user));
        group.MapPut("/{id:int}", async (IUserRepository repository, int id, [FromBody] UserRequest request) => await repository.UpdateUser(request, id));
        group.MapDelete("/{id:int}", async (IUserRepository repository, int id) => await repository.DeleteUser(id));
        group.MapPost("/register", async (IUserRepository repository, [FromBody] UserRequest request) => await repository.CreateUser(request));
        return builder;
    }
}