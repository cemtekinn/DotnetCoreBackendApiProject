using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public long ProductID { get; set; }
        public int CategoryID { get; set; }
        public int UserID { get; set; }
        public string BarcodeNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string Brand { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int StockAmount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal KdvRate { get; set; }
        public long SalesAmount { get; set; }
        public string StokKodu { get; set; }
        public string StokRafı { get; set; }
        public int Status { get; set; }
        public int SupplierId { get; set; }
        public int UnitId { get; set; }


    }
}
