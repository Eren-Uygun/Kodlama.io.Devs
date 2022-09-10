using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Devs.Application.Features.AppUserFeatures.Dtos;
using Devs.Application.Features.AppUserFeatures.Rules;
using Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.AppUserFeatures.Commands.LoginAppUser
{
    public class LoginAppUserCommand:UserForLoginDto,IRequest<TokenDto>
    {
        public class LoginAppUserCommandHandler : IRequestHandler<LoginAppUserCommand, TokenDto>
        {
            private readonly IAppUserRepository _appUserRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;

            public LoginAppUserCommandHandler(IAppUserRepository appUserRepository, IMapper mapper, ITokenHelper tokenHelper)
            {
                _appUserRepository = appUserRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
            }

            public async Task<TokenDto> Handle(LoginAppUserCommand request, CancellationToken cancellationToken)
            {
                var appUser = await _appUserRepository.GetAsyncWithInclude(x=>x.Email.ToLower()==request.Email.ToLower(),
                    include: x => x.Include(x => x.UserOperationClaims).ThenInclude(x => x.OperationClaim)
                    );

                List<OperationClaim> operationClaims = new List<OperationClaim>() {};

                foreach(var appUserOperationClaim in appUser.UserOperationClaims)
                {
                    operationClaims.Add(appUserOperationClaim.OperationClaim);
                }

                AccessToken token = _tokenHelper.CreateToken(appUser,operationClaims);
                TokenDto tokenDto = _mapper.Map<TokenDto>(token);
                return tokenDto;

            }
        }
    }
}
