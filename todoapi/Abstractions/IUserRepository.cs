using todoapi.Dto;
using todoapi.Models;

namespace todoapi.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllUsers();
    Task<User?> GetUser(string username);
    Task<int> CreateUser(UserRequest request);
    Task<int> UpdateUser(UserRequest request,int id);
    Task<int> DeleteUser(int id);
}