using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUnitService
    {
        IDataResult<List<Unit>> GetAll();
        IResult Add(Unit unit);
        IResult Delete(int unitId);
        IResult Update(Unit unit);

    }
}
