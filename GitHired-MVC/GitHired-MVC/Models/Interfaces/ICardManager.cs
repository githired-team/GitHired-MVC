using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitHired_MVC.Models.Interfaces
{
    public interface ICardManager
    {
        Task CreateCard(Card card);

        Task<Card> GetCard(int id);

        Task UpdateCard(Card card);

        Task DeleteCard(int id);
    }
}
