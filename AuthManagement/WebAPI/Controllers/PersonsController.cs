using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly  IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        //-getall-get by id -add,delete,update

        [HttpGet("GetAll")]// bu methodda- otomatik olarak auth dan aldığı biligiye göre kayıtlı bütün accountlara ait personlar
        [Authorize]
        public IActionResult GetAll(int accountId)
        {
            var clm = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
            accountId = Int32.Parse(clm);

            var result = _personService.GetAllPersonsByAccountId(accountId);// bu account id yi jsondan otomatik almalı- yani giriş yapılı kullanıcıdan
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }
        [HttpGet("getbypersonid")]//burdada tokenden aldığı bilgiye göre-girilen personid o accountda ise o personu getir
        [Authorize]
        public IActionResult GetByUserId(int personId)
        {
            var result = _personService.GetByPersonId(personId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        [Authorize]
        public IActionResult Add(Person  person)
        {
            var clm = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
            person.AccountId = Int32.Parse(clm);
            var result = _personService.Add(person);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }
        [HttpPost("Update")]
        [Authorize]
        public IActionResult Update(Person person)
        {
            var clm = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
            person.AccountId = Int32.Parse(clm);
            var result = _personService.Update(person);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }
        [HttpPost("Delete")]
        [Authorize]
        public IActionResult Delete(Person person)
        {
            var clm = (User.Identity as ClaimsIdentity).FindFirst("AccountId").Value;
            person.AccountId = Int32.Parse(clm);
            var result = _personService.Delete(person);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }
    }
}
