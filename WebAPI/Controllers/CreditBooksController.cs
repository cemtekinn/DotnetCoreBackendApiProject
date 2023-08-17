using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CreditBooksController : Controller
    {
        ICreditBookService _creditBookService;
        public CreditBooksController(ICreditBookService creditBookService)
        {
            _creditBookService = creditBookService;
        }
        [HttpGet("getdetails")]
        public ActionResult GetDetails()
        {
            IResult result= _creditBookService.GetCreditBookDetails();
            if(result.Success)
                return Ok(result);
            else return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public ActionResult Add(CreditBook creditBook)
        {
            IResult result = _creditBookService.Add(creditBook);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result.Message);
        }
        [HttpPut("update")]
        public ActionResult Update(CreditBook creditBook)
        {
            IResult result = _creditBookService.Update(creditBook);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result.Message);
        }
        [HttpGet("delete")]
        public ActionResult Delete(int id)
        {
            IResult result = _creditBookService.Delete(id);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result.Message);
        }
    }
}
