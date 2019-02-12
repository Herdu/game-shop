using System;
using System.Collections.Generic;
using MateuszDobrowolski.Core;
using MateuszDobrowolski.Interfaces;

namespace MateuszDobrowolski.DAOMock.DataObjects
{
    class Game : IGame
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IProducer Producer { get; set; }
        public List<IGameRelease> Releases { get; set; }

        public override string ToString()
        {
            return $" \n {Name} \n producer: {Producer.Name} \n releases: \n   {(Releases.ToArray().Length > 0 ? String.Join("\n   ", Releases) : "none")} \n";
        }
    }


}
