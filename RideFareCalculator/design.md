# Ride Fare Calculator

Build a ride fare calculation system for a ride-booking application.

The system should calculate the fare for a completed ride.

- Create a ride
- Select a Pricing Model
- Calculate a Fare
- Get a Final Fare


## Entities
- Ride
  - StartingLocation
  - Desitination
  - DistanceTravelled
  - Duration

## Enums 
- PricingModel
  - Regular
  - Premium
  - Surge

## Interfaces
- IPricingStrategy
  - GetPrice()

## Strategies
- RegularPricingStrategy : GetPrice()
- PremimiumPricingStrategy : GetPrice()
- SurgePricingStrategy : GetPrice()

## Service
- RideCalculationService (pricingStrategy)
  - CalculateFare(Ride)

## Factory
- PricingStrategyFactory

## Regular
- Base fare: ₹50    
- ₹15 per kilometre
-₹2 per minute

## Premium
- Base fare: ₹100
- ₹25 per kilometre
- ₹4 per minute

## Surge
- Calculate the regular fare first.
- Apply a surge multiplier of 1.5×.