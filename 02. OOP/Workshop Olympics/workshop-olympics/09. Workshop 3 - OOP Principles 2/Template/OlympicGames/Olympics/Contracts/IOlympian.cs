using OlympicGames.Olympics.Enums;

namespace OlympicGames.Olympics.Contracts
{
    public interface IOlympian
    {
        string FirstName { get; }

        string LastName { get; }

        string Country { get; }

      //  OrderValues OrderValues { get; }  added for test

        string ListOlympians();

        string CreateOlympian();
    }
}
