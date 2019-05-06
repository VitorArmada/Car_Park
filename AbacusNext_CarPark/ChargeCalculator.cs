using System;
using System.Collections.Generic;
using System.Linq;

namespace AbacusNext_CarPark
{
    public class ChargeCalculator
    {
        public decimal CalculateTotalCost(IChargeBase charge)
        {
            return Math.Round(charge.StayCharge * charge.TotalUnits(), 2);
        }

        public static double CalculatePeriod(List<Tuple<DateTime, DateTime>> periods, DateTime startTimeWithCharge, DateTime endTimeWithCharge)
        {
            double totalPeriodTime = 0;

            foreach (var period in periods.Select(period =>
            {
                var periodStart = startTimeWithCharge;
                var periodEnd = endTimeWithCharge;

                if (period.Item1 > startTimeWithCharge)
                {
                    periodStart = period.Item1;
                }

                if (period.Item2 < endTimeWithCharge)
                {
                    periodEnd = period.Item2;
                }

                return (periodEnd - periodStart).TotalHours;
            }))
                totalPeriodTime += period;

            return totalPeriodTime;
        }
    }
}
