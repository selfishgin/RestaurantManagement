namespace Domain.Enum;

public enum PriceType : int
{
	Standart = 1,
	Discounted = 2,
	Premium = 3,
	VIP = 4
}


//GetPrice(int carId, PriceType priceType);