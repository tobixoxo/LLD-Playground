public class RideCalculationService
{
    private readonly IPricingStrategy _priceCalculationStrategy;

    public RideCalculationService(IPricingStrategy priceCalculationStrategy)
    {
        _priceCalculationStrategy = priceCalculationStrategy;
    }

    public decimal CalculateFare(Ride ride)
    {
        decimal finalFare = _priceCalculationStrategy.GetPrice(ride.DistanceTravelled, ride.Duration);
        return finalFare;
    }

}