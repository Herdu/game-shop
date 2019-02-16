using MateuszDobrowolski.Interfaces;
using MateuszDobrowolski.UI.Views;

namespace MateuszDobrowolski.UI.ViewModels
{
    public class GameViewModel: BaseViewModel
    {
        public RelayCommand GoToListCommand { get; }

        private int _id;
        private IGame _game;

        public GameViewModel(int id)
        {
            _id = id;
           

            if (_game is null)
            {
                GoToList();
            }

            GoToListCommand = new RelayCommand(param => GoToList());
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
            Switcher.Switch(new GameList());
        }
    }
}
