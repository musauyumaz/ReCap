using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManagerBase : IAuthService<User, UserForLoginDto>
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManagerBase(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user,claims);
            return new SuccessDataResult<AccessToken>(accessToken, "Token oluşturuldu");
        }

        public IDataResult<User> Login(UserForLoginDto dto)
        {
            var user = _userService.GetByEmail(dto.Email);
            var rule = BusinessRules.Run(userToCheck(dto.Email,dto.Password,user.Data.PasswordHash,user.Data.PasswordSalt));
            if (!rule.Success)
            {
                return new ErrorDataResult<User>(rule.Message);
            }
            return new SuccessDataResult<User>(user.Data,"Başarılı Giriş");
        }
        public IResult userToCheck(string email,string password,byte[] passwordHash,byte[] passwordSalt)
        {
            var userControl = _userService.GetByEmail(email);
            var passwordControl = HashingHelper.VerifyPasswordHash(password,passwordHash,passwordSalt);
            if (userControl == null)
            {
                return new ErrorResult("Kullanıcı Bulunamadı");
            }
            if (passwordControl==false)
            {
                return new ErrorResult("Parola Hatası");
            }
            return new SuccessResult("Başarılı Giriş");
        }
    }
}
