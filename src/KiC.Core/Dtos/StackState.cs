using KiC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiC.Core.Dtos
{
    public class StackState
    {
        public Card? Top {  get; set; }
        public Card? Bottom { get; set; }
        public override string ToString()
        {
            return $"({Top}, {Bottom})";
        }
    }
}
