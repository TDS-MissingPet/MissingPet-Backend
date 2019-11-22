using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MissingPet.DataAccess.Entities;
using MissingPet.DataAccess.Repositories;
using MissingPet.Domain.Models;

namespace MissingPet.BLL.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<AccountEntity> _accountRepository;
        private readonly IRepository<AccountPhoneNumberEntity> _accountPhoneNumberRepository;

        public AccountService(
            IRepository<AccountEntity> accountRepository,
            IRepository<AccountPhoneNumberEntity> accountPhoneNumberRepository)
        {
            _accountRepository = accountRepository;
            _accountPhoneNumberRepository = accountPhoneNumberRepository;
        }

        public void Add(Account account)
        {
            if(account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            _accountRepository.Add(new AccountEntity()
            {
                FirstName = account.FirstName,
                LastName = account.LastName,
                AccountPhoneNumbers = new List<AccountPhoneNumberEntity>()
                {
                    new AccountPhoneNumberEntity()
                    {
                        PhoneNumber = account.PhoneNumber,
                        IsPrimary = true
                    }
                }
            });
        }
    }
}
