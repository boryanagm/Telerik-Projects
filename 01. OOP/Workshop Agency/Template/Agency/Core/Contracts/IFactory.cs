using Agency.Models.Contracts;

namespace Agency.Core.Contracts
{
    public interface IFactory
    {
        IBus CreateBus(int passengerCapacity, double pricePerKilometer, bool hasFreeTv);

        IAirplane CreateAirplane(int passengerCapacity, double pricePerKilometer, bool isLowCost);

        ITrain CreateTrain(int passengerCapacity, double pricePerKilometer, int carts);

        IJourney CreateJourney(string startingLocation, string destination, int distance, IVehicle vehicle);

        ITicket CreateTicket(IJourney journey, double administrativeCosts);
    }
}
