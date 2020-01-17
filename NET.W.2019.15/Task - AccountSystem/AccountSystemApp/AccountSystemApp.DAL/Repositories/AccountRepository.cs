// <copyright file="AccountRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AccountSystemApp.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using AccountSystemApp.DAL.Interface.DTO;
    using AccountSystemApp.DAL.Interface.Interfaces;

    /// <summary>
    /// Repository class. Provides methods to work with DTO entities and file storage.
    /// </summary>
    public class AccountRepository : IRepository<AccountDTO>
    {
        private readonly List<AccountDTO> accountList;
        private readonly string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRepository"/> class.
        /// </summary>
        /// <param name="path">
        /// Path to file storage to work with.
        /// </param>
        public AccountRepository(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException(message: "Repository path is invalid", nameof(path));
            }

            this.accountList = this.ReadFile(path);
            AccountDTO.id = this.accountList.Count;
            this.path = path;
        }

        /// <summary>
        /// Adds instance of AccountDTO to storage.
        /// </summary>
        /// <param name="item">
        /// AccountDTO instance.
        /// </param>
        public void Create(AccountDTO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), message: "Cannot create account with null");
            }

            if (this.accountList.Exists(account => account.AccountNumber == item.AccountNumber))
            {
                throw new InvalidOperationException(message: $"Account with such account number ({item.AccountNumber}) already exists");
            }
            else
            {
                this.accountList.Add(item);
            }

            this.WriteFile(this.accountList);
        }

        /// <summary>
        /// Removes AccountDTO instance from storage.
        /// </summary>
        /// <param name="id">
        /// Used to determine account to remove.
        /// </param>
        public void Delete(int id)
        {
            if (this.accountList.Exists(item => item.AccountNumber == id))
            {
                this.accountList.Remove(this.accountList.Find(item => item.AccountNumber == id));
            }
            else
            {
                throw new InvalidOperationException(message: $"Account with account number {id} does not exist");
            }

            this.WriteFile(this.accountList);
        }

        /// <summary>
        /// Searches for matches in storage with given predicate.
        /// </summary>
        /// <param name="predicate">
        /// Predicate to search with.
        /// </param>
        /// <returns>
        /// List of matches.
        /// </returns>
        public List<AccountDTO> Find(Predicate<AccountDTO> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate), message: "Cannot search with null predicate");
            }

            return this.accountList.FindAll(predicate);
        }

        /// <summary>
        /// Gets all accounts from storage in a form of list.
        /// </summary>
        /// <returns>
        /// List of AccountDTO accounts.
        /// </returns>
        public List<AccountDTO> GetAll()
        {
            return this.accountList;
        }

        /// <summary>
        /// Replaces AccountDTO instance in storage with given account with the same account number.
        /// </summary>
        /// <param name="item">
        /// Account to replace with.
        /// </param>
        public void Update(AccountDTO item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), message: "Cannot update null");
            }

            if (this.accountList.Exists(account => account.AccountNumber == item.AccountNumber))
            {
                this.accountList.Remove(this.accountList.Find(account => account.AccountNumber == item.AccountNumber));
                this.accountList.Add(item);
                this.WriteFile(this.accountList);
            }
            else
            {
                throw new InvalidOperationException(message: "Account does not exist - nothing to update");
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
            if (this.accountList.Exists(item => item.AccountNumber == id))
            {
                return this.accountList.Find(item => item.AccountNumber == id);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Reads file and forms list of AccountDTO accounts.
        /// </summary>
        /// <param name="path">
        /// Path to file storage.
        /// </param>
        /// <returns>
        /// List of AccountDTO accounts.
        /// </returns>
        private List<AccountDTO> ReadFile(string path)
        {
            List<AccountDTO> list = new List<AccountDTO>();

            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                throw new ArgumentException(message: "Given repository path is invalid", nameof(path));
            }

            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate)))
            {
                if (reader.PeekChar() > -1)
                {
                    AccountDTO.id = reader.ReadInt32();
                }

                while (reader.PeekChar() > -1)
                {
                    int accountType = reader.ReadInt32();
                    int accountNumber = reader.ReadInt32();
                    string accountOwner = reader.ReadString();
                    decimal accountSum = reader.ReadDecimal();
                    int accountBonusScore = reader.ReadInt32();

                    AccountDTO item = new AccountDTO(accountType, accountNumber, accountOwner, accountSum, accountBonusScore);
                    list.Add(item);
                }
            }

            return list;
        }

        /// <summary>
        /// Writes list of AccountDTO accounts to file.
        /// </summary>
        /// <param name="list">
        /// List to write.
        /// </param>
        private void WriteFile(List<AccountDTO> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list), message: "Cannot write null");
            }

            if (!Directory.Exists(Path.GetDirectoryName(this.path)))
            {
                throw new ArgumentException(message: "Given repository path is invalid", nameof(this.path));
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(this.path, FileMode.Create)))
            {
                writer.Write(AccountDTO.id);

                foreach (var item in list)
                {
                    writer.Write(item.AccountType);
                    writer.Write(item.AccountNumber);
                    writer.Write(item.AccountOwner);
                    writer.Write(item.AccountSum);
                    writer.Write(item.BonusScore);
                }
            }
        }
    }
}
