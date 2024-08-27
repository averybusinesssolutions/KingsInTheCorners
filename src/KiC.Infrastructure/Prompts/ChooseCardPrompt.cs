using KiC.Core.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiC.Infrastructure.Prompts
{
    internal class ChooseCardPrompt : IPrompt<Card>
    {
        public Card Show(IAnsiConsole console)
        {
            
            throw new NotImplementedException();
        }

        public Task<Card> ShowAsync(IAnsiConsole console, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
