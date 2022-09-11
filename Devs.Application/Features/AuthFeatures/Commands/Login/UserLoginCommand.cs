using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
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
    public class UserLoginCommand:UserForLoginDto,IRequest<AccessToken>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
    }
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, AccessToken>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;

        public UserLoginCommandHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
        }

        public async Task<AccessToken> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetAsyncWithInclude(x=>x.Email.ToLower() == request.UserForLoginDto.Email.ToLower(),include: x=>x.Include(x=>x.UserOperationClaims).ThenInclude(x=>x.OperationClaim));

            var validation = HashingHelper.VerifyPasswordHash(request.UserForLoginDto.Password,result.PasswordSalt,result.PasswordHash);

            //if(!validation) throw new BusinessException("WrongPassword");
             

            List<OperationClaim> operationClaims = new List<OperationClaim>();
            foreach (var operationClaim in result.UserOperationClaims)
            {
                operationClaims.Add(operationClaim.OperationClaim);
            }

            var token = _tokenHelper.CreateToken(result,operationClaims);
            return token;
        }
    }
    
}
