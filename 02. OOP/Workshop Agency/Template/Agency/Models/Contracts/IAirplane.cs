using Agency.Models.Enums;

namespace Agency.Models.Contracts
{
    public interface IAirplane
    {
        VehicleType Type
        {
            get;
        }

        int PassangerCapacity
        {
            get;
        }

        double PricePerKilometer
        {
            get;
        }

        bool IsLowCost
        {
            get;
        }
    }
}