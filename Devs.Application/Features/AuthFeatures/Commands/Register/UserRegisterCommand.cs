using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.AuthFeatures.Commands.Register
{
    public class UserRegisterCommand:IRequest
    {
        public  UserForRegisterDto UserForRegisterDto {get;set;}
    }
    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, Unit>
        { 
            private readonly IUserRepository _repository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;

            public UserRegisterCommandHandler(IUserRepository repository, IMapper mapper, ITokenHelper tokenHelper)
            {
                _repository = repository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
            }

            public async Task<Unit> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
            {
                 byte[] passwordHash, passwordSalt;
                 HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);



                var registeredUser = new User
                {
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName,
                    Email = request.UserForRegisterDto.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true,
                    
                };

                 await _repository.AddAsync(registeredUser);
                //var token = _tokenHelper.CreateToken(newUser,new List<OperationClaim>());
               //UserForRegisterDto userForRegisterDto = _mapper.Map<UserForRegisterDto>(newUser);
                return Unit.Value;

            }
        }
    
}
