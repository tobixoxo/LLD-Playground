
VehicleFactory vh = new VehicleFactory();

Vehicle bike = vh.CreateVehicle("BIKE01", VehicleType.Bike);

bike.Start();
bike.Stop();

Vehicle car = vh.CreateVehicle("BIKE01", VehicleType.Car);
car.Start();
car.Stop();

Vehicle truck = vh.CreateVehicle("BIKE01", VehicleType.Truck);
truck.Start();
truck.Stop();

// validates the argument null exception 
// Vehicle badTruck = vh.CreateVehicle(null, VehicleType.Truck);