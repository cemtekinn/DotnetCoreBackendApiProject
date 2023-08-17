using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : Controller
    {
        ISupplierService _supplierService;
        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        [HttpGet("getall")]
        public ActionResult GetAll()
        {
            IResult result = _supplierService.GetAll();
            if (result.Success)
                return Ok(result);
            else return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add(Supplier supplier)
        {
            var result = _supplierService.Add(supplier);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result.Message);
        }

        [HttpPut("update")]
        public IActionResult Update(Supplier supplier)
        {
            var result = _supplierService.Update(supplier);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result.Message);
        }
        [HttpGet("delete")]
        public IActionResult Delete(int id)
        {
            var result = _supplierService.Delete(id);
            if (result.Success)
                return Ok(result);
            else return NotFound(result.Message);
        }
    }
}
