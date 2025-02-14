using Application.CQRS.Categories.Commands.Responds;
using Common.GlobalResponse.Generics;
using MediatR;

namespace Application.CQRS.Categories.Commands.Requests;

public class CreateCategoryRequest:IRequest<ResponseModel<CreateCategoryResponse>>
{
	public string Name { get; set; }	

}
