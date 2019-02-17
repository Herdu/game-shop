using System.Collections.Generic;

namespace MateuszDobrowolski.Interfaces
{
    public interface IDAO
    {
        IEnumerable<IGame> GetAllGames();
        IEnumerable<IProducer> GetAllProducers();
        IEnumerable<IGame> GetGames(string name, int producerId, int gameType);
        IGame NewGame();
        IGame GetGameById(int id);
        void DeleteGame(int gameId);
        void SaveGame(IGame game);
    }
}
    