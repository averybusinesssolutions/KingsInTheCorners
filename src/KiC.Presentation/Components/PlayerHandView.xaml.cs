using KiC.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KiC.Presentation.Components
{
    /// <summary>
    /// Interaction logic for PlayerHandView.xaml
    /// </summary>
    public partial class PlayerHandView : UserControl
    {
        public PlayerHandViewModel Player { get; set; }
        public PlayerHandView(Core.Models.Player player)
        {
            Player = new PlayerHandViewModel(player);
            InitializeComponent();
            DataContext = Player;
        }
    }
}
