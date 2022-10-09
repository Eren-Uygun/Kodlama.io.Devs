using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Devs.Application.Features.AuthFeatures.Dtos;
using Devs.Application.Features.AuthFeatures.Rules;
using Devs.Application.Services.AuthService;
using Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.AuthFeatures.Commands.Register
{
    public class UserRegisterCommand : IRequest<RegisteredDto>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }
    }
    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, RegisteredDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;

        public UserRegisterCommandHandler(IUserRepository userRepository, IMapper mapper, IAuthService authService, AuthBusinessRules authBusinessRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<RegisteredDto> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);

            User registeredUser = new()
            {
                FirstName = request.UserForRegisterDto.FirstName,
                LastName = request.UserForRegisterDto.LastName,
                Email = request.UserForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,

            };

            User createdUser = await _userRepository.AddAsync(registeredUser);

            AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);
            RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser);
            RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

            RegisteredDto registeredDto = new()
            {
                AccessToken =  createdAccessToken,
                RefreshToken = addedRefreshToken
            };

            return registeredDto;



        }
    }

}
