using KiC.Presentation.Components;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KiC.Presentation.ViewModels;
using KiC.Core.Models;
using KiC.Core.Dtos;

namespace KiC.Presentation;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Board _board;
    public MainWindow()
    {
        InitializeComponent();
        _board = new Board();
        DeckView deckView = new DeckView();
        PlayerHandView playerHandView = new PlayerHandView(_board.GetCurrentPlayer());
        playerHandView.Player.RegisterToMessenger();

        BoardState boardState = _board.ToBoardState();

        StackView northStackView = new StackView(boardState.Stacks[0], 1);
        StackView southStackView = new StackView(boardState.Stacks[1], 2);
        StackView eastStackView = new StackView(boardState.Stacks[2],3, 90);
        StackView westStackView = new StackView(boardState.Stacks[3],4, 90);

        AddChild(northStackView, 1, 0);
        AddChild(southStackView, 1, 2);
        AddChild(eastStackView, 0, 1);
        AddChild(westStackView, 2, 1);

        AddChild(playerHandView, 0, 3, columnspan:4);
        AddChild(deckView, 1, 1);
    }

    private void AddCard(string imagePath, int column, int row, int angle = 0)
    {
        CardView cardView = new CardView(new CardViewModel(imagePath, angle));
        Grid.SetColumn(cardView, column);
        Grid.SetRow(cardView, row);
        Board.Children.Add(cardView);
    }

    private void AddChild<T>(T element, int column, int row, int columnspan = 1, int rowspan = 1) where T : UIElement
    {
        Grid.SetColumn(element, column);
        Grid.SetRow(element, row);
        Grid.SetRowSpan(element, rowspan);
        Grid.SetColumnSpan(element, columnspan);
        Board.Children.Add(element);
    }
}