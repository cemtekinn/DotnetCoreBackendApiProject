using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfCreditBookDal : EfEntityRepositoryBase<CreditBook, WebApiContext>, ICreditBookDal
    {
        public List<CreditBookDetailDto> GetCreditBookDetails()
        {
            using (WebApiContext context = new WebApiContext())
            {
                var result = from credit in context.CreditBooks
                             join customer in context.Customers on credit.CustomerId equals customer.CustomerId
                             select new CreditBookDetailDto
                             {
                                 Id= credit.Id,
                                 CustomerId= credit.CustomerId,
                                 CustomerName = customer.Name + " " + customer.Lastname,
                                 TotalDebt = credit.TotalDebt,
                                 ReceivedMoney = credit.ReceivedMoney,
                                 RemainingDebt = credit.RemainingDebt,
                                 DueDate = credit.DueDate,
                                 CustomerPhoneNumber = customer.PhoneNumber,
                                 CustomerEmail = customer.Mail,
                                 Address = customer.Address,
                                 RemainingDay =(credit.DueDate-DateTime.Now).Days>=0 
                                            ? "Kalan Gün: "+ (credit.DueDate - DateTime.Now).Days
                                            : "Süre doldu: "+ -1*(credit.DueDate - DateTime.Now).Days+" gün geçti",
                                 City =customer.City,
                                 District=customer.District,
                                 IdentityNumber=customer.IdentityNumber,
                                 TransactionDate=credit.TransactionDate
                             };
                return result.ToList();
            }
        }
        public CreditBookDetailDto GetCreditBookDetailById(int creditBookId)
        {
            using (WebApiContext context = new WebApiContext())
            {
                var result = from credit in context.CreditBooks
                             join customer in context.Customers on credit.CustomerId equals customer.CustomerId
                             where credit.Id == creditBookId
                             select new CreditBookDetailDto
                             {
                                 Id = credit.Id,
                                 CustomerId = credit.CustomerId,
                                 CustomerName = customer.Name + " " + customer.Lastname,
                                 TotalDebt = credit.TotalDebt,
                                 ReceivedMoney = credit.ReceivedMoney,
                                 RemainingDebt = credit.RemainingDebt,
                                 DueDate = credit.DueDate,
                                 CustomerPhoneNumber = customer.PhoneNumber,
                                 CustomerEmail = customer.Mail,
                                 Address = customer.Address,
                                 RemainingDay = (credit.DueDate - DateTime.Now).Days >= 0
                                            ? "Kalan Gün: " + (credit.DueDate - DateTime.Now).Days
                                            : "Süre doldu: " + -1 * (credit.DueDate - DateTime.Now).Days + " gün geçti",
                                 City = customer.City,
                                 District = customer.District,
                                 IdentityNumber = customer.IdentityNumber,
                                 TransactionDate = credit.TransactionDate
                             };
                return result.SingleOrDefault();
            }
        }

     
    }
}
