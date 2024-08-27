using KiC.Core.Dtos;
using KiC.Core.Models;
using KiC.Infrastructure;
using KiC.Infrastructure.Commands;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Spectre.Console.Cli;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
var app = new CommandApp();
app.Configure((config) =>
{
    config.AddCommand<PlayCard>("play");
    config.AddCommand<MoveStack>("move");
    config.AddCommand<DrawCard>("draw");
});

var registrations = new ServiceCollection();
Board board = new Board();
registrations.AddSingleton(board);

while (board.GetCurrentPlayer().Hand.Count > 0)
{
    var boardLayout = Renderer.RenderBoardState(board.ToBoardState());
    var handLayout = Renderer.RenderHand(board.GetCurrentPlayer().Hand);
    AnsiConsole.Write(boardLayout);
    AnsiConsole.Write(handLayout);

    var card = AnsiConsole.Prompt(
        new SelectionPrompt<Card>()
        .Title(boardLayout.ToString())
        .AddChoices(board.GetCurrentPlayer().Hand));

    AnsiConsole.Confirm("Exit application");
    //app.Run(args);
}