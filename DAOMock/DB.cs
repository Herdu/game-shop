using System;
using System.Collections.Generic;
using System.Linq;
using MateuszDobrowolski.Core;
using MateuszDobrowolski.Interfaces;

namespace MateuszDobrowolski.DAOMock2
{
    public class DB : IDAO
    {

        private List<IProducer> _producers = new List<IProducer>();

        private List<IGame> _games = new List<IGame>();

        public DB()
        {
            DataObjects.Producer Blizzard = new DataObjects.Producer() { ID = 1, Name = "Blizzard", Funded = 1993, Description = "Blizzard Entertainment, Inc. is an American video game developer and publisher based in Irvine, California, and is a subsidiary of the American company Activision Blizzard. The company was Funded on February 8, 1991, under the name Silicon & Synapse, Inc. by three graduates of the University of California, Los Angeles:[2] Michael Morhaime, Frank Pearce and Allen Adham. The company originally concentrated on the creation of game ports for other studios' games before beginning development of their own software in 1993 with games like Rock n' Roll Racing and The Lost Vikings. In 1994 the company became Chaos Studios, Inc., then Blizzard Entertainment after being acquired by distributor Davidson & Associates." };
            DataObjects.Producer EAGames = new DataObjects.Producer() { ID = 2, Name = "EA Games", Funded = 2002, Description = "Electronic Arts Inc. (EA) is an American video game company headquartered in Redwood City, California. Funded and incorporated on May 28, 1982 by Trip Hawkins, the company was a pioneer of the early home computer games industry and was notable for promoting the designers and programmers responsible for its games. As of March 2018, Electronic Arts is the second-largest gaming company in the Americas and Europe by revenue and market capitalization after Activision Blizzard and ahead of Take-Two Interactive and Ubisoft." };
            DataObjects.Producer Ubisoft = new DataObjects.Producer() { ID = 3, Name = "Ubisoft", Funded = 1983, Description = "Ubisoft Entertainment SA ( formerly Ubi Soft Entertainment SA) is a French video game company headquartered in Montreuil, France, with several development studios across the world. It is known for publishing games for several acclaimed video game franchises including Assassin's Creed, Far Cry, Just Dance, Prince of Persia, Rayman, Raving Rabbids, and Tom Clancy's" };
            DataObjects.Producer CDProjekt = new DataObjects.Producer() { ID = 4, Name = "CD Projekt", Funded = 1994, Description = "CD Projekt S.A. is a Polish video game publisher and distributor based in Warsaw, founded in May 1994 by Marcin Iwiński and Michał Kiciński. Iwiński and Kiciński were video game retailers before they founded the company. CD Projekt is best known for their The Witcher series, developed by their CD Projekt Red division, and their digital distribution service GOG.com." };

            _producers.Add(Blizzard);
            _producers.Add(EAGames);
            _producers.Add(Ubisoft);
            _producers.Add(CDProjekt);


            DataObjects.Game WorldOfWarcraft = new DataObjects.Game()
            {
                ID = 1,
                Name = "World of Warcraft",
                Producer = Blizzard,
                ReleaseDate = new DateTime(2004, 11, 23),
                Type = GameType.RPG,
                Price = 99.99m,
            };

            _games.Add(WorldOfWarcraft);

            DataObjects.Game Fifa18 = new DataObjects.Game()
            {
                ID = 2,
                Name = "Fifa 18",
                Producer = EAGames,
                ReleaseDate = new DateTime(2016, 8, 27),
                Type = GameType.SPORT,
                Price = 169.99m,
            };
            _games.Add(Fifa18);

            DataObjects.Game Witcher3 = new DataObjects.Game()
            {
                ID = 3,
                Name = "Witcher 3",
                Producer = CDProjekt,
                ReleaseDate = new DateTime(2015, 5, 19),
                Type = GameType.RPG,
                Price = 139.99m,
            };

            _games.Add(Witcher3);


            for (int i =0; i< 50; i++)
            {
                DataObjects.Game Fifa = new DataObjects.Game()
                {
                    ID = 4 + i,
                    Name = "Fifa " + (20+i).ToString(),
                    Producer = EAGames,
                    ReleaseDate = new DateTime(2019 + i, 8, 27),
                    Type = GameType.SPORT,
                    Price = 169,
                };
                _games.Add(Fifa);
            }

        }

        public IGame GetGameById(int id)
        {
            return _games.Find((game) => game.ID == id);
        }

        public IEnumerable<IGame> GetAllGames()
        {
            return _games;
        }

        public IEnumerable<IGame> GetGames(string name = "", int producerId = -1, int gameType = -1)
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

            if(gameType >= 0)
            {
                games = games.Where(o => o.Type == (GameType)gameType);
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
            
            return new DataObjects.Game() { ID = newId, ReleaseDate = DateTime.Now };
        }

        public void DeleteGame(int gameId)
        {
            _games = GetAllGames().Where(o=> o.ID != gameId).ToList();
        }

        public void SaveGame(IGame game)
        {
            int index = _games.FindIndex(o => o.ID == game.ID);

            if( index == -1)
            {
                _games.Add(new DataObjects.Game(game));
            }
            else
            {
                _games[index] = new DataObjects.Game(game);
            }

        }
    }
}
