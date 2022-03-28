namespace FoodShortage.Interfaces
{
    public interface IBuyer
    {
        int BuyFood();
        int Food { get; }
        string Name { get; }
    }
}
