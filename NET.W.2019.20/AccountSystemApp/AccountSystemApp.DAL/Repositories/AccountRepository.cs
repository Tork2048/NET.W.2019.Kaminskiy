// <copyright file="AccountRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AccountSystemApp.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AccountSystemApp.DAL.Interface.DTO;
    using AccountSystemApp.DAL.Interface.Interfaces;

    /// <summary>
    /// Repository class. Provides methods to work with DTO entities and file storage.
    /// </summary>
    public class AccountRepository : IRepository<AccountDTO>
    {
        /// <summary>
        /// Adds instance of AccountDTO to storage.
        /// </summary>
        /// <param name="account">
        /// AccountDTO instance.
        /// </param>
        public void Create(AccountDTO account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account), message: "Cannot create account with null");
            }

            using (var db = new AccountContext())
            {
                db.Accounts.Add(account);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Removes AccountDTO instance from storage.
        /// </summary>
        /// <param name="id">
        /// Used to determine account to remove.
        /// </param>
        public void Delete(int id)
        {
            using (var db = new AccountContext())
            {
                var account = new AccountDTO() { AccountDTOId = id };
                db.Accounts.Attach(account);
                db.Accounts.Remove(account);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Searches for matches in storage with given predicate.
        /// </summary>
        /// <param name="accountOwner">
        /// AccountOwner to search for.
        /// </param>
        /// <returns>
        /// List of matches.
        /// </returns>
        public List<AccountDTO> FindByAccountOwner(string accountOwner)
        {
            List<AccountDTO> result = new List<AccountDTO>();
            using (var db = new AccountContext())
            {
                result = db.Accounts.Where(account => string.Compare(account.AccountOwner, accountOwner, StringComparison.InvariantCultureIgnoreCase) == 0).ToList();
            }

            return result;
        }

        /// <summary>
        /// Gets all accounts from storage in a form of list.
        /// </summary>
        /// <returns>
        /// List of AccountDTO accounts.
        /// </returns>
        public List<AccountDTO> GetAll()
        {
            List<AccountDTO> result = new List<AccountDTO>();
            using (var db = new AccountContext())
            {
                result = db.Accounts.ToList();
            }

            return result;
        }

        /// <summary>
        /// Replaces AccountDTO instance in storage with given account with the same account number.
        /// </summary>
        /// <param name="account">
        /// Account to replace with.
        /// </param>
        public void Update(AccountDTO account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account), message: "Cannot update null");
            }

            using (var db = new AccountContext())
            {
                var accountToUpdate = db.Accounts.Where(acc => acc.AccountDTOId == account.AccountDTOId).FirstOrDefault();
                if (accountToUpdate != null)
                {
                    accountToUpdate.AccountOwner = account.AccountOwner;
                    accountToUpdate.AccountType = account.AccountType;
                    accountToUpdate.AccountSum = account.AccountSum;
                    accountToUpdate.BonusScore = account.BonusScore;
                }

                db.SaveChanges();
            }
        }

        /// <summary>
        /// Gets account from storage by account number.
        /// </summary>
        /// <param name="id">
        /// Account number.
        /// </param>
        /// <returns>
        /// Found AccountDTO instance.
        /// </returns>
        public AccountDTO Get(int id)
        {
            AccountDTO accountResult = null;
            using (var db = new AccountContext())
            {
                var account = db.Accounts.Where(acc => acc.AccountDTOId == id).FirstOrDefault();
                if (account != null)
                {
                    accountResult = account.Clone();
                }
            }

            return accountResult;
        }
    }
}
