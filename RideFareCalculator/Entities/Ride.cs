public class Ride
{
    public string StartingLocation {get; set;}
    public string Destination {get; set;}
    public decimal DistanceTravelled {get; set;}
    public TimeSpan Duration {get; set;}

    public Ride(string startingLocation, string destination, decimal distanceTravelled, TimeSpan duration)
    {
        StartingLocation = startingLocation;
        Destination = destination;
        DistanceTravelled = distanceTravelled;
        Duration = duration;
    }
}