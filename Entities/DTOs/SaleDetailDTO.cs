using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class SaleDetailDTO:IDto
    {
        public long Id { get; set; }
        public List<ProductDetailDto> Products { get; set; }
        public CreditBookDetailDto CreditBookDetails { get; set; }
        public DateTime SalesDate { get; set; }
        
    }
}
