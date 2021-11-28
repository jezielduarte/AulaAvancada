using Data.SqLite;
using Domain.Entity;
using Domain.Repository;
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

        public async Task SaveAsync(User user)
        {
            await _context.Users.AddAsync(user).AsTask();
            await _context.SaveChangesAsync();
        }
    }
}
