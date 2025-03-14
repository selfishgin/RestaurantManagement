using DAL.SqlServer.Context;
using Domain.Entities;
using Domain.Enum;

namespace Application.CQRS.Cars;
public class CarService
{
	private readonly List<Car> _cars;
	private readonly CarPriceCalculator _priceCalculator;

	public CarService()
	{
		_priceCalculator = new CarPriceCalculator();

		// Sample Car Data
		_cars = new List<Car>
		{
			new Car { Id = 1, Model = "Camry", Vendor = "Toyota", Year = new DateTime(2020, 1, 1), PriceType = PriceType.Standart },
			new Car { Id = 2, Model = "Accord", Vendor = "Honda", Year = new DateTime(2021, 1, 1), PriceType = PriceType.Premium },
			new Car { Id = 3, Model = "A4", Vendor = "Audi", Year = new DateTime(2022, 1, 1), PriceType = PriceType.VIP }
		};
	}

	public decimal GetCarPrice(int carId, PriceType priceType)
	{
		var car = _cars.FirstOrDefault(c => c.Id == carId);
		if (car == null)
		{
			throw new Exception("Car not found");
		}
		return _priceCalculator.GetPrice(car, priceType);
	}

	public List<Car> GetAllCars() => _cars;
}