using System;
using AbacusNext_CarPark;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AbacusNext_CarPark_Tests
{
    [TestClass]
    public class ShortStayChargeTests
    {
        [TestMethod]
        public void StartTimeHasToBeBeforeEndTime_ReturnsException()
        {
            Assert.ThrowsException<Exception>(() => new ShortStayCharge(
                new DateTime(2019, 04, 05, 12, 00, 00), new DateTime(2019, 03, 05, 12, 00, 00)));
        }

        [TestMethod]
        public void ParkingOnShortStayWeekends_ReturnsZero()
        {
            var charge_weekend = new ShortStayCharge(new DateTime(2019, 04, 27, 05, 00, 00), new DateTime(2019, 04, 28, 09, 59, 59));

            Assert.AreEqual(0, charge_weekend.TotalUnits());
        }

        [TestMethod]
        public void ParkingOnShortStayOutsideOfPeriod_ReturnsZero()
        {

            var chargeOvernight = new ShortStayCharge(new DateTime(2019, 10, 18, 01, 00, 00), new DateTime(2019, 10, 18, 06, 59, 59));
            var chargeLateNight = new ShortStayCharge(new DateTime(2019, 10, 18, 18, 01, 00), new DateTime(2019, 10, 18, 21, 00, 59));
            
            Assert.AreEqual(0, chargeOvernight.TotalUnits());
            Assert.AreEqual(0, chargeLateNight.TotalUnits());
        }

        [TestMethod]
        public void ValidShortStay_ReturnsExpectedValue()
        {
            var charge = new ShortStayCharge(new DateTime(2019, 05, 07, 16, 00, 00), new DateTime(2019, 05, 09, 20, 20, 10));

            Assert.AreEqual(24.2M, charge.TotalUnits() * 1.10M);
        }
    }
}
