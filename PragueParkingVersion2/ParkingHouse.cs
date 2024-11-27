




using PragueParking.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace PragueParking
{
    public class ParkingHouse
    {
        public required List<ParkingSpot> Spots { get; set; } // Null-säker

        public static ParkingHouse LoadFromFiles()
        {
            var config = DataManager.LoadData<Config>("config.json");

            // Om konfigurationsfilen saknas, använd standardvärden
            if (config == null)
            {
                config = new Config
                {
                    TotalParkingSpots = 100,
                    DefaultSpotSize = 1.0,
                    AllowedVehicleTypes = new List<string> { "Car", "Motorcycle" }
                };
                DataManager.SaveData("config.json", config);
            }

            var spots = Enumerable.Range(1, config.TotalParkingSpots)
                .Select(i => new ParkingSpot { SpotNumber = i, MaxSize = config.DefaultSpotSize })
                .ToList();

            return new ParkingHouse { Spots = spots };
        }

        public string GetMap()
        {
            return string.Join("\n", Spots.Select(s =>
                $"Plats {s.SpotNumber}: {s.Vehicles.Count} fordon"));
        }

        public void ParkVehicle(Vehicle vehicle)
        {
            foreach (var spot in Spots)
            {
                if (spot.CanFitVehicle(vehicle))
                {
                    spot.Vehicles.Add(vehicle);
                    Console.WriteLine($"Fordonet ({vehicle.LicensePlate}) parkerades på plats {spot.SpotNumber}.");
                    DataManager.SaveData("data.json", Spots);  // Uppdaterar datakällan
                    return;
                }
            }

            Console.WriteLine("Ingen ledig plats för detta fordon!");
        }

        public void RemoveVehicle(string licensePlate)
        {
            foreach (var spot in Spots)
            {
                var vehicle = spot.Vehicles.FirstOrDefault(v => v.LicensePlate == licensePlate);
                if (vehicle != null)
                {
                    spot.Vehicles.Remove(vehicle);
                    Console.WriteLine($"Fordonet ({licensePlate}) togs bort från plats {spot.SpotNumber}.");
                    DataManager.SaveData("data.json", Spots);  // Uppdaterar datakällan
                    return;
                }
            }

            Console.WriteLine("Fordonet kunde inte hittas.");
        }

        public void ReloadFiles()
        {
            Spots = DataManager.LoadData<List<ParkingSpot>>("data.json");
        }
    }
}
