using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet("getall")]
        public ActionResult GetAll()
        {
            IResult result=_customerService.GetAll();
            if (result.Success)
                return Ok(result);
            else return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            var result = _customerService.Add(customer);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result.Message);
        }

        [HttpPut("update")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerService.Update(customer);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result.Message);
        }
        [HttpGet("delete")]
        public IActionResult Delete(int customerId)
        {
            var result = _customerService.Delete(customerId);
            if (result.Success)
                return Ok(result);
            else return NotFound(result.Message);
        }
    }
}
