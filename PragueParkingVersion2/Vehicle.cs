




namespace PragueParking
{
    public abstract class Vehicle
    {
        public string LicensePlate { get; set; } // License plate of the vehicle
        public DateTime ArrivalTime { get; set; } // Arrival time
        public abstract double Size { get; } // Abstract size property that must be overridden
    }
}
