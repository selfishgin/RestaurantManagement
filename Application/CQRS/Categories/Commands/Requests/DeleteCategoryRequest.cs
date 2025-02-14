using Application.CQRS.Categories.Commands.Responds;
using Common.GlobalResponse.Generics;
using MediatR;

namespace Application.CQRS.Categories.Commands.Requests;

public record struct DeleteCategoryRequest : IRequest<ResponseModel<DeleteCategoryResponse>>
{
	public int Id { get; set; }
}
