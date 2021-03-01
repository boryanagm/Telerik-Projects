using Agency.Models.Enums;

namespace Agency.Models.Contracts
{
    public interface IVehicle
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
    }
}