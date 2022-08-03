using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AccountManager : IAccountService
    {
        private readonly IAccountDal _accountDal;
        

        public AccountManager(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }

        public Result Add(Account account)
        {
            _accountDal.Add(account);
            return new SuccessResult();
        }

        public Result Delete(Account account)
        {
            return new Result(true, Messages.AccountDeleted);
        }
        public Result Update(Account account)
        {
            _accountDal.Update(account);
            return new Result(true);
        }

        public DataResult<Account> GetByMail(string email)
        {
            return new SuccessDataResult<Account>(_accountDal.GetAll(u => u.Email == email).FirstOrDefault());
        }

        public DataResult<Account> GetByUserName(string userName)
        {
            return new SuccessDataResult<Account>(_accountDal.GetAll(u => u.UserName == userName).FirstOrDefault());
        }
        public DataResult<Account> GetById(int accountId)
        {
            return new SuccessDataResult<Account>(_accountDal.GetAll(u => u.AccountId == accountId).FirstOrDefault());
        }

        public Result UpdatePassword(AccountPasswordUpdateDTO accountPasswordUpdateDTO, int accountId)
        {
            var account = (GetById(accountId)).Data;
            if (!HashingHelper.VerifyPasswordHash(accountPasswordUpdateDTO.OldPassword, account.passwordHash, account.passwordSalt))
            {
                return new ErrorResult(Messages.OldPasswordIsWrong);

            }
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(accountPasswordUpdateDTO.NewPassword, out passwordHash, out passwordSalt);

            
            account.passwordHash = passwordHash;
            account.passwordSalt = passwordSalt;
            account.Status = true;
            _accountDal.Update(account);


            return new SuccessDataResult<Account>(account, Messages.PasswordUpdated);
        }
    }
}
