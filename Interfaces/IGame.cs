using System;

namespace MateuszDobrowolski.Interfaces
{
    public interface IGame
    {
        int ID { get; set; }
        string Name { get; set; }
        DateTime ReleaseDate { get; set; }
        IProducer Producer { get; set; }
    }
}
