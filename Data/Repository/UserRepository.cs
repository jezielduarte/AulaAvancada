using Data.SqLite;
using Domain.Entity;
using Domain.Repository;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {
        ContextSQLite _context;

        public UserRepository(ContextSQLite context)
        {
            _context = context;
        }

        public void Save(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
