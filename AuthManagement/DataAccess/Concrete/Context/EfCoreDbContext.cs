using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Context
{
    public class EfCoreDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {//hocanın kodunda startupcsten alıyordu-  ama benim yapıma uymadı-
            //configuraiton managerle appsettingsten gerekenleri cekip burada if else ile secim sagladım
            ConfigurationManager configurationManager = new();//nuget 6.01 versiyonu geerekli
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WebAPI"));
            configurationManager.AddJsonFile("appsettings.json");


            var dbType = configurationManager.GetConnectionString("DbType");
            if (dbType == "SQL")
            {
                optionsBuilder.UseSqlServer(configurationManager.GetConnectionString("DefaultConnection"));
            }
            else if (dbType == "PostgreSQL")
            {
                optionsBuilder.UseNpgsql(configurationManager.GetConnectionString("PostgreSqlConnection"));
            }


        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        //sağdaki veritabanındaki tablo adı


        public DbSet<Account> Accounts { get; set; }
        public DbSet<Person> Persons { get; set; }



    }
}
