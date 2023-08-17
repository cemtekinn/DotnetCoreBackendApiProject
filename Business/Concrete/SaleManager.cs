using Business.Abstract;

using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Business.Concrete
{
    public class SaleManager : ISaleService
    {
        ISaleDal _saleDal;

        IProductService _productService;
        public SaleManager(ISaleDal saleDal,IProductService productService)
        {
            _saleDal = saleDal;
            _productService = productService;
        }
        public IResult Add(Sale sale)
        {
           _saleDal.Add(sale);
            return new SuccessResult();
        }

        public IResult AddSale(string productsJson,int creditBookId)
        {

            //List<ProductDetailDto> products = new List<ProductDetailDto>
            //{
            //    new ProductDetailDto { ProductID = 1, ProductName = "Product 2",BarcodeNumber=}
            //};
            //string productsJson = JsonSerializer.Serialize(products);

            Sale sale = new Sale
            {
                Products = productsJson,
                SalesDate = DateTime.Now,
                CreditBookId = creditBookId
            };

            Add(sale);
            return new SuccessResult();
        }

        public IResult CreatePdf()
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int id)
        {
            Sale getSale=_saleDal.Get(s=>s.Id == id);
            _saleDal.Delete(getSale);
            return new SuccessResult();
        }

        public IDataResult<List<Sale>> GetAll()
        {
            return new SuccessDataResult<List<Sale>>(_saleDal.GetAll());
        }

        public IDataResult<List<SaleDetailDTO>> GetAllSalesDetails()
        {
            
            return new SuccessDataResult<List<SaleDetailDTO>>(_saleDal.GetSalesDetails());  
        }
     


        public IDataResult<List<SaleDetailDTO>> GetAllSalesDetailsByDate(DateTime date)
        {
            return new SuccessDataResult<List<SaleDetailDTO>>(_saleDal.GetAllSalesDetailsByDate(date));
        }

        public IDataResult<List<SaleDetailDTO>> GetAllSalesDetailsDateRange(DateTime startDay, DateTime endTime)
        {
            return new SuccessDataResult<List<SaleDetailDTO>>(_saleDal.GetAllSalesDetailsDateRange(startDay, endTime));
        }

        public IResult Update(Sale sale)
        {
            _saleDal.Update(sale);
            return new SuccessResult();
        }

       
    }
}
