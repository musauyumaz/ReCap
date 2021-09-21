using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthService<TEntity,TDto> where TEntity : class, IEntity where TDto : class, IDto
    {
        IDataResult<TEntity> Login(TDto dto);
        IDataResult<AccessToken> CreateAccessToken(TEntity entity);
    }
} 
