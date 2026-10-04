# Vehicle Factory

A factory that should be able to generate a vehcile based on its type
vehicle can start or stop, it has a registration number and an id

# Entities
- Vehicle (Abstract Class)
  - Id
  - RegistrationNumber
  - Start() (abstract Method)
  - Stop() (abstract method)
- Bike : Vehicle
- Car : Vehicle
- Truck : Vehicle

# Enum
- VehicleType
  - Car
  - Bike
  - Truck

# VehicleFactory
- CreateVehicle() : Vehicle
