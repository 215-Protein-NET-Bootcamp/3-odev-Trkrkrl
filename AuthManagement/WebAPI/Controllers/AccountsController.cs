using Business.Abstract;
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

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _accountService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int accountId)
        {
            var result = _accountService.GetById(accountId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getdetailsbyid")]
        public IActionResult GetDetailsById(int accountId)
        {
            var result = _accountService.GetDetailsById(accountId);
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
