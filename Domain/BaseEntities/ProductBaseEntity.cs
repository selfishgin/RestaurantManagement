﻿namespace Domain.BaseEntities;

public abstract class ProductBaseEntity : BaseEntity
{
	public string Name { get; set; }
	public string Type { get; set; }
	public string Barcode { get; set; }
	public decimal Price { get; set; }
	public bool OpenPrice { get; set; } // endirimli qiymetin gorunub gorunmemesi
	public string ButtonColor { get; set; }
	public string TextColor { get; set; }
	public string InvoiceNumber { get; set; } // sifaris nomresi
}