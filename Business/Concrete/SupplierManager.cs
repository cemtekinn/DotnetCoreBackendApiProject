using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class SupplierManager : ISupplierService
    {
        ISupplierDal _supplierDal;
        public SupplierManager(ISupplierDal supplierDal)
        {
            _supplierDal = supplierDal;
        }
        public IResult Add(Supplier supplier)
        {
           _supplierDal.Add(supplier);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            Supplier getSupplier = _supplierDal.Get(s => s.Id == id); 
            _supplierDal.Delete(getSupplier);
            return new SuccessResult();

        }

        public IDataResult<List<Supplier>> GetAll()
        {
            return new SuccessDataResult<List<Supplier>>(_supplierDal.GetAll());
        }

        public IResult Update(Supplier supplier)
        {
            _supplierDal.Update(supplier);
            return new SuccessResult();
        }
    }
}
