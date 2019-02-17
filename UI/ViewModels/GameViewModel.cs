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

        public string Type
        {
            get => _game.Type.ToString();
        }

        public string ProducerName
        {
            get => _game.Producer.Name;
        }

        public int ProducerFunded
        {
            get => _game.Producer.Funded;
        }

        public string ProducerDescription
        {
            get => _game.Producer.Description;
        }

        public string ReleaseDate
        {
            get => _game.ReleaseDate.ToShortDateString();
        }


        public decimal Price
        {
            get => _game.Price;
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
