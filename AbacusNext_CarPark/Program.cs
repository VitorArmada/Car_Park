using System;
using Moq;

namespace AbacusNext_CarPark
{
    internal class Program
    {
        private static void Main()
        {
            //Using a generic calculator as it seems more clean for the hardcode but can also use the method within the class
            var calculator = new ChargeCalculator();

            Console.WriteLine("A stay entirely outside of a chargeable period will return " + calculator.CalculateTotalCost(new ShortStayCharge(DateTime.Parse("03/05/2019 18:01:00"),
                DateTime.Parse("03/05/2019 21:00:00"))));

            Console.WriteLine("A short stay from 07/09/2017 16:50:00 to 09/09/2017 19:15:00 would cost " + calculator.CalculateTotalCost(new ShortStayCharge(DateTime.Parse("07/09/2017 16:50:00"), DateTime.Parse("09/09/2017 19:15:00"))));

            Console.WriteLine("A long stay from 07/09/2017 07:50:00 to 09/09/2017 05:20:00 would cost " + calculator.CalculateTotalCost(new LongStayCharge(DateTime.Parse("07/09/2017 07:50:00"), DateTime.Parse("09/09/2017 05:20:00"))));

            Console.ReadLine();
        }
    }
}
