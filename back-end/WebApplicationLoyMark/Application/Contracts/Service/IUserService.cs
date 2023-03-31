using Data.Entities;

namespace Application.Contracts.Service
{
    public interface IUserService
    {
        Task LogEvents(string task, int user);
        Task Delete(int id);
        Task Update(int id, User user);
        Task Create(User user);
        Task<IList<User>> GetAll();
        Task Disabled(int id);
        Task<List<Activity>> GetActivity();
        Task<User> GetUserById(int id);
    }
}
