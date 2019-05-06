using System;
using System.Collections.Generic;
using AbacusNext_CarPark.Helper;

namespace AbacusNext_CarPark
{
    public class ShortStayCharge : ChargeBase
    {
        public DateTime StartTimeWithCharge { get; set; }

        public DateTime EndTimeWithCharge { get; set; }

        public const decimal ChargeRate = (decimal) 1.10;

        public ShortStayCharge(DateTime startTime, DateTime endTime)
            : base(ChargeRate, startTime, endTime)
        {
            StartTimeWithCharge = startTime;
            EndTimeWithCharge = endTime;

            if (startTime > endTime)
            {
                throw new Exception("Start Time must be before End Time");
            }
        }

        public override decimal TotalUnits()
        {
            var periods = new List<Tuple<DateTime, DateTime>>();

            var startTimeWithCharge = new DateTime(StartTimeWithCharge.Year, StartTimeWithCharge.Month, StartTimeWithCharge.Day, 8, 0, 0);

            if (StartTimeWithCharge > new DateTime(StartTimeWithCharge.Year, StartTimeWithCharge.Month, StartTimeWithCharge.Day, 18, 0, 0))
            {
                // If the start time is after the end of the charge period then we move for the next day at 8 am
                startTimeWithCharge = WeekHelper.MoveNextDay(startTimeWithCharge);
            }

            while (startTimeWithCharge < EndTimeWithCharge)
            {
                if (WeekHelper.IsWeekday(startTimeWithCharge))
                {
                    //add range to end of day
                    periods.Add(Tuple.Create(startTimeWithCharge,
                        WeekHelper.MoveToEndOfDay(startTimeWithCharge)));
                }

                // move to next day at 8 am
                startTimeWithCharge = WeekHelper.MoveNextDay(startTimeWithCharge);
            }

            return (decimal)ChargeCalculator.CalculatePeriod(periods, StartTimeWithCharge, EndTimeWithCharge);
        }
    }
}
