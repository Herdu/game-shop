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

        public int? FirstReleaseYear
        {
            get
            {
                if (_game.Releases.Count > 0)
                {
                    _game.Releases.Sort((x, y) => DateTime.Compare(x.Date, y.Date));
                    return _game.Releases[0].Date.Year;
                }
                return null;
            }
        }
    }
}
