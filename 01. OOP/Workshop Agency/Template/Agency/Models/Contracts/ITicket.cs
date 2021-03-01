namespace Agency.Models.Contracts
{
    public interface ITicket
    {
        double AdministrativeCosts
        {
            get;
        }

        IJourney Journey
        {
            get;
        }

        double CalculatePrice();
    }
}