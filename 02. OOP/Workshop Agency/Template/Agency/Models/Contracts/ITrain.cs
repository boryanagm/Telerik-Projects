using Agency.Models.Enums;

namespace Agency.Models.Contracts
{
    public interface ITrain
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

        int Carts
        {
            get;
        }
    }
}