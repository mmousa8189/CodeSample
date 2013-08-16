using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infrastructure;

namespace Repository
{
    public class ContactRepository : RepositoryBase<Contact, CRMContext>, IContactRepository
    {
        public ContactRepository(IDatabaseFactory<CRMContext> databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
