using System;
using MateuszDobrowolski.Interfaces;

namespace MateuszDobrowolski.DAOMock.DataObjects
{
    class Game : IGame
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IProducer Producer { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Game() {}

        public Game(IGame data)
        {
            ID = data.ID;
            Name = data.Name;
            Producer = data.Producer;
            ReleaseDate = data.ReleaseDate;
        }
    }
}
