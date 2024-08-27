using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiC.Core.Models
{
    public class Card
    {
        public Suit Suit { get; set; }
        public int Rank { get; set; }
        public Card() { }
        public Card(int rank, Suit suit) 
        {
            Rank = rank;
            Suit = suit;
        }

        public override string ToString()
        {
            string r = Rank == 1 ? "A" : Rank == 11 ? "J" : Rank == 12 ? "Q" : Rank == 13 ? "K" : Rank.ToString();
            string s = Suit == Suit.Diamonds ? "Diamonds" : Suit == Suit.Hearts ? "Hearts" : Suit == Suit.Clovers ? "Clovers" : "Spades";
            return $"{r} of {s}";
        }

        public bool IsBlack() => Suit == Suit.Spades || Suit == Suit.Clovers;
        public bool IsRed() => Suit == Suit.Hearts || Suit == Suit.Diamonds;
    }

    public enum Suit
    {
        Clovers,
        Spades,
        Hearts,
        Diamonds
    }
}
