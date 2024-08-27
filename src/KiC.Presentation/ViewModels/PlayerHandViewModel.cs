using CommunityToolkit.Mvvm.Messaging;
using KiC.Core.Models;
using KiC.Presentation.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiC.Presentation.ViewModels
{
    public class PlayerHandViewModel : ViewModelBase, IRecipient<CardDrawnMessage>
    {
        private Player _player;
        public ObservableCollection<CardViewModel> CardsInHand { get; } = new ObservableCollection<CardViewModel>();
        public PlayerHandViewModel()
        {
            _player = new Player();
        }

        public PlayerHandViewModel(Core.Models.Player player)
        {
            _player = player;
            CardsInHand = new ObservableCollection<CardViewModel>(_player.Hand.Select(x => new CardViewModel(x, 0)));
        }

        public void Receive(CardDrawnMessage message)
        {
            _player.Hand.Add(message.Card);
            CardViewModel cardViewModel = new CardViewModel(message.Card, 0);
            CardsInHand.Add(cardViewModel);
        }

        public void RegisterToMessenger()
        {
            StrongReferenceMessenger.Default.Register<CardDrawnMessage>(this);
        }

        public void UnregisterFromMessenger()
        {
            StrongReferenceMessenger.Default.Unregister<CardDrawnMessage>(this);
        }
    }
}
