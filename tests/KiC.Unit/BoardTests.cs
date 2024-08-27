using KiC.Core.Dtos;
using KiC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiC.Unit
{
    public class BoardTests
    {
        [Fact]
        public void Constructor_Returns_StackListWithDifferentCards()
        {
            Board b = new Board();
            var bs = b.ToBoardState();
            Assert.NotEqual(bs.Stacks[0].ToString(), bs.Stacks[1].ToString());
        }

    }
}
