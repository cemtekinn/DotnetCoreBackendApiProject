using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.Json;
using Core.Utilities;
using DataAccess.DataConverter;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSaleDal:EfEntityRepositoryBase<Sale,WebApiContext>,ISaleDal
    {
        public List<SaleDetailDTO> GetAllSalesDetailsByDate(DateTime date)
        {
            using (WebApiContext context = new WebApiContext())
            {
                var result = from s in context.Sales
                             join c in context.CreditBooks on s.CreditBookId equals c.Id into creditBooks
                             from cb in creditBooks.DefaultIfEmpty()
                             where s.SalesDate.Day == date.Day && s.SalesDate.Month == date.Month && s.SalesDate.Year == date.Year
                             select new SaleDetailDTO
                             {
                                 Id = s.Id,
                                 Products = DtoConverter.GetProductDetailDTO(s.Products),
                                 SalesDate = s.SalesDate,
                                 CreditBookDetails = DtoConverter.GetCreditBookDetailWithId(s.CreditBookId)
                             };
                return result.ToList();
            }
        }

        public List<SaleDetailDTO> GetAllSalesDetailsDateRange(DateTime startDay, DateTime endDay)
        {
            using (WebApiContext context = new WebApiContext())
            {
                var result = from s in context.Sales
                             join c in context.CreditBooks on s.CreditBookId equals c.Id into creditBooks
                             from cb in creditBooks.DefaultIfEmpty()
                             where s.SalesDate.Date >= startDay.Date && s.SalesDate.Date <= endDay.Date
                             select new SaleDetailDTO
                             {
                                 Id = s.Id,
                                 Products = DtoConverter.GetProductDetailDTO(s.Products),
                                 SalesDate = s.SalesDate,
                                 CreditBookDetails = DtoConverter.GetCreditBookDetailWithId(s.CreditBookId)
                             };
                return result.ToList();
            }
        }

        public List<SaleDetailDTO> GetSalesDetails()
        {
            using (WebApiContext context=new WebApiContext())
            {
                var result = from s in context.Sales
                             join c in context.CreditBooks on s.CreditBookId equals c.Id into creditBooks
                             from cb in creditBooks.DefaultIfEmpty()
                             select new SaleDetailDTO
                             {
                                 Id = s.Id,
                                 Products = DtoConverter.GetProductDetailDTO(s.Products),
                                 SalesDate = s.SalesDate,
                                 CreditBookDetails = DtoConverter.GetCreditBookDetailWithId(s.CreditBookId)
                             };
                return result.ToList();
            }
        }
    }
}
