using Domain.Entity;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IUserRepository
    {
        Task SaveAsync(User user);
    }
}
