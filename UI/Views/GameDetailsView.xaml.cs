using MateuszDobrowolski.UI.ViewModels;
using System.Windows.Controls;


namespace MateuszDobrowolski.UI.Views
{
    public partial class GameDetailsView : Page
    {
        public GameDetailsView(int id)
        {
            InitializeComponent();
            DataContext = new GameViewModel(id);
        }
    }
}
