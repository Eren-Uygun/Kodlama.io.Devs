using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Devs.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.AuthFeatures.Rules
{
    public class AuthBusinessRules
    {

        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
        {
            User? user = await _userRepository.GetAsync(u=>u.Email==email);
            if (user != null) throw new BusinessException("Mail already exists");

        }

        public User? UserShouldBeExistsWhenLoggingIn(string email)
        {
            User? user =  _userRepository.Get(u=>u.Email.ToLower() == email);
            if(user == null) throw new BusinessException("User not found"); 
            return user;
        }

        public async Task VerifyUserPassword(String password,byte[] passwordhash , byte[] passwordSalt)
        {
            if(!HashingHelper.VerifyPasswordHash(password,passwordhash,passwordSalt)) throw new BusinessException("Wrong Password");

        }

    }
}
