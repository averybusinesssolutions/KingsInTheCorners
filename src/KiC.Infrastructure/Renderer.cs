using KiC.Core.Dtos;
using KiC.Core.Models;
using Spectre.Console;
using Spectre.Console.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KiC.Infrastructure
{
    internal static class Renderer
    {
        public static IRenderable RenderBoardState(BoardState boardState)
        {
            Layout board = new Layout("Board").SplitColumns(
                new Layout("Left").SplitRows(
                    new Layout("KingsNW"),
                    new Layout("W"),
                    new Layout("KingsSW")
                    ),
                new Layout("Center").SplitRows(
                    new Layout("N"),
                    new Layout("Draw"),
                    new Layout("S")),
                new Layout("Right").SplitRows(
                    new Layout("KingsNE"),
                    new Layout("E"),
                    new Layout("KingsSW")
                    )
                );
            board["N"].Update(RenderStack(boardState.Stacks[0]));
            board["E"].Update(RenderStack(boardState.Stacks[1]));
            board["S"].Update(RenderStack(boardState.Stacks[2]));
            board["W"].Update(RenderStack(boardState.Stacks[3]));
            return board;
        }
        public static IRenderable RenderCard(Card? card)
        {
            if (card != null)
            {
                string cardRank = card.Rank == 11 ? "J" : card.Rank == 12 ? "Q" : card.Rank == 13 ? "K" : card.Rank == 1 ? "A" : card.Rank.ToString();
                switch (card.Suit)
                {
                    case Suit.Clovers:
                        cardRank += Emoji.Known.ClubSuit;
                        break;
                    case Suit.Spades:
                        cardRank += Emoji.Known.SpadeSuit;
                        break;
                    case Suit.Diamonds:
                        cardRank += Emoji.Known.DiamondSuit;
                        break;
                    case Suit.Hearts:
                        cardRank += Emoji.Known.HeartSuit;
                        break;
                }
                var cardPanel = new Panel(new Markup($"[{(card.IsRed() ? "red" : "white")}]{cardRank}[/]"));
                cardPanel.Border(BoxBorder.Heavy);
                return cardPanel;
            }
            return new Markup("No cards");
        }

        public static IRenderable RenderStack(StackState stack)
        {
            Layout layout = new Layout();
            if(stack.Top == stack.Bottom)
            {
                layout.Update(RenderCard(stack.Top));
            }
            else
            {
                layout.SplitRows(
                    new Layout("Top").Update(RenderCard(stack.Top)),
                    new Layout("Bottom").Update(RenderCard(stack.Bottom))
                    );
            }
            return layout;
        }

        public static IRenderable RenderHand(List<Card> hand)
        {
            var layout = new Layout();
            var list = new List<Layout>();
            foreach(Card card in hand)
            {
                list.Add(new Layout().Update(RenderCard(card)));
            }
            layout.SplitColumns(list.ToArray());
            return layout;
        }
    }
}
