using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Context
{
    public class EfCoreDbContext:DbContext
    {
        //sağdaki veritabanındaki tablo adı
        
        
        public DbSet<Account> Accounts { get; set; }

    }
}
