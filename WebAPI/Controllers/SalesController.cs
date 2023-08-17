using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : Controller
    {
        ISaleService _saleService;
        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet("getallsalesdetails")]
        public ActionResult GetAllSalesDetails()
        {
            IResult result = _saleService.GetAllSalesDetails();
            if (result.Success)
                return Ok(result);
            else return BadRequest(result.Message);
        }

       
        [HttpGet("addsale")]
        public IActionResult AddSale(string jsonProduct,int creditBookId)
        {
            var result = _saleService.AddSale(jsonProduct,creditBookId);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result.Message);

        }

        [HttpPut("update")]
        public IActionResult Update(Sale sale)
        {
            var result = _saleService.Update(sale);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result.Message);
        }
        [HttpGet("delete")]
        public IActionResult Delete(int id)
        {
            var result = _saleService.Delete(id);
            if (result.Success)
                return Ok(result);
            else return NotFound(result.Message);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _saleService.GetAll();
            if (result.Success)
                return Ok(result);
            else return BadRequest(result.Message);

        }
        [HttpGet("getallsalesdetailsbydate")]
        public IActionResult GetAllSalesDetailsByDate(DateTime date)
        {
            var result = _saleService.GetAllSalesDetailsByDate(date);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result.Message);

        }
        [HttpGet("getallsalesdetailsbydaterange")]
        public IActionResult GetAllSalesDetailsByDateRange(DateTime startDay,DateTime endDay)
        {
            var result = _saleService.GetAllSalesDetailsDateRange(startDay,endDay);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result.Message);

        }
    }
}
