using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategory(int categoryId);
        IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<ProductDetailDto> GetSingleProductDetail(int productId);
        IDataResult<Product> GetByBarcodeNumber(string barcodeNumber);
        IDataResult<List<OutOfStockProducts>> OutOfStockProducts();
        IDataResult<Product> GetById(int id);

        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(int productId);
    }
}
