﻿using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

      
        [HttpGet("getbymail")]
        [Authorize]
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
        [Authorize]
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
        [Authorize]
        public IActionResult Add(Account account)
        {
            var result = _accountService.Add(account);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        [Authorize]
        public IActionResult Update(Account account)
        {
            var result = _accountService.Update(account);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        [Authorize]
        public IActionResult Delete(Account account)
        {
            var result = _accountService.Delete(account);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
