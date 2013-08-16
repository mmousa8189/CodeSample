using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infrastructure;
using Repository;

namespace Service
{
    public class AccountService : IAccountService
    {
        private IAccountRepository _accountRepository;
        private IUnitOfWork<CRMContext> _unitOfWork;
        public AccountService(IUnitOfWork<CRMContext> unitOfWork, IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
            this._unitOfWork = unitOfWork;
        }

        public List<Account> GetAll()
        {
            return _accountRepository.GetMany(a => a.IsActive).ToList();
        }


        public bool Update(Account account)
        {
            var accountToUpdate = _accountRepository.GetById(account.Id);
            accountToUpdate.Name = account.Name;
            accountToUpdate.Email = account.Email;
            accountToUpdate.Url = account.Url;
            accountToUpdate.Phone = account.Phone;
            accountToUpdate.AccountType = account.AccountType;
            accountToUpdate.AccountStatus = account.AccountStatus;

            _accountRepository.Update(accountToUpdate);
            _unitOfWork.Commit();
            return true;
        }

        public bool Delete(int id)
        {
            //soft delete
            var account = _accountRepository.GetById(id);
            account.IsActive = false;
            _accountRepository.Update(account);
            _unitOfWork.Commit();


            return true;
        }

        public bool Add(Account account)
        {
            _accountRepository.Add(account);
            _unitOfWork.Commit();
            return true;
        }
    }
}
