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
    /// Interaction logic for StackView.xaml
    /// </summary>
    public partial class StackView : UserControl
    {
        public StackView()
        {
            InitializeComponent();
            StackViewModel stackViewModel = new StackViewModel(new Core.Dtos.StackState(), 0, 1);
            DataContext = stackViewModel;
        }

        public StackView(Core.Dtos.StackState stack, int id, int angle = 0)
        {
            InitializeComponent();
            StackViewModel stackViewModel = new StackViewModel(stack, angle, id);
            DataContext = stackViewModel;
        }

    }
}
