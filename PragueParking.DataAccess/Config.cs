




namespace PragueParking.DataAccess
{
    public class Config
    {
        public required int TotalParkingSpots { get; set; }
        public required double DefaultSpotSize { get; set; }
        public required List<string> AllowedVehicleTypes { get; set; }
    }
}
