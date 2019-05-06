namespace AbacusNext_CarPark
{
    public interface IChargeBase
    {
        decimal TotalUnits();
        decimal StayCharge { get; set; }
    }
}
