using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Devs.Application.Features.AppUserFeatures.Dtos;
using Devs.Application.Features.AppUserFeatures.Rules;
using Devs.Application.Services.Repositories;
using Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.AppUserFeatures.Commands.RegisterAppUser
{
    public class RegisterAppUserCommand:UserForRegisterDto, IRequest<TokenDto>
    {
        public class RegisterAppUserCommandHandler : IRequestHandler<RegisterAppUserCommand, TokenDto>
        {
            private readonly IAppUserRepository _appUserRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;

            public RegisterAppUserCommandHandler(IAppUserRepository appUserRepository, IMapper mapper, ITokenHelper tokenHelper)
            {
                _appUserRepository = appUserRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
            }

            public async Task<TokenDto> Handle(RegisterAppUserCommand request, CancellationToken cancellationToken)
            {
                byte[] passwordHash,passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password,out passwordHash,out passwordSalt);

                AppUser appUser = _mapper.Map<AppUser>(request);
                appUser.PasswordSalt = passwordSalt;
                appUser.PasswordHash = passwordHash;

                AppUser createdAppUser = await _appUserRepository.AddAsync(appUser);
                AccessToken accessToken = _tokenHelper.CreateToken(appUser,new List<OperationClaim>());
                TokenDto createdToken = _mapper.Map<TokenDto>(accessToken);
                

                return createdToken;
            }
        }

    }
}
