using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class Account : IEntity
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public byte[] passwordSalt { get; set; }
        public byte[] passwordHash { get; set; }
        public bool Status { get; set; }



    }
}
