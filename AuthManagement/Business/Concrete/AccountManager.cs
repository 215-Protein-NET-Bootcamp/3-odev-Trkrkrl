using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
        IAccountDal _accountDal;

        public AccountManager(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }

        public IResult Add(Account account)
        {
            _accountDal.Add(account);
            return new SuccessResult();
        }

        public IDataResult<Account> GetByMail(string email)
        {
            return new SuccessDataResult<Account>(_accountDal.GetAll(u => u.Email == email).FirstOrDefault());
        }

        public IDataResult<Account> GetByUserName(string userName)
        {
            return new SuccessDataResult<Account>(_accountDal.GetAll(u => u.UserName == userName).FirstOrDefault());
        }

       
    }
}
