public class SurgePricingStrategy : IPricingStrategy
{

    private readonly IPricingStrategy _basePricingStrategy;

    public SurgePricingStrategy(IPricingStrategy basePricingStrategy)
    {
        _basePricingStrategy = basePricingStrategy;    
    }

    public decimal GetPrice(decimal distanceTravelled, TimeSpan duration)
    {
        // decimal baseFare = 50 + (15 * distanceTravelled) + (2 * (decimal)duration.TotalMinutes);
        
        decimal baseFare = _basePricingStrategy.GetPrice(distanceTravelled, duration);
        return baseFare * (decimal)1.5;
    }
}