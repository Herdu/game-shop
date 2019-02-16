using System.Collections.ObjectModel;
namespace MateuszDobrowolski.ViewModels
{
    public class GameListViewModel: BaseViewModel
    {
        public ObservableCollection<GameViewModel> Games { get; set; } = new ObservableCollection<GameViewModel>();
        public RelayCommand ShowGameDetailsCommand { get; }
        
        public GameListViewModel()
        {
            OnPropertyChanged("Games");
            GetAllGames();

            ShowGameDetailsCommand = new RelayCommand(param => ShowGameDetails(param));
        }

        private void GetAllGames()
        {
            foreach (var game in BLC.BLC.DAO.GetAllGames())
            {
                Games.Add(new GameViewModel(game));
            }
        }

        private GameViewModel _editedGame;

        public GameViewModel editedGame
        {
            get => _editedGame;
            set
            {
                _editedGame = value;
                OnPropertyChanged(nameof(editedGame));
            }
        }

        private void AddNewGame()
        {
            editedGame = new GameViewModel(BLC.BLC.DAO.NewGame());
        }
    }


}
