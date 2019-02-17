using MateuszDobrowolski.Interfaces;
using MateuszDobrowolski.UI.Views;

namespace MateuszDobrowolski.UI.ViewModels
{
    public class GameFormViewModel : BaseViewModel
    {
        private IGame _game;

        public bool IsNew
        {
            get;
        }

        public string FormTitle
        {
            get => IsNew ? "New game" : "Edit game";
        }

        public RelayCommand GoToListCommand { get; }

        public GameFormViewModel(int? gameId)
        {
            if(gameId.HasValue)
            {
                IsNew = false;
                _game = BLC.BLC.DAO.GetGameById(gameId.Value);
            }
            else
            {
                IsNew = true;
                _game = BLC.BLC.DAO.NewGame();
            }

            GoToListCommand = new RelayCommand(param => GoToList());
        }

        private void GoToList()
        {
            GoToPage(new GameListView());
        }
    }
}
