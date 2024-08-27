using KiC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiC.Unit
{
    public class StackTests
    {
        [Fact]
        public void Stack_With_List_First_and_Last_Equal_JOfSpades()
        {
            Card testCard = new Card(11, Suit.Spades);
            List<Card> cards = [testCard];
            Stack stack = new Stack(cards);
            Assert.NotNull(stack);
            Assert.Equal(testCard.ToString(), stack.First().ToString());
            Assert.Equal(testCard.ToString(), stack.Last().ToString());
        }

        //Test Constructors in A loop
        [Fact]
        public void Constructors_In_Loop_Return_Different_Cards()
        {
            Card joS = new Card(11, Suit.Spades);
            Card tenOfHearts = new Card(10, Suit.Hearts);
            Card nineOfClubs = new Card(9, Suit.Clovers);
            Card eightOfDiamonds = new Card(8, Suit.Diamonds);

            List<Card> cards = [joS, tenOfHearts, nineOfClubs, eightOfDiamonds];

            for (int i = 0; i < 4; i++)
            {
                Stack s = new Stack([cards[i]]);
                Assert.Equal(cards[i].ToString(), s.First().ToString());
            }
        }
    }
}
