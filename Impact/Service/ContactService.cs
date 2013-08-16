using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Repository;

namespace Service
{
    public class ContactService : IContactService
    {
        private IContactRepository _contactRepository;
        private IUnitOfWork<CRMContext> _unitOfWork;
        public ContactService(IUnitOfWork<CRMContext> unitOfWork, IContactRepository contactRepository)
        {
            this._contactRepository = contactRepository;
            this._unitOfWork = unitOfWork;
        }
    }
}
