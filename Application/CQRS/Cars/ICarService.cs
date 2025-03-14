using Domain.Enum;
using Domain.Entities;

namespace Application.CQRS.Cars;

public interface ICarService
{
	// decimal GetPrice(int carId, PriceType priceType);
	decimal GetPrice(Car car);

}
