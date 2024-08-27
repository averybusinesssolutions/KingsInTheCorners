using KiC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiC.Core.Events
{
    public class CardPlayedEventArgs : EventArgs
    {
        public CardPlayedEventArgs(Card card,int stack, StackType stackType)
        {
            Stack = stack;
            Card = card;
            StackType = stackType;
        }

        public int Stack { get; set; }
        public Card Card { get; set; }
        public StackType StackType { get; set; }
    }

    public enum StackType
    {
        King,
        Regular
    }
}
