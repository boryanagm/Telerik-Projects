using System.Collections.Generic;

namespace Cosmetics.Contracts
{
    public interface IToothpaste : IProduct
    {
        string Ingredients { get; }
    }
}