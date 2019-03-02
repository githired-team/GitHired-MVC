using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHired_MVC.Data;
using GitHired_MVC.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GitHired_MVC.Models.Services
{
    public class UserManagementService : IUserManager
    {
        private GitHiredDBContext _context { get; }

        public UserManagementService(GitHiredDBContext context)
        {
            _context = context;
        }

        public async Task CreateUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> SearchUserName(string name)
        {
            var users = from u in _context.User
                        .Where(n => n.Name.Equals(name))
                       select u;

            return await users.ToListAsync();
        }

        public async Task DeleteUser(int id)
        {
            User user = _context.User.FirstOrDefault(x => x.ID == id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<User> GetUserByName(string name)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task UpdateUser(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
