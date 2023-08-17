using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal productDal;
        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }

        [SecuredOperation("admin,moderator,authorized")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            IResult result=BusinessRules.Run(CheckIfProductOfCategoryCorrect(product.CategoryID), CheckIfProductOfProductNameExists(product.ProductName));
            
            if(result!=null) return result;
            
            this.productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }
        [CacheRemoveAspect("IProductService.Get")]
        [LogAspect(typeof(DatabaseLogger))]
        [SecuredOperation("admin")]
        public IResult Delete(int productId)
        {
            Product getProduct = productDal.Get(p=>p.ProductID==productId);
            this.productDal.Delete(getProduct);
            return new SuccessResult(Messages.ProductDeleteSuccessfully);
        }

        [CacheAspect]
        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(productDal.GetAll(),Messages.ProductListed);
        }
        public IDataResult<List<Product>> GetAllByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(productDal.GetAll(p=>p.CategoryID==categoryId),Messages.ProductBroughtByCategory);
        }
       
        public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(productDal.GetAll(p=>p.UnitPrice>min && p.UnitPrice <=max));
        }

        [CacheAspect]
        public IDataResult<Product> GetByBarcodeNumber(string barcodeNumber)
        {
            return new SuccessDataResult<Product>(productDal.Get(p=>p.BarcodeNumber==barcodeNumber));
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(productDal.Get(p=>p.ProductID==id));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
           return new SuccessDataResult<List<ProductDetailDto>>(productDal.GetProductDetails());
        }

        public IDataResult<ProductDetailDto> GetSingleProductDetail(int productId)
        {
            return new SuccessDataResult<ProductDetailDto>(productDal.GetSingleProductDetail(productId));
        }

        public IDataResult<List<OutOfStockProducts>> OutOfStockProducts()
        {
            return new SuccessDataResult<List<OutOfStockProducts>>(productDal.OutOfStockProducts(),Messages.ProductListed);
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            //Product getProduct = productDal.Get(p => p.ProductID == ProductID);
            productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdateSuccessfully);

        }



        //Kısıtlamalar
        private IResult CheckIfProductOfCategoryCorrect(int categoryId)
        {
            // Eklenecek ürün kategorisinde eğer 15 den az ürün varsa ekle # Örnektir #
            var result=productDal.GetAll(p=>p.CategoryID==categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult("Aynı kategoriye en fazla 15 ürün eklenebilir");
            }
            else
            {
                return new SuccessResult();
            }
        }
        private IResult CheckIfProductOfProductNameExists(string productName)
        {
            // Daha önce aynı isimde ürün varsa yeni ürün eklenemez
            var result=productDal.GetAll(p=>p.ProductName==productName).Count;
            if (result !=0) 
            {
                return new ErrorResult(Messages.ProductNameExists);
            }
            else
            {
                return new SuccessResult(Messages.ProductAdded);
            }
        }
        /*   Kategoriye özel kısıtlamalar getirilecekse
         *   
            private IResult CheckIfCategoryLimitExceed()
            {
                var result = categoryService.GetAll();
                if (result.Count > 15)
                {
                    return new ErrorResult();
                }
                return SuccessResult();
            }
        */
    }
}
