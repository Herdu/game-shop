namespace MateuszDobrowolski.Interfaces
{
    public interface IProducer
    {
        int ID { get; set; }
        string Name { get; set; }
        int Funded { get; set; }
        string Description { get; set; }
    }
}
