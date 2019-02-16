using System.Windows.Controls;

namespace MateuszDobrowolski.UI
{
    public class Switcher
    {
        public static MainWindow pageSwitcher;

        public static void Switch(Page newPage)
        {
            pageSwitcher.Navigate(newPage);
        }
    }
}
