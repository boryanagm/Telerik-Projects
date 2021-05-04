namespace DrinkAndGo.Web.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public Drink Drink { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId {get;set;}
    }
}
