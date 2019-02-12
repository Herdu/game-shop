using MateuszDobrowolski.Interfaces;
using System;
using System.Collections.Generic;


namespace MateuszDobrowolski.GameShop
{
    class Shop
    {
        static void Main(string[] args)
        {
            IDAO IDAO = new DAOMock.DB();
           IEnumerable<IGame> Games = IDAO.GetAllGames(); 
            foreach(var Game in Games)
            {
                Console.WriteLine(Game);
            }
        }
    }
}
