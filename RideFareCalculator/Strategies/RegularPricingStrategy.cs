public class RegularPricingStrategy : IPricingStrategy
{
    public decimal GetPrice(decimal distanceTravelled, TimeSpan duration)
    {
        return 50 + (15 * distanceTravelled) + (2 * (decimal) duration.TotalMinutes);
    }
}