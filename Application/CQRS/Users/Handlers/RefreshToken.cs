﻿using Common.GlobalResponse;
using Common.GlobalResponse.Generics;
using MediatR;
using Microsoft.Extensions.Configuration;
using Repository.Common;
using System.Security.Claims;

namespace Application.CQRS.Users.Handlers;

public class RefreshTokenService
{
    public class RefreshTokenRequest : IRequest<ResponseModel<string>>
    {
        public string Token { get; set; }
    }

    public class Handler(IUnitOfWork unitOfWork, IConfiguration configuration) : IRequestHandler<RefreshTokenRequest, ResponseModel<string>>
    {

        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IConfiguration _configuration = configuration;



        public async Task<ResponseModel<string>> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            var refreshToken = await _unitOfWork.RefreshTokenRepository.GetStoredRefreshToken(request.Token);

            if (refreshToken.ExpirationDate<DateTime.UtcNow || refreshToken == null) 
            {
                throw new InvalidOperationException();            
            }

            var currentUser = await _unitOfWork.UserRepository.GetByIdAsync(refreshToken.UserId);

            List<Claim> authClaim = [
                new Claim(ClaimTypes.NameIdentifier , currentUser.Id.ToString()),
                new Claim(ClaimTypes.Name , currentUser.Name),
                new Claim(ClaimTypes.Email , currentUser.Email),
                new Claim(ClaimTypes.MobilePhone , currentUser.Phone),
                new Claim(ClaimTypes.Role, currentUser.Roles.ToString())
            ];

        }
    }
}
