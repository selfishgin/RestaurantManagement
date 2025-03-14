using Domain.Enum;
using Domain.Entities;


namespace Application.CQRS.Cars;

public class CarPriceCalculator
{
	private readonly Dictionary<PriceType, ICarService> _strategies;

	public CarPriceCalculator()
	{
		_strategies = new Dictionary<PriceType, ICarService>
		{
			{ PriceType.Standart, new StandardPricingStrategy() },
			{ PriceType.Discounted, new DiscountedPricingStrategy() },
			{ PriceType.Premium, new PremiumPricingStrategy() },
			{ PriceType.VIP, new VIPPricingStrategy() }
		};
	}

	public decimal GetPrice(Car car, PriceType priceType)
	{
		if (_strategies.ContainsKey(priceType))
		{
			return _strategies[priceType].GetPrice(car);
		}
		throw new ArgumentException("Invalid price type");
	}
}
