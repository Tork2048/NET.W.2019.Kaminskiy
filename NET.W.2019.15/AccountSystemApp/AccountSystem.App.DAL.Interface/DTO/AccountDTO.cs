// <copyright file="AccountDTO.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AccountSystemApp.DAL.Interface.DTO
{
    /// <summary>
    /// Adapted Account entity for storage.
    /// Contains only necessary information to restore Account.
    /// </summary>
    public class AccountDTO
    {
        /// <summary>
        /// Static field that keeps account numbers unique.
        /// </summary>
        public static int id = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountDTO"/> class.
        /// </summary>
        /// <param name="accountType">
        /// Account type.
        /// </param>
        /// <param name="accountNumber">
        /// Account number.
        /// </param>
        /// <param name="accountOwner">
        /// Account owner.
        /// </param>
        /// <param name="accountSum">
        /// Account sum.
        /// </param>
        /// <param name="bonusScore">
        /// Bonus score.
        /// </param>
        public AccountDTO(int accountType, int accountNumber, string accountOwner, decimal accountSum, int bonusScore)
        {
            this.AccountType = accountType;
            this.AccountNumber = accountNumber;
            this.AccountOwner = accountOwner;
            this.AccountSum = accountSum;
            this.BonusScore = bonusScore;
        }

        /// <summary>
        /// Gets or sets account type.
        /// </summary>
        public int AccountType { get; set; }

        /// <summary>
        /// Gets or sets account number.
        /// </summary>
        public int AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets account owner.
        /// </summary>
        public string AccountOwner { get; set; }

        /// <summary>
        /// Gets or sets account sum.
        /// </summary>
        public decimal AccountSum { get; set; }

        /// <summary>
        /// Gets or sets account bonus score.
        /// </summary>
        public int BonusScore { get; set; }
    }
}
