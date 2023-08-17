using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISupplierService
    {
        IDataResult<List<Supplier>> GetAll();
        IResult Add(Supplier supplier);
        IResult Delete(int id);
        IResult Update(Supplier supplier);

    }
}
