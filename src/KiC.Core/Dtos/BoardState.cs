using KiC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiC.Core.Dtos
{
    public class BoardState
    {
        public Player CurrentPlayer { get; set; }
        public List<StackState> KingStacks { get; set; }
        public List<StackState> Stacks { get; set; }
        public int DrawDeckCount { get; set; }
        public override string ToString()
        {
            StringBuilder boardStateString = new StringBuilder($"Current Player: {CurrentPlayer.Name}\n");
            boardStateString.AppendLine($"Deck: {DrawDeckCount}");
            boardStateString.Append("Kings: ");
            KingStacks.ForEach(s => boardStateString.Append(s.ToString()));
            boardStateString.Append('\n');
            boardStateString.Append("Stacks: ");
            Stacks.ForEach(s => boardStateString.Append(s.ToString()));
            boardStateString.Append('\n');

            return boardStateString.ToString();
        }

    }
}
