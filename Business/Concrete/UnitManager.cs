using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UnitManager : IUnitService
    {
        IUnitDal _unitDal;
        public UnitManager(IUnitDal unitDal)
        {
          _unitDal = unitDal;
        }
        public IResult Add(Unit unit)
        {
            _unitDal.Add(unit);
            return new SuccessResult();
        }

        public IDataResult<List<Unit>> GetAll()
        {
           return new SuccessDataResult<List<Unit>>(_unitDal.GetAll());
        }

        public IResult Delete(int unitId)
        {
            Unit findUnit = _unitDal.Get(u => u.Id == unitId);
            if (findUnit != null)
            {
                _unitDal.Delete(findUnit);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult("Birim bulunamadı");
            }
        }

        public IResult Update(Unit unit)
        {
            _unitDal.Update(unit);
            return new SuccessResult();
        }
    }
}
