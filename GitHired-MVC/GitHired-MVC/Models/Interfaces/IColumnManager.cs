using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHired_MVC.Models.Interfaces
{
    public interface IColumnManager
    {
        Task CreateColumn(Column column);

        Task<Column> GetColumn(int id);

        Task UpdateColumn(Column column);

        Task DeleteColumn(int id);
    }
}
