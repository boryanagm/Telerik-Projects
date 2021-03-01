using System;
using Agency.Core.Contracts;
using Agency.Models;
using Agency.Models.Contracts;

namespace Agency.Core
{
    public class Factory : IFactory
    {
        private static IFactory instance;
        public static IFactory Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Factory();
                }

                return instance;
            }
        }
        
        public IBus CreateBus(int passengerCapacity, double pricePerKilometer, bool hasFreeTv)
        {
            Bus bus = new Bus(passengerCapacity, pricePerKilometer, hasFreeTv);

            return bus;
        }

        public IAirplane CreateAirplane(int passengerCapacity, double pricePerKilometer, bool isLowCost)
        {
            Airplane airplane = new Airplane(passengerCapacity, pricePerKilometer, isLowCost);

            return airplane;
        }

        public ITrain CreateTrain(int passengerCapacity, double pricePerKilometer, int carts)
        {
            Train train = new Train(passengerCapacity, pricePerKilometer, carts);

            return train;
        }
        
        public IJourney CreateJourney(string startLocation, string destination, int distance, IVehicle vehicle)
        {
            Journey journey = new Journey(startLocation, destination, distance, vehicle);

            return journey;
        }

        public ITicket CreateTicket(IJourney journey, double administrativeCosts)
        {
            Ticket ticket = new Ticket(journey, administrativeCosts);

            return ticket;
        }
    }
}
