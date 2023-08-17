using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CreditBookDetailDto:IDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmail { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string IdentityNumber { get; set; }
        public decimal TotalDebt { get; set; }
        public decimal ReceivedMoney { get; set; }
        public decimal RemainingDebt { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime TransactionDate { get; set; }
        public string RemainingDay { get; set; }
    }
}
