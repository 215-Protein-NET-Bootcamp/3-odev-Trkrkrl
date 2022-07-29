using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class AccountOperationClaim : IEntity
    {
        public int Id { get; set; }
        public int AccountId { get; set; }

        public int OperationClaimId { get; set; }
    }
}
