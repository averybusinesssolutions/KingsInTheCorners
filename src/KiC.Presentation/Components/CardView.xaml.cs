﻿using KiC.Presentation.ViewModels;
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
    /// Interaction logic for Card.xaml
    /// </summary>
    public partial class CardView : UserControl
    {
        public CardView()
        {
            InitializeComponent();
            var cardViewModel = new CardViewModel();
            DataContext = cardViewModel;
        }

        public CardView(CardViewModel cardViewModel)
        {
            InitializeComponent();
            DataContext = cardViewModel;
        }
    }
}
