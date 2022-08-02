using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonManager : IPersonService
    {
        private readonly IPersonDal _personDal;

        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
        }

      

        public  DataResult<List<AccountDetailDTO>> GetAllPersonsByAccountId(int accountId)
        {
            return new SuccessDataResult<List<AccountDetailDTO>>(_personDal.GetDetailsById(c => c.AccountId == accountId));
        }

        public DataResult<Person> GetByPersonId(int personId)
        {
            return new SuccessDataResult<Person>(_personDal.Get(C => C.PersonId== personId));
        }
        public Result Add(Person person)//bunlar account id yi nasıl otomatik çekecek
        {
            _personDal.Add(person);
            return new SuccessDataResult<Person>(Messages.PersonAdded);
        }

        public Result Delete(Person person)
        {
            _personDal.Delete(person);
            return new Result(true, Messages.PersonDeleted);
        }
        public Result Update(Person person)
        {
            _personDal.Update(person);//I resultta result oluyor-update de mesaj veya eri gelimyo sadece bool
            return new Result(true);
        }
    }
}
