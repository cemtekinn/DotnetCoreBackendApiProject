using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFProductDal : EfEntityRepositoryBase<Product, WebApiContext>, IProductDal
    {
     
        public List<ProductDetailDto> GetProductDetails()
        {
            using (WebApiContext context = new WebApiContext())
            {
                var result = from p in context.Products
                             join c in context.Categories on p.CategoryID equals c.CategoryID
                             join s in context.Suppliers on p.SupplierId equals s.Id into supplierGroup
                             from s in supplierGroup.DefaultIfEmpty()
                             join un in context.Units on p.UnitId equals un.Id
                             select new ProductDetailDto
                             {
                                 ProductName = p.ProductName,
                                 ProductDescription = p.ProductDescription,
                                 ProductID = p.ProductID,
                                 UnitPrice = p.UnitPrice,
                                 BarcodeNumber = p.BarcodeNumber,
                                 Brand = p.Brand,
                                 CategoryName = c.CategoryName,
                                 ExpirationDate = p.ExpirationDate,
                                 KdvRate = p.KdvRate,
                                 SalesAmount = p.SalesAmount,
                                 Status = p.Status,
                                 StockAmount = p.StockAmount,
                                 StokKodu = p.StokKodu,
                                 StokRafı = p.StokRafı,
                                 SupplierAddress = s != null ? s.Address : null,
                                 SupplierName = s != null ? s.Name : null,
                                 SupplierPhoneNumber = s != null ? s.PhoneNumber : null,
                                 SupplierMail = s != null ? s.Email : null,
                                 Unit = un.UnitName
                             };

                return result.ToList();



            }
        }

        public ProductDetailDto GetSingleProductDetail(int productId)
        {
            using (WebApiContext context = new WebApiContext())
            {
                var result = from p in context.Products
                             join c in context.Categories on p.CategoryID equals c.CategoryID
                             join s in context.Suppliers on p.SupplierId equals s.Id into supplierGroup
                             from s in supplierGroup.DefaultIfEmpty()
                             join un in context.Units on p.UnitId equals un.Id
                             where p.ProductID == productId
                             select new ProductDetailDto
                             {
                                 ProductName = p.ProductName,
                                 ProductDescription = p.ProductDescription,
                                 ProductID = p.ProductID,
                                 UnitPrice = p.UnitPrice,
                                 BarcodeNumber = p.BarcodeNumber,
                                 Brand = p.Brand,
                                 CategoryName = c.CategoryName,
                                 ExpirationDate = p.ExpirationDate,
                                 KdvRate = p.KdvRate,
                                 SalesAmount = p.SalesAmount,
                                 Status = p.Status,
                                 StockAmount = p.StockAmount,
                                 StokKodu = p.StokKodu,
                                 StokRafı = p.StokRafı,
                                 SupplierAddress = s != null ? s.Address : null,
                                 SupplierName = s != null ? s.Name : null,
                                 SupplierPhoneNumber = s != null ? s.PhoneNumber : null,
                                 SupplierMail = s != null ? s.Email : null,
                                 Unit = un.UnitName
                             };

                return result.SingleOrDefault();
            }
        }

        public List<OutOfStockProducts> OutOfStockProducts()
        {
            using (WebApiContext context = new WebApiContext())
            {
                var result = from p in context.Products
                             join c in context.Categories on p.CategoryID equals c.CategoryID
                             join s in context.Suppliers on p.SupplierId equals s.Id into supplierGroup
                             from s in supplierGroup.DefaultIfEmpty()
                             join un in context.Units on p.UnitId equals un.Id
                             where p.StockAmount <= 0
                             select new OutOfStockProducts
                             {
                                 ProductName = p.ProductName,
                                 ProductId = p.ProductID,
                                 UnitPrice = p.UnitPrice,
                                 BarcodeNumber = p.BarcodeNumber,
                                 Brand = p.Brand,
                                 CategoryName = c.CategoryName,
                                 SalesAmount = p.SalesAmount,
                                 StokKodu = p.StokKodu,
                                 StokRafı = p.StokRafı,
                                 SupplierAddress = s != null ? s.Address : null,
                                 SupplierName = s != null ? s.Name : null,
                                 SupplierPhoneNumber = s != null ? s.PhoneNumber : null,
                                 SupplierMail = s != null ? s.Email : null,
                                 Unit = un.UnitName
                             };

                return result.ToList();
            }


        }
    }
}
