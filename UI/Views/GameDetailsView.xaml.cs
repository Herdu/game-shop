using MateuszDobrowolski.Interfaces;
using MateuszDobrowolski.UI.ViewModels;
using System;
using System.Diagnostics;
using System.Windows.Controls;


namespace MateuszDobrowolski.UI.Views
{
    public partial class GameDetailsView : Page
    {
        public GameViewModel CurrentGameViewModel
        {
            get; set;
        }

        public GameDetailsView(int id)
        {
            InitializeComponent();
            DataContext = new GameViewModel(id);
        }
    }
}
