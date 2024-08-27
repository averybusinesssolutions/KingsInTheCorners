using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using KiC.Core.Dtos;
using KiC.Core.Models;
using KiC.Presentation.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KiC.Presentation.ViewModels
{
    public class StackViewModel : ViewModelBase, IPlayable, IRecipient<StackClickedMessage<StackViewModel>>, IRecipient<StackClickedMessage<CardViewModel>>
    {
        private StackState _stack;
        private int _angle;
        private StackViewModel _stackViewModel;
        private CardViewModel _cardViewModel;
        public int Id {  get; private set; }
        public CardViewModel TopCard { get; private set; }
        public CardViewModel BottomCard { get; private set; }
        public int Angle { get => _angle; set => SetProperty(ref _angle, value); }
        public ICommand OnStackClick { get; set; }
        public StackViewModel(StackState stack, int angle, int id)
        {
            _stack = stack;
            _angle = angle;
            TopCard = new CardViewModel(stack.Top, angle);
            BottomCard = new CardViewModel(stack.Bottom, angle);
            OnStackClick = new RelayCommand(StackClick);
            Id = id;
            StrongReferenceMessenger.Default.Register<StackClickedMessage<StackViewModel>>(this);
            StrongReferenceMessenger.Default.Register<StackClickedMessage<CardViewModel>>(this);
        }

        private void StackClick()
        {
            if (_cardViewModel is null && _stackViewModel is null)
            {
                SendMessage<StackViewModel>(_stackViewModel);
            }
            else if(_cardViewModel is null) 
            {
                SendMessage<StackViewModel>(_stackViewModel);
            }
            else
            {
                SendMessage<CardViewModel>(_cardViewModel);
            }
        }

        private void SendMessage<T>(T selected) where T : IPlayable
        {
            StrongReferenceMessenger.Default.Send(new StackClickedMessage<T>(this, selected));
        }

        public void Receive(StackClickedMessage<StackViewModel> message)
        {
            if (message.Selected != null) 
            {
                BottomCard = message.Selected.BottomCard;
            }
            else
            {
                _stackViewModel = this;
            }
        }

        public void Receive(StackClickedMessage<CardViewModel> message)
        {
            throw new NotImplementedException();
        }
    }
}
