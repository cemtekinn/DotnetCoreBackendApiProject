using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISaleService
    {
        IDataResult<List<SaleDetailDTO>> GetAllSalesDetails();
        IDataResult<List<SaleDetailDTO>> GetAllSalesDetailsByDate(DateTime date);

        IDataResult<List<SaleDetailDTO>> GetAllSalesDetailsDateRange(DateTime startDay,DateTime endTime);

        IResult AddSale(string jsonProduct,int creditBookId);
        IResult Delete(int id);
        IResult Update(Sale sale);

        IDataResult<List<Sale>> GetAll();

    }
}
