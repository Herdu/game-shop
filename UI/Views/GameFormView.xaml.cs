
using System.Windows.Controls;
using MateuszDobrowolski.UI.ViewModels;

namespace MateuszDobrowolski.UI.Views
{
    public partial class GameFormView : Page
    {
        public GameFormView(int? id)
        {
            InitializeComponent();
            DataContext = new GameFormViewModel(id);
        }


    }
}
