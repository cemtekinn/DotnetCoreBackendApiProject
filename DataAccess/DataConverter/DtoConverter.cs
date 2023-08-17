using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace DataAccess.DataConverter
{
    public static class DtoConverter
    {
        public static List<ProductDetailDto> GetProductDetailDTO(string productsJson)
        {
            List<ProductDetailDto> products = JsonSerializer.Deserialize<List<ProductDetailDto>>(productsJson);
            return products;
        }
        public static CreditBookDetailDto GetCreditBookDetailWithId(int creditBookId)
        {
            CreditBookDetailDto details = new EfCreditBookDal().GetCreditBookDetailById(creditBookId);
            return details;
        }
    }
}
