using KiC.Core.Dtos;
using KiC.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiC.Core.Models
{
    public class Board
    {
        private Deck drawDeck = new Deck();
        private List<Player> playerList = new List<Player>();
        private Player currentPlayer = new Player();
        private Stack[] stackList = [new Stack(), new Stack(), new Stack(), new Stack()];
        private Stack[] kingsStackList = [new Stack(), new Stack(), new Stack(), new Stack()];

        public Board() 
        {
            Player player = new Player("Player 1", false, Draw(7));
            player.CardPlayed += PlayerPlayed;
            player.MoveStack += Player_MoveStack;
            playerList.Add(player);

            for(int i = 0; i < 4; i++)
            {
                stackList[i].Add(Draw());
            }

            for (int i = 0; i < 3; i++)
            {
                Player comp = new Player($"Comp {i}", false, Draw(7));
                comp.CardPlayed += PlayerPlayed;
                comp.MoveStack += Player_MoveStack;
                playerList.Add(comp);
            }
            currentPlayer = player;
        }

        private void Player_MoveStack(object? sender, MoveStackEventArgs e)
        {
            
        }

        public List<Card> Draw(int num)
        {
            List<Card> cards = new List<Card>();
            for(int i = 0;i < num; i++)
            {
                cards.Add(drawDeck.GetRandomCard());
            }
            return cards;
        }

        public Card Draw()
        {
            return drawDeck.GetRandomCard();
        }
        public Player Next()
        {
            int pi = playerList.IndexOf(currentPlayer);
            if (pi == -1)
                throw new IndexOutOfRangeException("Player not found");
            currentPlayer = playerList[(pi + 1) == playerList.Count ? 0: (pi + 1)];
            return currentPlayer;
        }

        public BoardState ToBoardState()
        {
            BoardState state = new BoardState()
            {
                CurrentPlayer = currentPlayer,
                KingStacks = kingsStackList.Select(k => new StackState { Top = k.First(), Bottom = k.Last() }).ToList(),
                Stacks = stackList.Select(s => new StackState { Top = s.First(), Bottom =s.Last()}).ToList(),
                DrawDeckCount = drawDeck.Count()
            };
            return state;
        }

        private void PlayerPlayed(object sender, CardPlayedEventArgs eventArgs)
        {
            if(eventArgs.StackType == StackType.Regular)
            {
                stackList[eventArgs.Stack].Add(eventArgs.Card);
            }
            else if (eventArgs.StackType == StackType.King)
            {
                kingsStackList[eventArgs.Stack].Add(eventArgs.Card);
            }
            Next();
        }

        public Player GetCurrentPlayer()
        {
            return currentPlayer;
        }
    }
}
