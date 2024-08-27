using KiC.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KiC.Core.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsCPU { get; set; }
        public List<Card> Hand { get; set; } = [];
        public event EventHandler<CardPlayedEventArgs> CardPlayed;
        public event EventHandler<MoveStackEventArgs> MoveStack;  
        public event EventHandler<DrawCardEventArgs> DrawCard;
        public Player() { }
        public Player(string name, bool isCPU, List<Card> hand)
        {
            Name = name;
            IsCPU = isCPU;
            Hand = hand;
        }

        public void Draw()
        {
            DrawCard?.Invoke(this, new DrawCardEventArgs());
        }

        public void Move(int stackToBeMoved,int stackedOn) 
        {
            MoveStack?.Invoke(this, new MoveStackEventArgs(stackToBeMoved, stackedOn));
        }

        public void Play(Card card, int stack, StackType stackType = StackType.Regular)
        {
            CardPlayed?.Invoke(this, new CardPlayedEventArgs(card, stack, stackType));
            Hand.Remove(card);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var card in Hand)
            {
                sb.Append(card.ToString() + " ");
            }
            return sb.ToString();
        }
    }
}
