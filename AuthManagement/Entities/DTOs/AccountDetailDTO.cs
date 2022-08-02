using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class AccountDetailDTO
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }
        public List<Person> PersonList { get; set; }
    }
}
