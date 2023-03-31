using Data.Entities;

namespace Application.Contracts.Repository
{
    public interface IActivityRepository
    {
        Task LogEvents(Activity activity);
        Task<List<Activity>> GetActivity();
    }
}
