using MateuszDobrowolski.Core;
using MateuszDobrowolski.Interfaces;
using System;

namespace MateuszDobrowolski.DAOMock.DataObjects
{
    class GameRelease : IGameRelease
    {
        public DateTime Date { get; set; }
        public Platform Platform { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"platform: {Platform},  date: {Date.ToString("dd.MM.yyyy")}, price: {Price}pln";
        }
    }
}
