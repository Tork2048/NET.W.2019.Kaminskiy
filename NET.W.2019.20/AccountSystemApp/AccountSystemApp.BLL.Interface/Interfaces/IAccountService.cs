// <copyright file="IAccountService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AccountSystemApp.BLL.Interface.Interfaces
{
    using System.Collections.Generic;
    using AccountSystemApp.BLL.Interface.Entities;

    /// <summary>
    /// Interface that provides access to Account service methods.
    /// Part of stairway pattern implementation.
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Method retrieves accounts from repository and forms a List.
        /// </summary>
        /// <returns>
        /// List of accounts.
        /// </returns>
        List<Account> GetAllAccounts();

        /// <summary>
        /// Creates account with required information.
        /// </summary>
        /// <param name="accountOwner">
        /// Account owner - required information to create account.
        /// </param>
        /// <param name="type">
        /// Account type - required.
        /// </param>
        /// <param name="creator">
        /// Account number generation strategy.
        /// </param>
        void OpenAccount(string accountOwner, AccountType type);

        /// <summary>
        /// Removes account from storage.
        /// </summary>
        /// <param name="accountNumber">
        /// Used to determine account to be deleted.
        /// </param>
        void CloseAccount(int accountNumber);

        /// <summary>
        /// Deposit sum to account.
        /// </summary>
        /// <param name="accountNumber">
        /// Used to determines account.
        /// </param>
        /// <param name="sum">
        /// Sum to deposit.
        /// </param>
        void DepositAccount(int accountNumber, decimal sum);

        /// <summary>
        /// Withdraw sum from account.
        /// </summary>
        /// <param name="accountNumber">
        /// Used to determine account.
        /// </param>
        /// <param name="sum">
        /// Sum to withdraw.
        /// </param>
        void WithdrawAccount(int accountNumber, decimal sum);
    }
}