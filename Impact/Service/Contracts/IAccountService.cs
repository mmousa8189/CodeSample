using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Service
{
    public interface IAccountService
    {
        List<Account> GetAll();
        bool Update(Account account);
        bool Delete(int id);
        bool Add(Account account);

    }
}
