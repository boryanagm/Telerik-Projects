using Agency.Models.Contracts;
using System.Collections.Generic;

namespace Agency.Core.Contracts
{
    public interface IDatabase
    {
        IList<IVehicle> Vehicles { get; }
        IList<IJourney> Journeys { get; }
        IList<ITicket> Tickets { get; }
    }
}
