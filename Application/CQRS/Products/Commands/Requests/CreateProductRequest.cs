using Application.CQRS.Categories.Commands.Responds;
using Application.CQRS.Categories.Commands.Responses;
using Common.GlobalResponse.Generics;
using MediatR;

namespace Application.CQRS.Categories.Commands.Requests;

public class CreateProductRequest : IRequest<ResponseModel<CreateProductResponse>>
{
	public string Name { get; set; }
}