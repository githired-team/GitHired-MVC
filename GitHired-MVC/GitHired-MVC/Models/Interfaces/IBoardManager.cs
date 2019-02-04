using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHired_MVC.Models.Interfaces
{
    public interface IBoardManager
    {
        Task CreateBoard(Board board);

        Task<Board> GetBoard(int id);

        Task UpdateBoard(Board board);

        Task DeleteBoard(int id);
    }
}
