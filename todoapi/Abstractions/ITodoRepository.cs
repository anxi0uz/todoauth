using todoapi.Dto;
using todoapi.Models;

namespace todoapi.Repositories;

public interface ITodoRepository
{
    Task<List<Todo>> GetAllAsync(int userid);
    Task<int> CreateTodoAsync(TodoRequest request);
    Task<int> UpdateTodoAsync(TodoRequest request, int id);
    Task<int> DeleteTodoAsync(int id);
}