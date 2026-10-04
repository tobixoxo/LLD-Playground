public class Truck : Vehicle
{

    public Truck(string registrationNumber) : base(registrationNumber, VehicleType.Truck)
    {
        Console.WriteLine($"created {VehicleType}!");
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