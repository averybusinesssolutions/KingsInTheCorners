using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiC.Core.Models
{
    public class Deck 
    {
        private List<Card> _cards = new List<Card>();
        public Card GetRandomCard()
        {
            Random rnd = new Random();
            int cardIndex = _cards.Count > 1? rnd.Next(_cards.Count - 1) : 0;

            Card c = _cards[cardIndex];
            _cards.Remove(c);
            return c;
        }

        public Deck()
        {
            for (int i = 1; i <= 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    _cards.Add(new Card(i, (Suit)j));
                }
            }
        }

        public int Count()
        {
           return _cards.Count;
        }
    }
}
