using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : Controller
    {
        ISettingService _settingService;
        public SettingsController(ISettingService settingService)
        {
            _settingService = settingService;
        }
        [HttpGet("getall")]
        public ActionResult GetAll()
        {
            IResult result = _settingService.GetAll();
            if (result.Success)
                return Ok(result);
            else return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add(Setting setting)
        {
            var result = _settingService.Add(setting);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result.Message);
        }

        [HttpPut("update")]
        public IActionResult Update(string key,string value)
        {
            var result = _settingService.Update(key,value);
            if (result.Success)
                return Ok(result);
            else return BadRequest(result.Message);
        }
        [HttpGet("delete")]
        public IActionResult Delete(int id)
        {
            var result = _settingService.Delete(id);
            if (result.Success)
                return Ok(result);
            else return NotFound(result.Message);
        }
        [HttpGet("getbykey")]
        public IActionResult GetByKey(string key)
        {
            var result = _settingService.GetByKey(key);
            if (result.Success)
                return Ok(result);
            else return NotFound(result.Message);
        }
    }
}
