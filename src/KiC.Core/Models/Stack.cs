using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace KiC.Core.Models
{
    public class Stack
    {
        private List<Card> _cards = [];
        public Stack() { }
        public Stack(List<Card> cards)
        {
            _cards = cards;
        }

        public Stack(Card card)
        {
            _cards.Add(card);
        }
        public Card? First() =>  _cards.FirstOrDefault();
        public Card? Last() => _cards.LastOrDefault();

        public void Add(Card card)
        {
            _cards.Add(card);
        }

        public void Add(IEnumerable<Card> cards)
        {
            foreach (var card in cards) 
            {
                Add(card);
            }
            
        }
    }
}
