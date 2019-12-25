// <copyright file="AccountService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AccountSystemApp.BLL.ServiceImplementation
{
    using System.Collections.Generic;
    using AccountSystemApp.BLL.Interface.Entities;
    using AccountSystemApp.BLL.Interface.Interfaces;
    using AccountSystemApp.BLL.Mappers;
    using AccountSystemApp.DAL.Interface.DTO;
    using AccountSystemApp.DAL.Interface.Interfaces;

    /// <summary>
    /// Class provides means to work with bank accounts.
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly IRepository<AccountDTO> repository;
        private readonly IBonusLogic bonusLogic;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountService"/> class.
        /// </summary>
        /// <param name="repository">
        /// Constructor injected dependancy that defines repository for bank accounts.
        /// </param>
        /// <param name="bonusLogic">
        /// Constructor injected dependancy that defines bonus logic.
        /// </param>
        public AccountService(IRepository<AccountDTO> repository, IBonusLogic bonusLogic)
        {
            this.repository = repository;
            this.bonusLogic = bonusLogic;
        }

        /// <summary>
        /// Method that removes account from storage via given repository instance.
        /// </summary>
        /// <param name="accountNumber">
        /// Used to determine account to delete.
        /// </param>
        public void CloseAccount(int accountNumber)
        {
            this.repository.Delete(accountNumber);
        }

        /// <summary>
        /// Method that contains or may contain account deposit logic.
        /// Calls Put method for given account.
        /// </summary>
        /// <param name="accountNumber">
        /// Determines account to operate.
        /// </param>
        /// <param name="sum">
        /// Sum to deposit.
        /// </param>
        public void DepositAccount(int accountNumber, decimal sum)
        {
            Account account = this.repository.Get(accountNumber).ToAccount();
            account.Put(sum, this.bonusLogic);
            this.repository.Update(account.ToAccountDTO());
        }

        /// <summary>
        /// Creates and return list of all accounts in storage.
        /// </summary>
        /// <returns>
        /// List with account objects.
        /// </returns>
        public List<Account> GetAllAccounts()
        {
            List<Account> accountList = new List<Account>();
            foreach (var accountDTO in this.repository.GetAll())
            {
                accountList.Add(accountDTO.ToAccount());
            }

            return accountList;
        }

        /// <summary>
        /// Method creates new account with given parameters and saves data to storage.
        /// </summary>
        /// <param name="accountOwner">
        /// Account owner - required data to create account.
        /// </param>
        /// <param name="type">
        /// Account type - required data to create account.
        /// </param>
        /// <param name="creator">
        /// Account number generation strategy injected as method argument.
        /// </param>
        public void OpenAccount(string accountOwner, AccountType type, IAccountNumberCreateService creator)
        {
            Account newAccount = AccountMapper.CreateAccount(type, creator.GenerateAccountNumber(AccountDTO.id), accountOwner, 0, 0);
            AccountDTO.id++;
            this.repository.Create(newAccount.ToAccountDTO());
        }

        /// <summary>
        /// Method that contains or may contain account withdraw logic.
        /// Calls Account Withdraw method.
        /// </summary>
        /// <param name="accountNumber">
        /// Determines account to operate.
        /// </param>
        /// <param name="sum">
        /// Sum to withdraw.
        /// </param>
        public void WithdrawAccount(int accountNumber, decimal sum)
        {
            Account account = this.repository.Get(accountNumber).ToAccount();
            sum -= (account.BonusScore * sum) / 1000M;
            account.WithDraw(sum, this.bonusLogic);
            this.repository.Update(account.ToAccountDTO());
        }
    }
}
