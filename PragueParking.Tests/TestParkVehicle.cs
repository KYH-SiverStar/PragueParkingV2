





using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PragueParking.Tests
{
    [TestClass]
    public class TestParkVehicle
    {
        [TestMethod]
        public void TestParkingCapacity()
        {
            var spot = new ParkingSpot { MaxSize = 1.0 };
            var car = new Car { LicensePlate = "ABC123" };

            spot.Vehicles.Add(car);

            Assert.AreEqual(1, spot.Vehicles.Count);
        }
    }
}


