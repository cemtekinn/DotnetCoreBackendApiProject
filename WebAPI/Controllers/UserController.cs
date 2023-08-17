using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService= userService;
        }
        [HttpGet("getclaims")]
        public List<OperationClaim> GetClaims(string email)
        {
            var user =userService.GetByEmail(email);
            var result = userService.GetClaims(user.Data);
            return result;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()        
        {
            var result = userService.GetAll();
            if (result.Success)
            {
               return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpGet("getbyemail")]
        public IActionResult Get(string email)
        {
            var result=userService.GetByMail(email);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }


    }
}
