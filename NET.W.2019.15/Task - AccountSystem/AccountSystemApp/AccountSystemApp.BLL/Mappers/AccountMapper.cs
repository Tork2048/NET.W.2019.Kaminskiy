// <copyright file="AccountMapper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AccountSystemApp.BLL.Mappers
{
    using System;
    using AccountSystemApp.BLL.Interface.Entities;
    using AccountSystemApp.DAL.Interface.DTO;

    /// <summary>
    /// Designed to provide extension methods for account conversion.
    /// Account to AccountDTO and vise versa.
    /// </summary>
    public static class AccountMapper
    {
        /// <summary>
        /// Extension method for AccountDTO instance. Converts object to Account.
        /// </summary>
        /// <param name="accountDTO">
        /// Used as a source object.
        /// </param>
        /// <returns>
        /// Account instance.
        /// </returns>
        public static Account ToAccount(this AccountDTO accountDTO)
        {
            if (accountDTO == null)
            {
                throw new ArgumentNullException(nameof(accountDTO), message: "Impossible to map null to Account");
            }

            AccountType enumType = (AccountType)accountDTO.AccountType;

            return CreateAccount(enumType, accountDTO.AccountNumber, accountDTO.AccountOwner, accountDTO.AccountSum, accountDTO.BonusScore);
        }

        /// <summary>
        /// Extension method for Account instance. Converts object to AccountDTO.
        /// </summary>
        /// <param name="account">
        /// Used as a source object.
        /// </param>
        /// <returns>
        /// AccountDTO instance.
        /// </returns>
        public static AccountDTO ToAccountDTO(this Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account), message: "Impossible to map null to AccountDTO");
            }

            AccountDTO accountDTO = new AccountDTO(GetAccountType(account), account.AccountNumber, account.AccountOwner, account.AccountSum, account.BonusScore);
            return accountDTO;
        }

        /// <summary>
        /// Supplementary method that creates account instance of specific type based on AccountType argument (enum).
        /// Other arguments are used as constructor data.
        /// </summary>
        /// <param name="enumType">
        /// Account type (enum). Type names in enum has to match existing account types precisely.
        /// </param>
        /// <param name="accountNumber">
        /// Account number for Account object constructor.
        /// </param>
        /// <param name="accountOwner">
        /// Account owner for Account object constructor.
        /// </param>
        /// <param name="accountSum">
        /// Account sum for Account object constructor.
        /// </param>
        /// <param name="bonusScore">
        /// Bonus score for Account object constructor.
        /// </param>
        /// <returns>
        /// Created Account instance.
        /// </returns>
        internal static Account CreateAccount(AccountType enumType, int accountNumber, string accountOwner, decimal accountSum, int bonusScore)
        {
            Type accountType = null;
            foreach (Type type in AccountTypes.AccountTypesArray)
            {
                if (enumType.ToString() == type.Name)
                {
                    accountType = type;
                    break;
                }
            }

            if (accountType == null)
            {
                throw new ArgumentException(message: $"Unknown account type ({enumType.ToString()}) - impossible to construct");
            }

            Account newAccount = (Account)Activator.CreateInstance(accountType, accountNumber, accountOwner, accountSum, bonusScore);

            return newAccount;
        }

        /// <summary>
        /// Supplementary method that discoveres Account instance type and converts to int (matches AccountType enum values).
        /// Will be used as AccountType property for AccountDTO object.
        /// </summary>
        /// <param name="account">
        /// Account instance.
        /// </param>
        /// <returns>
        /// Account type (int) for AccountDTO object constructor.
        /// </returns>
        private static int GetAccountType(Account account)
        {
            int accountType = -1;

            foreach (AccountType value in AccountType.GetValues(typeof(AccountType)))
            {
                if (account.GetType().Name == value.ToString())
                {
                    accountType = (int)value;
                    break;
                }
            }

            if (accountType < 0)
            {
                throw new ArgumentException(message: $"Unexpected account type - {account.GetType().ToString()}");
            }

            return accountType;
        }
    }
}
