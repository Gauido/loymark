using Application.Contracts.Repository;
using Data.Context;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Stores
{
    public class ActivityStore : IActivityRepository
    {
        private readonly LoyMarkDbContext _context;
        public ActivityStore(LoyMarkDbContext context)
        {
            _context = context;
        }

        public async Task LogEvents(Activity activity)
        {
            await _context.Activities.AddAsync(activity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Activity>> GetActivity()
        {
            return await _context.Activities
                .OrderByDescending(m => m.CreateDate)
                .Select(x => new Activity
                {
                    CreateDate = x.CreateDate,
                    User = x.User,
                    Id = x.Id,
                    Id_User = x.Id_User,
                    Task = x.Task,
                })
                .ToListAsync();
        }
    }
}
