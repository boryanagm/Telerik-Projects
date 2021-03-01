using Agency.Core.Contracts;
using Agency.Models.Contracts;
using System.Collections.Generic;

namespace Agency.Core
{
    public class Database : IDatabase
    {
        private static IDatabase instance = null;
        public static IDatabase Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Database();
                }

                return instance;
            }
        }

        private readonly List<IVehicle> vehicles = new List<IVehicle>();
        public IList<IVehicle> Vehicles
        {
            get => this.vehicles;
        }

        private readonly List<IJourney> journeys = new List<IJourney>();
        public IList<IJourney> Journeys
        {
            get => this.journeys;
        }
        
        private readonly List<ITicket> tickets = new List<ITicket>();
        public IList<ITicket> Tickets
        {
            get => this.tickets;
        }
    }
}
