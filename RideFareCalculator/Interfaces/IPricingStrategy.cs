public interface IPricingStrategy
{
    decimal GetPrice(decimal distanceTravelled, TimeSpan duration);
}