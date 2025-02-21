using Application.CQRS.Categories.Commands.Requests;
using Application.CQRS.Categories.Commands.Responds;
using AutoMapper;
using Common.Exceptions;
using Common.GlobalResponse.Generics;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Repository.Common;
using System.ComponentModel.DataAnnotations;

namespace Application.CQRS.Categories.Handlers.CommandHandlers;

public class CreateCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateCategoryRequest> validator) : IRequestHandler<CreateCategoryRequest, ResponseModel<CreateCategoryResponse>>
{

	private readonly IUnitOfWork _unitOfWork = unitOfWork;
	private readonly IMapper _mapper = mapper;
	private readonly IValidator<CreateCategoryRequest> _validator = validator;

	public async Task<ResponseModel<CreateCategoryResponse>> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
	{
		var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
			throw new ValidationException(validationResult.Errors);
        }



        if (string.IsNullOrEmpty(request.Name))
		{
			//return new ResponseModel<CreateCategoryResponse>
			//{
			//	Data = null,
			//	Errors = ["Gonderilen melumat bosh ve ya null ola bilmez"],
			//	IsSuccess = false
			//};

			throw new BadRequestException("Gonderilen melumat bosh ve ya null ola bilmez");
		}

		await _unitOfWork.CategoryRepository.AddAsync(newCategory);

		CreateCategoryResponse response = new()
		{
			Id = newCategory.Id,
			Name = request.Name,
		};

		return new ResponseModel<CreateCategoryResponse>
		{
			Data = response,
			Errors = [],
			IsSuccess = true
		};

	}
}
