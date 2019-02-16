using System;
using System.Collections.Generic;
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
                Releases = new List<IGameRelease>()
                {
                    new DataObjects.GameRelease() { Date = new DateTime(2004, 12,24), Platform = Core.Platform.PC, Price=119.99m }
                }
            };

            _games.Add(WorldOfWarcraft);

            DataObjects.Game Fifa18 = new DataObjects.Game()
            {
                ID = 2,
                Name = "Fifa 18",
                Producer = EAGames,
                Releases = new List<IGameRelease>()
               {
                new DataObjects.GameRelease() { Date = new DateTime(2017, 9,3), Platform = Core.Platform.PC, Price=159.99m },
                new DataObjects.GameRelease() { Date = new DateTime(2017, 10,2), Platform = Core.Platform.Playstation4, Price=259.99m },
                new DataObjects.GameRelease() { Date = new DateTime(2017, 11,5), Platform = Core.Platform.XboxOne, Price=249.99m },
               }
            };
            _games.Add(Fifa18);

            DataObjects.Game Fifa20 = new DataObjects.Game()
            {
                ID = 3,
                Name = "Fifa20",
                Producer = EAGames,
                Releases = new List<IGameRelease>(),
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

        public IEnumerable<IProducer> GetAllProducers()
        {
            return _producers;
        }

        public IGame NewGame()
        {
            return new DataObjects.Game();
        }

        public IGameRelease NewGameRelease()
        {
            return new DataObjects.GameRelease();
        }

        public IProducer NewProducer()
        {
            return new DataObjects.Producer();
        }
    }
}
