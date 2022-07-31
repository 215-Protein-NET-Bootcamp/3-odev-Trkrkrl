using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

      
        [HttpGet("getbymail")]
        public IActionResult GetByMail(string email)
        {
            var result = _accountService.GetByMail(email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyusername")]
        public IActionResult GetByUserName(string userName)
        {
            var result = _accountService.GetByUserName(userName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
       
        

        //post-add,update ,delete
        [HttpPost("add")]
        public IActionResult Add(Account accountId)
        {
            var result = _accountService.Add(accountId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Account accountId)
        {
            var result = _accountService.Update(accountId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Account accountId)
        {
            var result = _accountService.Delete(accountId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
