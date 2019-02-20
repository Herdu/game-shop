using System;
using MateuszDobrowolski.Core;
using MateuszDobrowolski.Interfaces;

namespace MateuszDobrowolski.DAOMock2.DataObjects
{
    class Game : IGame
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IProducer Producer { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public GameType Type { get; set; }

        public Game() {}

        public Game(IGame data)
        {
            ID = data.ID;
            Name = data.Name;
            Producer = data.Producer;
            ReleaseDate = data.ReleaseDate;
            Price = data.Price;
            Type = data.Type;
        }
    }
}
