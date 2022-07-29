using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("loginwithmail")]
        public ActionResult Login(AccountMailLoginDto accountMailLoginDto)
        {
            var userToLogin = _authService.Login(accountMailLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result);//aciklamasi en alttaki gibi donus olarak mesaji gosterttimiyor
            }

            return BadRequest(result);
        }
        [HttpPost("loginwithusername")]
        public ActionResult Login(AccountNameLoginDto accountNameLoginDto)
        {
            var userToLogin = _authService.Login(accountNameLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result);//aciklamasi en alttaki gibi donus olarak mesaji gosterttimiyor
            }

            return BadRequest(result);
        }

        [HttpPost("register")]
        public ActionResult Register(AccountForRegisterDto accountForRegisterDto)
        {
            var userExists = _authService.UserExists(accountForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(accountForRegisterDto, accountForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result);//buradaki datayı sildik ve
            }

            return BadRequest(result);//buradaki messaage yi sildik yoksa çalıştırınca sadece token olusturuyo mesaj vermiyo
        }
    }
}
