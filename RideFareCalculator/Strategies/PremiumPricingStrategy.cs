public class PremiumPricingStrategy : IPricingStrategy
{
    public decimal GetPrice(decimal distanceTravelled, TimeSpan duration)
    {
        return 100 + (25 * distanceTravelled) + (4 * (decimal)duration.TotalMinutes);
    }
}