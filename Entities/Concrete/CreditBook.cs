using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditBook:IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalDebt { get; set; }
        public decimal ReceivedMoney { get; set; }
        public decimal RemainingDebt { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime TransactionDate { get; set; }
        

    }
}
