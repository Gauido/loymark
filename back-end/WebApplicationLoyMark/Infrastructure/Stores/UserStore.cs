using Application.Contracts.Repository;
using Data.Context;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Stores
{
    public class UserStore : IUserRepository
    {
        private readonly LoyMarkDbContext _context;

        public UserStore(LoyMarkDbContext context)
        {
            _context = context;
        }
        public async Task<User> FindyById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<int> Create(User request)
        {
            await _context.Users.AddAsync(request);
            await _context.SaveChangesAsync();
            return request.Id;
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<User>> GetAll()
        {
            return await _context.Users.Where(x => x.Enabled == true).ToListAsync();
        }
    }
}