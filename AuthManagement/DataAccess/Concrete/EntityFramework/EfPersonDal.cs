using Core.DataAccess.Concrete.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPersonDal: EfEntityBaseRepository<Person, EfCoreDbContext>, IPersonDal
    {
        public List<AccountDetailDTO> GetDetailsById(Expression<Func<AccountDetailDTO, bool>> filter = null)//bunun Iemployeedal da daolması lazım yoksa hata verir
        {
            using (EfCoreDbContext context = new EfCoreDbContext())
            {
                var result = from a in context.Accounts
                             join b in context.Persons on a.AccountId equals b.PersonId
                             

                             select new AccountDetailDTO
                             {
                                 // Cuntryname, Departmentname,Employeename
                                 AccountId = a.AccountId,
                                 Email = a.Email,
                                 Name = a.Name,
                                 UserName = a.UserName,
                                


                                 //personList
                                 PersonList = (from p in context.Persons where p.AccountId == a.AccountId select p).ToList()

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();


            }
        }

    }
}
