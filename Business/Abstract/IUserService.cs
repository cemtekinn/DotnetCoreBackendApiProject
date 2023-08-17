using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        IResult Add(User user);
        IDataResult<User> GetByEmail(string email);
        IDataResult<User> GetByMail(string mail);
        IDataResult<List<User>> GetAll();    
       
    }
}
