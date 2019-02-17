using MateuszDobrowolski.Interfaces;
using MateuszDobrowolski.UI.Views;

namespace MateuszDobrowolski.UI.ViewModels
{
    public class GameViewModel: BaseViewModel
    {
        public RelayCommand GoToListCommand { get; }
        public RelayCommand EditGameCommand { get; }
        public RelayCommand DeleteGameCommand { get; }
        private int _id;
        private IGame _game;

        public GameViewModel(int id)
        {
            _id = id;
           
            GoToListCommand = new RelayCommand(param => GoToList());
            EditGameCommand = new RelayCommand(param => GoToPage(new GameFormView(_id)));
            DeleteGameCommand = new RelayCommand(param => DeleteGame());
            _game = BLC.BLC.DAO.GetGameById(_id);
        }

        public int ID
        {
            get => _game.ID;
        }

        public string Name
        {
            get => _game.Name;
        }

        private void GoToList()
        {
            GoToPage(new GameListView());
        }

        private void DeleteGame()
        {
            BLC.BLC.DAO.DeleteGame(_id);
            GoToList();
        }
    }
}
