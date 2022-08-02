﻿using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IPersonDal: IBaseRepository<Person>
    {
        public List<AccountDetailDTO> GetDetailsById(Expression<Func<AccountDetailDTO, bool>> filter = null);
    }
}
