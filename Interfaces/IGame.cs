using System.Collections.Generic;

namespace MateuszDobrowolski.Interfaces
{
    public interface IGame
    {
        int ID { get; set; }
        string Name { get; set; }
        List<IGameRelease> Releases { get; set; }
        IProducer Producer { get; set; }
    }
}
