using System;

namespace AbacusNext_CarPark
{
    public class LongStayCharge : ChargeBase
    {
        public DateTime StartTimeWithCharge { get; set; }

        public DateTime EndTimeWithCharge { get; set; }

        public const decimal ChargeRate = (decimal) 7.5;

        public LongStayCharge(DateTime startTime, DateTime endTime) 
            : base(ChargeRate, startTime, endTime)
        {
            // We charge the entire day since its a long stay so we move the start time to the start of the day
            // We apply the same for the end of the day
            StartTimeWithCharge = new DateTime(startTime.Year, startTime.Month, startTime.Day, 00, 00, 00);
            EndTimeWithCharge = new DateTime(endTime.Year, endTime.Month, endTime.Day, 23, 59, 59);
            
            if (startTime > endTime){
                throw new Exception("Start Time must be before End Time");
            }
        }

        public override decimal TotalUnits()
        {
            var totaldays = (EndTimeWithCharge - StartTimeWithCharge).TotalDays;
            // rounding up due to huge decimal results
            return (decimal) Math.Round(totaldays);
        }
    }
}
