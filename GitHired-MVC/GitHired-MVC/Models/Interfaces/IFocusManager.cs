using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHired_MVC.Models.Interfaces
{
    public interface IFocusManager
    {
        Task CreateFocus(Focus amenities);

        Task<Focus> GetFocus(int id);

        Task UpdateFocus(Focus amenities);

        Task DeleteFocus(int id);
    }
}
