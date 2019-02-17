using System;
using System.Collections.Generic;
using System.Linq;
using MateuszDobrowolski.Interfaces;

namespace MateuszDobrowolski.DAOMock
{
    public class DB : IDAO
    {

        private List<IProducer> _producers = new List<IProducer>();

        private List<IGame> _games = new List<IGame>();

        public DB()
        {
            DataObjects.Producer Blizzard = new DataObjects.Producer() { ID = 1, Name = "Blizzard", Founded = 1993 };
            DataObjects.Producer EAGames = new DataObjects.Producer() { ID = 2, Name = "EA Games", Founded = 2002 };

            _producers.Add(Blizzard);
            _producers.Add(EAGames);


            DataObjects.Game WorldOfWarcraft = new DataObjects.Game()
            {
                ID = 1,
                Name = "World of Warcraft",
                Producer = Blizzard,
                ReleaseDate = new DateTime(2004, 11, 23),
            };

            _games.Add(WorldOfWarcraft);

            DataObjects.Game Fifa18 = new DataObjects.Game()
            {
                ID = 2,
                Name = "Fifa 18",
                Producer = EAGames,
                ReleaseDate = new DateTime(2016, 8, 27),
            };
            _games.Add(Fifa18);

            DataObjects.Game Fifa20 = new DataObjects.Game()
            {
                ID = 3,
                Name = "Fifa 20",
                Producer = EAGames,
                ReleaseDate = new DateTime(2019, 8, 27),
            };
            _games.Add(Fifa20);
        }

        public IGame GetGameById(int id)
        {
            return _games.Find((game) => game.ID == id);
        }

        public IEnumerable<IGame> GetAllGames()
        {
            return _games;
        }

        public IEnumerable<IGame> GetGames(string name = "", int producerId = -1)
        {
            IEnumerable<IGame> games = GetAllGames();

            string filterName = name.ToLower();
            if(name.Length > 0)
            {
                games = games.Where(o => (o.Name.ToLower()).Contains(filterName));
            }

            if(producerId >= 0)
            {
                games = games.Where(o => o.Producer.ID == producerId);
            }

            return games;
        }

        public IEnumerable<IProducer> GetAllProducers()
        {
            return _producers;
        }

        public IGame NewGame()
        {
            int newId;
            IEnumerable<IGame> games = GetAllGames().OrderBy(o=> o.ID);
            if(games.Count() == 0)
            {
                newId = 1;
            } else
            {
                newId = games.Last().ID + 1;
            }
            
            return new DataObjects.Game() { ID = newId };
        }

        public void DeleteGame(int gameId)
        {
            _games = GetAllGames().Where(o=> o.ID != gameId).ToList();
        }

        public void SaveGame(IGame game)
        {
            _games.Add(new DataObjects.Game(game));
        }
    }
}
