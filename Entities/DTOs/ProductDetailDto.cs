﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Entities.DTOs
{
    public class ProductDetailDto:IDto
    {
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryName { get; set; }
        public string BarcodeNumber { get; set; }
        public string Brand { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int StockAmount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal KdvRate { get; set; }
        public long SalesAmount { get; set; }
        public string StokKodu { get; set; }
        public string StokRafı { get; set; }
        public int Status { get; set; }
        public string Unit { get; set; }
        public string SupplierName { get; set; }
        public string SupplierPhoneNumber { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierMail { get;set; }
    }
}
