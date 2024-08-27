using KiC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiC.Presentation.Messages
{
    public class CardDrawnMessage 
    {
        public Card Card { get; set; }
        public CardDrawnMessage() { }
        public CardDrawnMessage(Card card)
        {
            Card = card;
        }
    }
}
