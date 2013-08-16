using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infrastructure;

namespace Repository
{
    public class AccountRepository : RepositoryBase<Account, CRMContext>, IAccountRepository
    {
        public AccountRepository(IDatabaseFactory<CRMContext> databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
