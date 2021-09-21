using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        DataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByEmailandPassword(string email,byte[] passwordSalt, byte[] passwordHash);
        IDataResult<User> GetByEmail(string email);
    }
}
