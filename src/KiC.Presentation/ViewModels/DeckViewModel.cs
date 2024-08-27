using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using KiC.Core.Models;
using KiC.Presentation.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace KiC.Presentation.ViewModels
{
    public class DeckViewModel : ViewModelBase
    {
        private Deck _deck = new Deck();
        private BitmapImage _imageSource = new BitmapImage(new Uri("resources/DefaultBack_Stacked.png", UriKind.RelativeOrAbsolute));
        public Deck Deck { get => _deck; set => SetProperty(ref _deck, value); }
        public BitmapImage ImageSource { get => _imageSource; set => SetProperty(ref _imageSource, value); }
        public ICommand OnDrawCardEvent { get; }
        public DeckViewModel() 
        {
            OnDrawCardEvent = new RelayCommand(DrawCard);
        }

        private void DrawCard()
        {
            var drawnCard = Deck.GetRandomCard();
            StrongReferenceMessenger.Default.Send(new CardDrawnMessage(drawnCard));
        }
    }
}
