using System;
using System.Collections.Generic;
using System.Linq;
using MateuszDobrowolski.Core;
using MateuszDobrowolski.Interfaces;

namespace MateuszDobrowolski.DAOMock2
{
    public class DB : IDAO
    {
        private readonly Random _random = new Random();
        private readonly string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private List<IProducer> _producers = new List<IProducer>();

        private List<IGame> _games = new List<IGame>();

        private string RandomString(int length)
        {
            return new string(Enumerable.Repeat(_chars, length)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
        }


        public DB()
        {
            DataObjects.Producer DummyProducer1 = new DataObjects.Producer() { ID = 1, Name = "Dummy 1", Funded = 1999, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed luctus velit a velit consequat, quis elementum diam sagittis. Duis aliquet est elit, eu pulvinar erat rutrum ac. Sed ipsum augue, posuere quis est vel, aliquet condimentum arcu. Duis sagittis convallis orci at consectetur. Vestibulum auctor at nibh eget suscipit. Nam id justo in turpis dignissim iaculis. Vestibulum a libero vitae diam euismod volutpat et placerat nisi. Duis felis massa, cursus a porttitor vitae, commodo sit amet massa. Phasellus in lacinia massa, nec porta ipsum. Integer nec tortor a sapien viverra ultrices. Sed dolor felis, imperdiet at blandit sit amet, ornare non risus. Aliquam tempor quam velit. In a commodo ligula, in placerat sem." };
            DataObjects.Producer DummyProducer2 = new DataObjects.Producer() { ID = 2, Name = "Dummy 2", Funded = 2017, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed luctus velit a velit consequat, quis elementum diam sagittis. Duis aliquet est elit, eu pulvinar erat rutrum ac. Sed ipsum augue, posuere quis est vel, aliquet condimentum arcu. Duis sagittis convallis orci at consectetur. Vestibulum auctor at nibh eget suscipit. Nam id justo in turpis dignissim iaculis. Vestibulum a libero vitae diam euismod volutpat et placerat nisi. Duis felis massa, cursus a porttitor vitae, commodo sit amet massa. Phasellus in lacinia massa, nec porta ipsum. Integer nec tortor a sapien viverra ultrices. Sed dolor felis, imperdiet at blandit sit amet, ornare non risus. Aliquam tempor quam velit. In a commodo ligula, in placerat sem." };
            DataObjects.Producer DummyProducer3 = new DataObjects.Producer() { ID = 3, Name = "Dummy 3", Funded = 1982, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed luctus velit a velit consequat, quis elementum diam sagittis. Duis aliquet est elit, eu pulvinar erat rutrum ac. Sed ipsum augue, posuere quis est vel, aliquet condimentum arcu. Duis sagittis convallis orci at consectetur. Vestibulum auctor at nibh eget suscipit. Nam id justo in turpis dignissim iaculis. Vestibulum a libero vitae diam euismod volutpat et placerat nisi. Duis felis massa, cursus a porttitor vitae, commodo sit amet massa. Phasellus in lacinia massa, nec porta ipsum. Integer nec tortor a sapien viverra ultrices. Sed dolor felis, imperdiet at blandit sit amet, ornare non risus. Aliquam tempor quam velit. In a commodo ligula, in placerat sem." };
            DataObjects.Producer DummyProducer4 = new DataObjects.Producer() { ID = 4, Name = "Dummy 4", Funded = 1990, Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed luctus velit a velit consequat, quis elementum diam sagittis. Duis aliquet est elit, eu pulvinar erat rutrum ac. Sed ipsum augue, posuere quis est vel, aliquet condimentum arcu. Duis sagittis convallis orci at consectetur. Vestibulum auctor at nibh eget suscipit. Nam id justo in turpis dignissim iaculis. Vestibulum a libero vitae diam euismod volutpat et placerat nisi. Duis felis massa, cursus a porttitor vitae, commodo sit amet massa. Phasellus in lacinia massa, nec porta ipsum. Integer nec tortor a sapien viverra ultrices. Sed dolor felis, imperdiet at blandit sit amet, ornare non risus. Aliquam tempor quam velit. In a commodo ligula, in placerat sem." };

            _producers.Add(DummyProducer1);
            _producers.Add(DummyProducer2);
            _producers.Add(DummyProducer3);
            _producers.Add(DummyProducer4);


            Array gameTypeValues = Enum.GetValues(typeof(GameType));

            for (int i=0; i<100; i++)
            {
                DataObjects.Game game = new DataObjects.Game()
                {
                    ID = (i + 1),
                    Name = RandomString(10),
                    Price = _random.Next(20, 200),
                    Producer = _producers[_random.Next(1, 4)],
                    ReleaseDate = new DateTime(_random.Next(1990, 2015), _random.Next(1, 12), _random.Next(1, 28)),
                    Type = (GameType)gameTypeValues.GetValue(_random.Next(gameTypeValues.Length)),
                };

                _games.Add(game);
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
