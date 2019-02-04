using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHired_MVC.Models.Interfaces
{
    public interface IFocusManager
    {
        Task CreateFocus(Focus focus);

        Task<Focus> GetFocus(int id);

        Task UpdateFocus(Focus focus);

        Task DeleteFocus(int id);
    }
}
