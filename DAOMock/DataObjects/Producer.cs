using MateuszDobrowolski.Interfaces;

namespace MateuszDobrowolski.DAOMock.DataObjects
{
    class Producer : IProducer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Funded { get; set; }
        public string Description { get; set; }
    }
}
