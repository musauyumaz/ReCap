using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerAuthManager : AuthManagerBase, ICustomerAuthService
    {
        private IUserService _userService;
        private ICustomerService _customerService;
 
        public CustomerAuthManager(IUserService userService,ITokenHelper tokenHelper,ICustomerService customerService) : base(userService, tokenHelper)
        {
            _customerService = customerService;
            _userService = userService;
        }
        public IDataResult<Customer> Register(CustomerForRegisterDto customerForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(customerForRegisterDto.Password,out passwordHash,out passwordSalt);
            var rule = BusinessRules.Run(EmailControl(customerForRegisterDto.Email));
            var customer = new Customer
            {
                Email = customerForRegisterDto.Email,
                FirstName = customerForRegisterDto.FirstName,
                LastName = customerForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CompanyName = customerForRegisterDto.CompanyName,
                Status = true,
                
            };
            if (rule.Success)
            {
                _customerService.Add(customer);
                return new SuccessDataResult<Customer>("Kullanıcı Kayıt Edildi");
            }
            return new ErrorDataResult<Customer>(rule.Message);
        }
        private IResult EmailControl(string email)
        {
            var result = _userService.GetByEmail(email);
            if (result.Data != null)
            {
                return new ErrorResult("Bu kullanıcı sisteme daha önceden kayıt olmuş");
            }
            return new SuccessResult();
        }
    }
}
