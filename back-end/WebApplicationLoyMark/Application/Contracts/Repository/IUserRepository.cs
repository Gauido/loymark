using Data.Entities;

namespace Application.Contracts.Repository
{
    public interface IUserRepository
    {
        Task<User> FindyById(int id);
        Task<IList<User>> GetAll();
        Task<int> Create(User user);
        Task Update(User user);
        Task Delete(User user);
    }
}
