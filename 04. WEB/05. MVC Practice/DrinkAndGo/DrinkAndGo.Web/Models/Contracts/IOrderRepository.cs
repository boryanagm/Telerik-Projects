namespace DrinkAndGo.Web.Models.Contracts
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
