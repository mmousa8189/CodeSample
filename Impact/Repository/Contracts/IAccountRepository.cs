using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infrastructure;

namespace Repository
{
    public interface IAccountRepository : IRepository<Account>
    {
    }
}
