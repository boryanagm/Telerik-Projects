using Agency.Models.Enums;

namespace Agency.Models.Contracts
{
    public interface IBus
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

        bool HasFreeTv
        {
            get;
        }
    }
}