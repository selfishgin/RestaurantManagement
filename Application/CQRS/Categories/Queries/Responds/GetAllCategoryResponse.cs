﻿namespace Application.CQRS.Categories.Queries.Responds;

public class GetAllCategoryResponse
{
	public int Id { get; set; }
	public string Name { get; set; }
	public DateTime CreatedDate { get; set; }
	public DateTime UpdatedDate { get; set;}
	public DateTime DeletedDate { get; set; }

}
