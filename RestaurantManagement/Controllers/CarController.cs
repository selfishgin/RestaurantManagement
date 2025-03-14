using Application.CQRS.Cars;
using Domain.Entities;
using Domain.Enum;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarController : ControllerBase
{
	private readonly CarService _carService;

	public CarController(CarService carService)
	{
		_carService = carService ?? throw new ArgumentNullException(nameof(carService));
	}

	[HttpGet("GetPrice")]
	public IActionResult GetPrice(int id, PriceType priceType)
	{
		try
		{
			var price = _carService.GetCarPrice(id, priceType);
			return Ok(new { CarId = id, PriceType = priceType.ToString(), Price = price });
		}
		catch (Exception ex)
		{
			return BadRequest(new { error = ex.Message });
		}
	}

	[HttpGet("GetAllCars")]
	public IActionResult GetAllCars()
	{
		List<Car> cars = _carService.GetAllCars();
		return Ok(cars);
	}
}