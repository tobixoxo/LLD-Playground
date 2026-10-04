public class VehicleFactory
{
    public Vehicle CreateVehicle( string registrationNumber, VehicleType type)
    {
        switch (type)
        {
            case VehicleType.Car:
                return new Car(registrationNumber);
            case VehicleType.Bike:
                return new Bike(registrationNumber);
            case VehicleType.Truck:
                return new Truck(registrationNumber);
            default:
                throw new ArgumentException("Invalid vehicle type");
        }
    }
}