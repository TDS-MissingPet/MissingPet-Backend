﻿using System;
using System.Collections.Generic;
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

        public int Add(Account account)
        {
            if(account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            var accountId = _accountRepository.Add(new AccountEntity()
            {
                IdentityId = account.IdentityId,
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

            return accountId;
        }
    }
}
