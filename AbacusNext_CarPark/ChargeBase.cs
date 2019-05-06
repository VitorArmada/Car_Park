using System;

namespace AbacusNext_CarPark
{
    public abstract class ChargeBase : IChargeBase
    {
        public decimal StayCharge { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public abstract decimal TotalUnits();

        public decimal TotalCharge { get; set; }

        public void CalculateTotal(IChargeBase charge)
        {
            var calculator = new ChargeCalculator();
            TotalCharge = calculator.CalculateTotalCost(charge);
        }

        protected ChargeBase(decimal stayCharge, DateTime entryTime, DateTime endTime)
        {
            StayCharge = stayCharge;
            StartTime = entryTime;
            EndTime = endTime;
        }
    }
}
