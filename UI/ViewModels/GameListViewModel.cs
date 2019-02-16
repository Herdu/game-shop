using MateuszDobrowolski.Interfaces;
using MateuszDobrowolski.UI.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MateuszDobrowolski.UI.ViewModels
{
    public class GameListViewModel: BaseViewModel
    {
        public ObservableCollection<GameListItemViewModel> Games { get; set; } = new ObservableCollection<GameListItemViewModel>();
        public RelayCommand ShowGameDetailsCommand { get; }
        
        public GameListViewModel()
        {
            OnPropertyChanged("Games");
            GetAllGames();
            ShowGameDetailsCommand = new RelayCommand(param => ShowGameDetails(param as GameListItemViewModel));
        }

        private void GetAllGames()
        {
            foreach (var game in BLC.BLC.DAO.GetAllGames())
            {
                Games.Add(new GameListItemViewModel(game));
            }
        }

        private GameViewModel _editedGame;

        public GameViewModel EditedGame
        {
            get => _editedGame;
            set
            {
                _editedGame = value;
                OnPropertyChanged(nameof(EditedGame));
            }
        }

        private void ShowGameDetails(object game)
        {
            GameListItemViewModel model = game as GameListItemViewModel;

            Switcher.Switch(new GameDetailsView(model.ID));
        }
    }
}
