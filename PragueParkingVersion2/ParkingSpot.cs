




using System.Linq;

namespace PragueParking
{
    public class ParkingSpot
    {
        public int SpotNumber { get; set; }
        public double MaxSize { get; set; } = 1.0; // Default size
        public List<Vehicle> Vehicles { get; set; } = new(); // Ensure it's initialized

        // Checks if the vehicle can fit in this spot based on size
        public bool CanFitVehicle(Vehicle vehicle)
        {
            double currentSize = Vehicles.Sum(v => v.Size);
            return currentSize + vehicle.Size <= MaxSize;
        }
    }
}
