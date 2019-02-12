using System;
using MateuszDobrowolski.Core;

namespace MateuszDobrowolski.Interfaces
{
    public interface IGameRelease
    {
        DateTime Date { get; set; }
        Platform Platform { get; set; }
        decimal Price { get; set; }
}
}
