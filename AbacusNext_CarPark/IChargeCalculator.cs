namespace AbacusNext_CarPark
{
    // Can be used for dependency injection but for the sake of hardcoding on the main to make it easier to showcase
    public interface IChargeCalculator
    {
        decimal CalculateTotalCost(IChargeBase charge);
    }
}
