public class Car : Vehicle
{
    public Car(string registrationNumber) : base(registrationNumber, VehicleType.Car)
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