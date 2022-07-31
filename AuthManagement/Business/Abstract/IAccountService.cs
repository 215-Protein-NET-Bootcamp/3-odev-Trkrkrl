using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAccountService
    {
        IDataResult<Account> GetByMail(string email);
        IDataResult<Account> GetByUserName(string userName);

        
        IResult Add(Account account);
        //delete olmali mi?

    }
}
