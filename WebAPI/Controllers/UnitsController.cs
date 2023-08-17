using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : Controller
    {
        IUnitService _unitService;
        public UnitsController(IUnitService unitService)
        {

            _unitService = unitService;

        }
        [HttpGet("getall")]
        public ActionResult GetAll()
        {
            IResult result = _unitService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add(Unit unit)
        {
            var result = _unitService.Add(unit);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }

        [HttpPut("update")]
        public IActionResult Update(Unit unit)
        {
            var result = _unitService.Update(unit);
            if (result.Success)
                return Ok(result);
            return BadRequest(result.Message);
        }
        [HttpGet("delete")]
        public IActionResult Delete(int id)
        {
            var result = _unitService.Delete(id);
            if (result.Success)
                return Ok(result);
            return NotFound(result.Message);
        }
    }
}
