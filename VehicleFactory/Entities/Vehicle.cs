public abstract class Vehicle
{
    public Guid Id {get;}
    public string RegistrationNumber {get;}
    public VehicleType VehicleType {get;}

    public Vehicle(string registrationNumber, VehicleType type)
    {
        ArgumentException.ThrowIfNullOrEmpty(registrationNumber);
        Id = Guid.NewGuid();
        RegistrationNumber = registrationNumber;
        VehicleType = type;
    }

    public abstract void Start();
    
    public abstract void Stop();
}