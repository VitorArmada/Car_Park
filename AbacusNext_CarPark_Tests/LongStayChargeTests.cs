using System;
using AbacusNext_CarPark;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AbacusNext_CarPark_Tests
{
    [TestClass]
    public class LongStayChargeTests
    {
        [TestMethod]
        public void StartTimeHasToBeBeforeEndTime_ReturnsException()
        {
            Assert.ThrowsException<Exception>(() => new LongStayCharge(
                new DateTime(2019, 04, 05, 12, 00, 00), new DateTime(2019, 03, 05, 12, 00, 00)));
        }

        [TestMethod]
        public void StayForShortPeriod_ReturnsFullDay()
        {
            var charge = new LongStayCharge(
                new DateTime(2019, 09, 01, 00, 00, 00), new DateTime(2019, 09, 01, 00, 00, 00)
            );

            Assert.AreEqual(1.7M, charge.TotalUnits() * 1.7M);
        }

        [TestMethod]
        public void StayForLongerPeriodInTheDay_ReturnsFullDay()
        {
            var charge = new LongStayCharge(
                new DateTime(2019, 05, 03, 00, 00, 00), new DateTime(2019, 05, 03, 23, 59, 00)
            );

            Assert.AreEqual(1.7M, charge.TotalUnits() * 1.7M);
        }

        [TestMethod]
        public void StayForLongerPeriodInMultipleDays_ReturnsExpectedValue()
        {
            var charge = new LongStayCharge(
                new DateTime(2019, 05, 06, 00, 00, 00), new DateTime(2019, 05, 09, 23, 00, 00)
            );

            Assert.AreEqual(6.8M, charge.TotalUnits() * 1.7M);
        }

    }
}
