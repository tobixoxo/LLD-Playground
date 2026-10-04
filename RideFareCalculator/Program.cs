
PricingStrategyFactory psf = new PricingStrategyFactory();

IPricingStrategy regular = psf.CreateStrategy(PricingModel.Regular);
IPricingStrategy premium = psf.CreateStrategy(PricingModel.Premium);
IPricingStrategy surge = psf.CreateStrategy(PricingModel.Surge);

RideCalculationService rcs = new RideCalculationService(regular);

Ride ride = new Ride("Chandigarh", "Mohali", 10, TimeSpan.FromMinutes(20));

// regular fare
decimal finalFare = rcs.CalculateFare(ride);
Console.WriteLine($"Calculated fare for ride {ride.StartingLocation} - {ride.Destination} is {finalFare} ");


// premium fare
rcs = new RideCalculationService(premium);
finalFare = rcs.CalculateFare(ride);
Console.WriteLine($"Calculated fare for ride {ride.StartingLocation} - {ride.Destination} is {finalFare} ");

// surge fare
rcs = new RideCalculationService(surge);
finalFare = rcs.CalculateFare(ride);
Console.WriteLine($"Calculated fare for ride {ride.StartingLocation} - {ride.Destination} is {finalFare} ");
