﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
           _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(int customerId)
        {
            Customer customer = _customerDal.Get(c=>c.CustomerId==customerId);
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeletedSuccessfully);
        }

        public IDataResult<List<Customer>> GetAll()
        {
           return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.CustomersListed);
        }

        public IResult Update(Customer customer)
        {
           _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdatedSuccessfully);
        }
    }
}
