using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Application.CQRS.Users.Handlers.GetById;

namespace RestaurantManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(ISender sender) : ControllerBase
{
	private readonly ISender _sender = sender;

	[HttpGet]
	public async Task<IActionResult> GetById([FromQuery]int id)
	{
		var request = new Query() { Id = id };
		return Ok(await _sender.Send(request));
	}
}
