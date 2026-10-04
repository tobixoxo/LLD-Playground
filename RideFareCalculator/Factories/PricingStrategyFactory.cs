public class PricingStrategyFactory
{
    public IPricingStrategy CreateStrategy(PricingModel pricingModel)
    {
        return pricingModel switch
        {
            PricingModel.Regular => new RegularPricingStrategy(),
            PricingModel.Premium => new PremiumPricingStrategy(),
            PricingModel.Surge => new SurgePricingStrategy(new RegularPricingStrategy()),
            _ => throw new ArgumentException("Invalid PricingModel Type")
        };
    }
}