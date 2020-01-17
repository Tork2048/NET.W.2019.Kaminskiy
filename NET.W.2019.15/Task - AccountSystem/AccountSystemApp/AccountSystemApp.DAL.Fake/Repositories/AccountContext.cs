// <copyright file="AccountContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AccountSystemApp.DAL.Fake.Repositories
{
    using System;
    using System.Collections.Generic;
    using AccountSystemApp.DAL.Interface.DTO;
    using AccountSystemApp.DAL.Interface.Interfaces;

    class AccountRepository : IRepository<AccountDTO>
    {
        private readonly List<AccountDTO> accountList;
        public AccountRepository(string path)
        {
            accountList = new List<AccountDTO>();
        }

        public void Create(AccountDTO item)
        {
            if (accountList.Exists(account => account.AccountNumber == item.AccountNumber))
            {
                throw new InvalidOperationException(message: $"Account with such account number ({item.AccountNumber}) already exists");
            }
            else
            {
                accountList.Add(item);
            }

        }

        public void Delete(int id)
        {
            if (accountList.Exists(item => item.AccountNumber == id))
            {
                accountList.Remove(accountList.Find(item => item.AccountNumber == id));
            }
            else
            {
                throw new InvalidOperationException(message: $"Account with account number {id} does not exist");
            }
        }

        public List<AccountDTO> Find(Predicate<AccountDTO> predicate)
        {
            return accountList.FindAll(predicate);
        }

        public List<AccountDTO> GetAll()
        {
            return this.accountList;
        }

        public void Update(AccountDTO item)
        {
        }

        public AccountDTO Get(int id)
        {
            if (accountList.Exists(item => item.AccountNumber == id))
            {
                return accountList.Find(item => item.AccountNumber == id);
            }
            else
            {
                return null;
            }
        }

    }
}