namespace Agency.Models.Contracts
{
    public interface IJourney
    {
        string StartLocation
        {
            get;
        }

        string Destination
        {
            get;
        }

        int Distance
        {
            get;
        }

        IVehicle Vehicle
        {
            get;
        }

        double CalculatePrice();
    }
}