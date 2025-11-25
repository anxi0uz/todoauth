using Microsoft.EntityFrameworkCore;
using todoapi.DataAccess;
using todoapi.Dto;
using todoapi.Models;

namespace todoapi.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly AppDbContext _context;

    public TodoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Todo>> GetAllAsync(int userid)
    {
        return await _context.Todos
            .Where(s=>s.UserId==userid)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<int> CreateTodoAsync(TodoRequest request)
    {
        var todo = new Todo()
        {
            UserId = request.userid,
            Description = request.description,
            Name = request.name
        };
        await _context.Todos.AddAsync(todo);
        await _context.SaveChangesAsync();
        return todo.Id;
    }

    public async Task<int> UpdateTodoAsync(TodoRequest request, int id)
    {
        await _context.Todos.Where(t => t.Id == id)
            .ExecuteUpdateAsync(t => t
                .SetProperty(s => s.Description, request.description)
                .SetProperty(s => s.Name, request.name)
                .SetProperty(s => s.UserId, request.userid));
        await _context.SaveChangesAsync();
        return id;
    }

    public async Task<int> DeleteTodoAsync(int id)
    {
        await _context.Todos.Where(p => p.Id == id)
            .ExecuteDeleteAsync();
        await _context.SaveChangesAsync();
        return id;
    }
}