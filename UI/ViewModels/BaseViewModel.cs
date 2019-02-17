using System.ComponentModel;
using System.Windows.Controls;

namespace MateuszDobrowolski.UI.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void GoToPage(Page page)
        {
            Switcher.Switch(page);
        }
    }
}
