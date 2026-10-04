public class Bike : Vehicle
{
    public Bike(string registrationNumber) : base(registrationNumber, VehicleType.Bike)
    {
        Console.WriteLine($"created {base.VehicleType}!");
    }
 
    public override void Start()
    {
        Console.WriteLine($"{VehicleType} Started!");
    }
    
    public override void Stop()
    {
        Console.WriteLine($"{VehicleType} Stopped");        
    }
}