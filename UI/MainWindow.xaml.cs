using System.Windows;
using System;
using System.Windows.Controls;
using MateuszDobrowolski.Interfaces;
using MateuszDobrowolski.UI.Views;
namespace MateuszDobrowolski.UI
{ 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Switcher.pageSwitcher = this;
            Navigate(new GameListView());
        }


        public void Navigate(Page nextPage)
        {
            Content = nextPage;
        }
    }
}
