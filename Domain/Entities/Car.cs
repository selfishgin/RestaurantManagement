using Domain.Enum;

namespace Domain.Entities;

public class Car
{
	public int Id { get; set; }
	public string Model { get; set; }
	public string Vendor { get; set; }
	public DateTime Year { get; set; }
	public PriceType PriceType { get; set; }
}
