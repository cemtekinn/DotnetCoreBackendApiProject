using Core.Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Sale:IEntity
    {
        public long Id { get; set; }
        public string Products { get; set; }
        public DateTime SalesDate { get; set; }
        public int CreditBookId { get; set; }
    }
}
