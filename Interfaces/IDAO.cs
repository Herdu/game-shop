using MateuszDobrowolski.Core;
using System.Collections.Generic;

namespace MateuszDobrowolski.Interfaces
{
    public interface IDAO
    {
        IEnumerable<IGame> GetAllGames();
        IEnumerable<IProducer> GetAllProducers();
    }
}
    