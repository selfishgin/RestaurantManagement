using Application.CQRS.Categories.Commands.Requests;
using Application.CQRS.Categories.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(ISender sender) : ControllerBase
{
	//private readonly ISender _sender = sender;

	//[HttpPost]
	//public async Task<IActionResult> Create(CreateProductRequest request)
	//{
	//	return Ok(await _sender.Send(request));
	//}

	//[HttpGet("{id}")]
	//public async Task<IActionResult> GetById(int id)
	//{
	//	var request = new GetByIdProductRequest() { Id = id };
	//	return Ok(await _sender.Send(request));
	//}

}
