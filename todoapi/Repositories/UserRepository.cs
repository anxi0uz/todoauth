using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using todoapi.DataAccess;
using todoapi.Dto;
using todoapi.Models;

namespace todoapi.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserRepository(AppDbContext context,IPasswordHasher<User> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _context.Users.AsNoTracking().ToListAsync();
    }

    public async Task<User?> GetUser(int id)
    {
        return await _context.Users.Where(p=>p.Id==id).FirstOrDefaultAsync();
    }
    public async Task<int> CreateUser(UserRequest request)
    {
        var user = new User()
        {
            Password = _passwordHasher.HashPassword(null,request.password),
            Username = request.username
        };
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user.Id;
    }

    public async Task<int> UpdateUser(UserRequest request,int id)
    {
        await _context.Users
            .Where(u => u.Id == id)
            .ExecuteUpdateAsync(x => x
                .SetProperty(x => x.Password, _passwordHasher.HashPassword(null,request.password))
                .SetProperty(s => s.Username, request.username));
        await _context.SaveChangesAsync();
        return id;
    }

    public async Task<int> DeleteUser(int id)
    {
        await _context.Users.Where(p => p.Id == id)
            .ExecuteDeleteAsync();
        await _context.SaveChangesAsync();
        return id;
    }
}