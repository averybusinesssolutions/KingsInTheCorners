using KiC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace KiC.Presentation.ViewModels
{
    public class CardViewModel : ViewModelBase, IPlayable
    {
        private Card _card;
        private BitmapImage _imageSource = new BitmapImage(new Uri("resources/DefaultBack.png", UriKind.RelativeOrAbsolute));
        private int _angle = 45;
        public BitmapImage ImageSource { get => _imageSource; set => SetProperty(ref _imageSource, value); }
        public int Angle { get => _angle; set => SetProperty(ref _angle, value); }
        public CardViewModel() { }
        public CardViewModel(Card card, int angle)
        {
            _card = card;
            ImageSource = new BitmapImage(new Uri(GetResoucePath(card), UriKind.RelativeOrAbsolute));
            Angle = angle;
        }

        public CardViewModel(int angle)
        {   
            _angle = angle;
        }

        public CardViewModel(string source,  int angle = 0)
        {
            _imageSource = new BitmapImage(new Uri(source, UriKind.RelativeOrAbsolute));
            _angle = angle;
        }

        private string GetResoucePath(Card card)
        {
            return $"resources/card_{card.Rank}_{card.Suit.ToString().ToLower().Substring(0, card.Suit.ToString().Count() - 1)}.png";
        }

        public override string ToString()
        {
            return GetResoucePath(_card);
        }
    }
}
