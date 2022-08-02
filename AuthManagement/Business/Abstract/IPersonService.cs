using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPersonService
    {
        DataResult<List<AccountDetailDTO>> GetAllPersonsByAccountId(int accountId);
        DataResult<Person> GetByPersonId(int personId);

        Result Add(Person person);
        Result Update(Person person);
        Result Delete(Person person);
        //-
        
        
    }
}
