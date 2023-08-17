using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditBookManager : ICreditBookService
    {
        ICreditBookDal _creditBookDal;
        public CreditBookManager(ICreditBookDal creditBookDal)
        {
            _creditBookDal = creditBookDal;
        }

        public IResult Add(CreditBook creditBook)
        {
            _creditBookDal.Add(creditBook);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            CreditBook getCreditBookInfo = _creditBookDal.Get(c => c.Id == id);
            _creditBookDal.Delete(getCreditBookInfo);
            return new SuccessResult();
        }

        public IDataResult<List<CreditBookDetailDto>> GetCreditBookDetails()
        {
            return new SuccessDataResult<List<CreditBookDetailDto>>(_creditBookDal.GetCreditBookDetails());
        }

        public IResult Update(CreditBook creditBook)
        {
            _creditBookDal.Update(creditBook);
            return new SuccessResult();
        }
    }
}
