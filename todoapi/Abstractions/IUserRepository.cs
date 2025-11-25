using todoapi.Dto;
using todoapi.Models;

namespace todoapi.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllUsers();
    Task<User?> GetUser(int id);
    Task<int> CreateUser(UserRequest request);
    Task<int> UpdateUser(UserRequest request,int id);
    Task<int> DeleteUser(int id);
}