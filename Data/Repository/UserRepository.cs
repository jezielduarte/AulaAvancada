using Data.SqLite;
using Domain.Entity;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {
        ContextSQLite _context;

        public UserRepository(ContextSQLite context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await Task.FromResult(_context.Users.ToList());
        }

        public async Task<List<User>> GetAllAsync(Func<User, bool> predicate)
        {
            return await Task.FromResult(_context.Users.Where(predicate).ToList());
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await Task.FromResult(_context.Users.Find(id)); ;
        }

        public async Task<List<User>> GetByNameAsync(string name, int page, int itensPerPage)
        {
            return await Task.FromResult(_context.Users.Where(x => x.Login.Contains(name)).Skip(itensPerPage * (page - 1)).Take(itensPerPage).ToList());
        }

      
        public async Task SaveAsync(User user)
        {
            await _context.Users.AddAsync(user).AsTask();
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAsync(User user)
        {
           _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
