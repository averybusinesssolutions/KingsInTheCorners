using KiC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiC.Unit
{
    public class CardTests
    {
        [Fact]
        public void IsBlack_ReturnsTrue()
        {
            Card jOS = new Card(11, Suit.Spades);
            Assert.True(jOS.IsBlack());
        }

        [Fact]
        public void IsBlack_ReturnsFalse()
        {
            Card jOH = new Card(11, Suit.Hearts);
            Assert.False(jOH.IsBlack());
        }

        [Fact]
        public void IsRed_ReturnsTrue()
        {
            Card joD = new Card(11, Suit.Diamonds);
            Assert.True(joD.IsRed());
        }

        [Fact]
        public void IsRed_ReturnsFalse()
        {
            Card joC = new Card(11, Suit.Clovers);
            Assert.False(joC.IsRed());
        }
    }
}
