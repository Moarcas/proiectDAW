using Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using proiectDAW.Models;
using proiectDAW.Repositories.UserRepository;

public class UserRepository : IUserRepository {
    protected readonly DataContext _context;
    protected readonly DbSet<User> _table;

    public UserRepository(DataContext context) {
        _context = context;
        _table = _context.Set<User>();
    }

    public async Task<User> Create(User user) {
        await _table.AddAsync(user);
        return user;
    }

    public async Task<bool> SaveChanges() {
        try {
            return await _context.SaveChangesAsync() > 1;
        }
        catch (NpgsqlException ex) {
            Console.WriteLine(ex.Message);
        }
        return false;
    }

    public User GetByEmail(string email) {
        return _table.FirstOrDefault(user => user.email == email)!;
    }

    public User GetById(Guid id) {
        return _table.FirstOrDefault(user => user.id == id)!;
    }

    public bool EmailExists(string email) {
        return _table.Any(user => user.email == email);
    }
}