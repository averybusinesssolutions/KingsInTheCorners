using KiC.Core.Dtos;
using KiC.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiC.Presentation.Messages
{
    public class StackClickedMessage<T> where T : IPlayable
    {
        public StackViewModel? Stack { get; private set; }
        public T? Selected {  get; private set; }
        public StackClickedMessage() { }
        public StackClickedMessage(StackViewModel stack, T? selected)
        {
            Stack = stack;
            Selected = selected;
        }
    }
}
