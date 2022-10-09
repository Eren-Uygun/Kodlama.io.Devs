using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Devs.Application.Features.AuthFeatures.Dtos;
using Devs.Application.Features.AuthFeatures.Rules;
using Devs.Application.Services.AuthService;
using Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.AuthFeatures.Commands.Login
{
    public class UserLoginCommand:UserForLoginDto,IRequest<LoggingInDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
    }
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, LoggingInDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private IAuthService _authService;
        private AuthBusinessRules _authBusinessRules;

        public UserLoginCommandHandler(IUserRepository userRepository, IMapper mapper, IAuthService authService, AuthBusinessRules authBusinessRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<LoggingInDto> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        { 
           User user =  _authBusinessRules.UserShouldBeExistsWhenLoggingIn(request.UserForLoginDto.Email);

            await _authBusinessRules.VerifyUserPassword(request.UserForLoginDto.Password,user.PasswordHash,user.PasswordSalt);

            AccessToken createdAccessToken = await _authService.CreateAccessToken(user);
            RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user);
            RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

            LoggingInDto loggingInDto = new()
            {
                 
                 RefreshToken = addedRefreshToken,
                 AccessToken = createdAccessToken,
                 
            };

            return loggingInDto;
        }
    }
    
}
