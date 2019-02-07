using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHired_MVC.Models.Interfaces
{
    public interface IFocusManager
    {
        Task CreateFocus(Focus focus);

        Task<IEnumerable<Focus>> GetFocus(int id);

        Task<Focus> GetSingleFocus(int id);

        Task UpdateFocus(Focus focus);

        Task<Focus> GetSingleFocus(int id);

        Task<Focus> DeleteFocus(int id);
    }
}
