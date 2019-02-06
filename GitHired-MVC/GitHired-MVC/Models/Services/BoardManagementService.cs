using GitHired_MVC.Data;
using GitHired_MVC.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHired_MVC.Models.Services
{
    public class BoardManagementService : IBoardManager
    {
        private GitHiredDBContext _context { get; }

        public BoardManagementService(GitHiredDBContext context )
        {
            _context = context;
        }

        public async Task CreateBoard(Board board)
        {
            _context.Board.Add(board);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Board>> SearchBoard(string name)
        {
            var boards = from b in _context.Board
                        .Where(n => n.Name.Equals(name))
                        select b;

            return await boards.ToListAsync();
        }

        public async Task DeleteBoard(int id)
        {
            Board board = _context.Board.FirstOrDefault(x => x.ID == id);
            _context.Board.Remove(board);
            // Remove from neighbors
            await _context.SaveChangesAsync();
        }

        public async Task<Board> GetBoardAsync(int id)
        {
            return await _context.Board.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task UpdateBoard(Board board)
        {
            _context.Board.Update(board);
            await _context.SaveChangesAsync();
        }
    }
}
