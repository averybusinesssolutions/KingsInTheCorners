using KiC.Infrastructure.Commands.Settings;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiC.Infrastructure.Commands
{
    internal class PlayCard : Command<PlayCardSettings>
    {
        public override int Execute(CommandContext context, PlayCardSettings settings)
        {
            return 0;
        }
    }
}
