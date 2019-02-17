using MateuszDobrowolski.Interfaces;
using System;


namespace MateuszDobrowolski.UI.ViewModels
{
    public class GameListItemViewModel: BaseViewModel
    {
        private IGame _game;
        
        public GameListItemViewModel(IGame game)
        {
            _game = game;
        }

        public int ID
        {
            get => _game.ID;
        }

        public string Name
        {
            get => _game.Name;
        }

        public string ProducerName
        {
            get => _game.Producer.Name;
        }

        public int ReleaseYear
        {
            get => _game.ReleaseDate.Year;
        }

        public int ProducerFounded
        {
            get => _game.Producer.Funded;
        }

        public string ProducerDescription
        {
            get => _game.Producer.Description;
        }

        public string Price
        {
            get => (_game.Price).ToString() + " PLN";
        }
    }
}
