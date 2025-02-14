using Application.CQRS.Categories.Queries.Requests;
using Application.CQRS.Categories.Queries.Responds;
using Common.GlobalResponse.Generics;
using Domain.Entities;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Categories.Handlers;

public class GetByIdCategoryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetByIdCategoryRequest, ResponseModel<GetByIdCategoryResponse>>
{
	private readonly IUnitOfWork _unitOfWork=unitOfWork;

	public async Task<ResponseModel<GetByIdCategoryResponse>> Handle(GetByIdCategoryRequest request, CancellationToken cancellationToken)
	{
		Category currentCategory = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);

		if (currentCategory == null)
		{
			return new ResponseModel<GetByIdCategoryResponse>
			{
				Data = null,
				Errors = ["The Category does not exist with provided id"],
				IsSuccess = false
			};
		}

		GetByIdCategoryResponse response = new()
		{
			Id = currentCategory.Id,
			CreatedDate = currentCategory.CreatedDate,
			Name = currentCategory.Name,
		};

		return new ResponseModel<GetByIdCategoryResponse>
		{
			Data = response,
			Errors = [],
			IsSuccess = true
		};
	}
}
