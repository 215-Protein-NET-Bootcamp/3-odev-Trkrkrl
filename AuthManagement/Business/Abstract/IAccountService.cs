using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
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
        DataResult<Account> GetByMail(string email);
        DataResult<Account> GetByUserName(string userName);

        
        Result Add(Account account);
        
        //delete olmali mi?
        Result Update(Account account);

        Result Delete(Account account);
        Result UpdatePassword(AccountPasswordUpdateDTO accountPasswordUpdateDTO, int accountId);
       
    }
}
