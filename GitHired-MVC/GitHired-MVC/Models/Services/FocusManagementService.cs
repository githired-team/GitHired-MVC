using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHired_MVC.Data;
using GitHired_MVC.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GitHired_MVC.Models.Services
{
    public class FocusManagementService : IFocusManager
    {
        private GitHiredDBContext _context { get; }

        public FocusManagementService(GitHiredDBContext context)
        { 
            _context = context;
        }

        public async Task CreateFocus(Focus focus)
        {
            _context.Focus.Add(focus);
            await _context.SaveChangesAsync();
        }

        public Task<Focus> DeleteFocus(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Focus> GetSingleFocus(int id)
        {
            return await _context.Focus.FirstOrDefaultAsync(f => f.ID == id);
        }

        public async Task<IEnumerable<Focus>> GetFocus(int id)
        {
            //return await _context.Focus.FirstOrDefaultAsync(x => x.ID == id);
            var foc = from f in _context.Focus
                      .Where(ui => ui.UserID == id)
                       select f;
            return await foc.ToListAsync();
        }

        

        public async Task UpdateFocus(Focus focus)
        {
            _context.Focus.Update(focus);
            await _context.SaveChangesAsync();
        }

        Task<Focus> IFocusManager.DeleteFocus(int id)
        {
            throw new NotImplementedException();
        }
    }
}
