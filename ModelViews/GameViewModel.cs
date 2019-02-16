using MateuszDobrowolski.Interfaces;
using System.Collections.ObjectModel;
using System;

namespace MateuszDobrowolski.ViewModels
{
    public class GameViewModel: BaseViewModel
    {
        private IGame _game;

        public GameViewModel(IGame game)
        {
            _game = game;

        }

        public int ID
        {
            get => _game.ID;
            set
            {
                _game.ID = value;
            }
        }

        public string Name
        {
            get => _game.Name;
            set
            {
                _game.Name = value;
            }
        }

        public IProducer Producer
        {
            get => _game.Producer;
            set
            {
                _game.Producer = value;
            }
        }

        public int? FirstReleaseYear
        {
            get {
                if(_game.Releases.Count > 0)
                {
                    _game.Releases.Sort((x, y) => DateTime.Compare(x.Date, y.Date));
                    return _game.Releases[0].Date.Year;
                }
                return null;
               }

        }
    }
}
