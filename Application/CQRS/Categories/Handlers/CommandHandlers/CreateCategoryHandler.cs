using Application.CQRS.Categories.Commands.Requests;
using Application.CQRS.Categories.Commands.Responses;
using AutoMapper;
using Common.Exceptions;
using Common.GlobalResopnses.Generics;
using Domain.Entites;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Categories.Handlers.CommandHandlers;

public class CreateCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateCategoryRequest, ResponseModel<CreateCategoryResponse>>
{

    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper=mapper;

    public async Task<ResponseModel<CreateCategoryResponse>> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        //Category newCategory = new()
        //{
        //    Name = request.Name
        //};

        var mappedRequest = _mapper.Map<Category>(request);

        if (string.IsNullOrEmpty(mappedRequest.Name))
        {
            //return new ResponseModel<CreateCategoryResponse>
            //{
            //    Data = null,
            //    Errors = ["Gonderilen melumat bosh ve ya null ola bilmez"],
            //    IsSuccess = false
            //};

            throw new BadRequestException("Gonderilen melumat bosh ve ya null ola bilmez");
        }

        await _unitOfWork.CategoryRepository.AddAsync(mappedRequest);

        //CreateCategoryResponse response = new()
        //{
        //    Id = newCategory.Id,
        //    Name = request.Name,
        //};

        var response = _mapper.Map<CreateCategoryResponse>(mappedRequest);

        return new ResponseModel<CreateCategoryResponse>
        {
            Data = response,
            Errors = [],
            IsSuccess = true
        };

    }
}
