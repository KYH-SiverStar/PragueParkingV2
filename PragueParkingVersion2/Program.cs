



using PragueParking;
using Spectre.Console;

var parkingHouse = ParkingHouse.LoadFromFiles();

void DisplayMenu()
{
    while (true)
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[blue]Vad vill du göra?[/]")
                .AddChoices("Parkera ett fordon", "Ta bort ett fordon", "Visa karta", "Ladda om filer", "Avsluta"));

        switch (choice)
        {
            case "Parkera ett fordon":
                ParkVehicle(); // Calls the method to park a vehicle
                break;
            case "Ta bort ett fordon":
                RemoveVehicle(); // Calls the method to remove a vehicle
                break;
            case "Visa karta":
                AnsiConsole.WriteLine(parkingHouse.GetMap());
                break;
            case "Ladda om filer":
                parkingHouse.ReloadFiles();
                break;
            case "Avsluta":
                return;
        }
    }
}

void ParkVehicle()
{
    var licensePlate = AnsiConsole.Prompt(new TextPrompt<string>("Ange registreringsnummer:"));
    var vehicleType = AnsiConsole.Prompt(new SelectionPrompt<string>()
        .Title("Välj fordonstyp")
        .AddChoices("Car", "Motorcycle"));

    Vehicle vehicle;
    switch (vehicleType)
    {
        case "Car":
            vehicle = new Car { LicensePlate = licensePlate }; // Assuming Car class exists
            break;
        case "Motorcycle":
            vehicle = new Motorcycle { LicensePlate = licensePlate }; // Assuming Motorcycle class exists
            break;
        default:
            AnsiConsole.WriteLine("Ogiltig fordonstyp.");
            return;
    }

    parkingHouse.ParkVehicle(vehicle); // Pass the vehicle to be parked
}

void RemoveVehicle()
{
    var licensePlate = AnsiConsole.Prompt(new TextPrompt<string>("Ange registreringsnummer för att ta bort:"));
    parkingHouse.RemoveVehicle(licensePlate); // Pass the license plate to remove the vehicle
}

DisplayMenu();
