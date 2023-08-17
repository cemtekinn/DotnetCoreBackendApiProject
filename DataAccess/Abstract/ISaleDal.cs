using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ISaleDal:IEntityRepository<Sale>
    {
        List<SaleDetailDTO> GetSalesDetails();
        List<SaleDetailDTO> GetAllSalesDetailsByDate(DateTime date);
        List<SaleDetailDTO> GetAllSalesDetailsDateRange(DateTime startDay, DateTime endDay);
    }
}
