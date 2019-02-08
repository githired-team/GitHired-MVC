using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHired_MVC.Models.Interfaces
{
    public interface IBoardManager
    {
        Task<IEnumerable<Board>> SearchBoard(string name);

        Task CreateBoard(Board board);

        Task<Board> GetBoardAsync(int id);

        Task UpdateBoard(Board board);

        Task DeleteBoard(int id);
    }
}
