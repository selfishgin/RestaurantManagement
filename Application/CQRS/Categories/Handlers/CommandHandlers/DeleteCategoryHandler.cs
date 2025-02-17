using Application.CQRS.Categories.Commands.Requests;
using Application.CQRS.Categories.Commands.Responds;
using Common.GlobalResponse.Generics;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Categories.Handlers.CommandHandlers;

public class DeleteCategoryHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCategoryRequest, ResponseModel<DeleteCategoryResponse>>
{
	private readonly IUnitOfWork _unitOfWork = unitOfWork;

	public async Task<ResponseModel<DeleteCategoryResponse>> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
	{
		bool isTrue = await _unitOfWork.CategoryRepository.Remove(request.Id, 0);

		return new ResponseModel<DeleteCategoryResponse>
		{
			Data = new DeleteCategoryResponse { Message = "Deleted Succesfully" },
			Errors = [],
			IsSuccess = true
		};
	}

}
