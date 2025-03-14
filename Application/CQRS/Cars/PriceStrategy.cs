using Domain.Entities;

namespace Application.CQRS.Cars;

public class StandardPricingStrategy : ICarService
{
	public decimal GetPrice(Car car) => 20000; 
}

public class DiscountedPricingStrategy : ICarService
{
	public decimal GetPrice(Car car) => 18000; 
}

public class PremiumPricingStrategy : ICarService
{
	public decimal GetPrice(Car car) => 25000; 
}

public class VIPPricingStrategy : ICarService
{
	public decimal GetPrice(Car car) => 30000;
}
