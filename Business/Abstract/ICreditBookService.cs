using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditBookService
    {
        IDataResult<List<CreditBookDetailDto>> GetCreditBookDetails();

        IResult Add(CreditBook creditBook);
        IResult Delete(int id);
        IResult Update(CreditBook creditBook);

    }
}
