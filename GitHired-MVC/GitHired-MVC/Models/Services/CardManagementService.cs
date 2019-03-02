using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GitHired_MVC.Data;
using GitHired_MVC.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GitHired_MVC.Models.Services
{
    public class CardManagementService : ICardManager
    {
        private GitHiredDBContext _context { get; }

        public CardManagementService(GitHiredDBContext context)
        {
            _context = context;
        }

        public async Task CreateCard(Card card)
        {
            _context.Card.Add(card);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCard(int id)
        {
            Card card = _context.Card.FirstOrDefault(c => c.ID == id);
            _context.Card.Remove(card);

            await _context.SaveChangesAsync();
        }

        public async Task<Card> GetCard(int id)
        {
            return await _context.Card.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task UpdateCard(Card card)
        {
            _context.Card.Update(card);
            await _context.SaveChangesAsync();
        }
    }
}
