using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IAccountService _accountService;
        private ITokenHelper _tokenHelper;


        public AuthManager(IAccountService accountService, ITokenHelper tokenHelper)
        {
            _accountService = accountService;
            _tokenHelper = tokenHelper;
        }




        public IDataResult<Account> Register(AccountForRegisterDto accountForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var account = new Account//bu account core entitiesteki
            {
                Email = accountForRegisterDto.Email,
                Name = accountForRegisterDto.Name,
                UserName = accountForRegisterDto.UserName,
                passwordHash = passwordHash,
                passwordSalt = passwordSalt,
                Status = true
            };
            _accountService.Add(account);
            return new SuccessDataResult<Account>(account, Messages.AccountRegistered);
        }



        public IDataResult<Account> LoginWithEmail(AccountMailLoginDto accountMailLoginDto)
        {
            var userToCheck = _accountService.GetByMail(accountMailLoginDto.Email);
            if (userToCheck.Data == null)
            {
                return new ErrorDataResult<Account>(Messages.AccountNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(accountMailLoginDto.Password, userToCheck.Data.passwordHash, userToCheck.Data.passwordSalt))
            {
                return new ErrorDataResult<Account>(Messages.PasswordError);
            }

            return new SuccessDataResult<Account>(userToCheck.Data, Messages.SuccessfulLogin);
        }

        public IDataResult<Account> LoginWithUserName(AccountNameLoginDto accountNameLoginDto)
        {
            var userToCheck = _accountService.GetByUserName(accountNameLoginDto.UserName);
            if (userToCheck.Data == null)
            {
                return new ErrorDataResult<Account>(Messages.AccountNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(accountNameLoginDto.Password, userToCheck.Data.passwordHash, userToCheck.Data.passwordSalt))
            {
                return new ErrorDataResult<Account>(Messages.PasswordError);
            }

            return new SuccessDataResult<Account>(userToCheck.Data, Messages.SuccessfulLogin);
        }

       

        public IResult UserExists(string email)
        {
            throw new NotImplementedException();//şimdilik boş kalsın-business rules a gidiyor bunun ucu
        }
        public IDataResult<AccessToken> CreateAccessToken(Account account)
        {
            
            var accessToken = _tokenHelper.CreateToken(account);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
    }
}
