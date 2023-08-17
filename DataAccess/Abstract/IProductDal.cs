﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails();
        ProductDetailDto GetSingleProductDetail(int productId);
        List<OutOfStockProducts> OutOfStockProducts();
    }
}
