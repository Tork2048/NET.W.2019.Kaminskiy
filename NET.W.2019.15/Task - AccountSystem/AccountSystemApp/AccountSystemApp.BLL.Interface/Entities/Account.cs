// <copyright file="Account.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AccountSystemApp.BLL.Interface.Entities
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using AccountSystemApp.BLL.Interface.Interfaces;

    /// <summary>
    /// Abstract class that defines basic Account behaviour.
    /// All account types will derive from it.
    /// </summary>
    public abstract class Account : IEquatable<Account>
    {
        private int accountNumber;
        private string accountOwner;
        private decimal accountSum;
        private int bonusScore;

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// It is crucial that constructor remains the same for all Account predecessors.
        /// </summary>
        /// <param name="accountNumber">
        /// Account number for account.
        /// </param>
        /// <param name="accountOwner">
        /// Account owner for account.
        /// </param>
        /// <param name="accountSum">
        /// Account sum for account.
        /// </param>
        /// <param name="bonusScore">
        /// Bonus score for account.
        /// </param>
        public Account(int accountNumber, string accountOwner, decimal accountSum, int bonusScore)
        {
            this.AccountNumber = accountNumber;
            this.AccountOwner = accountOwner;
            this.AccountSum = accountSum;
            this.BonusScore = bonusScore;
        }

        /// <summary>
        /// Gets or sets accountNumber field.
        /// Implements value validation.
        /// </summary>
        public int AccountNumber
        {
            get
            {
                return this.accountNumber;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(message: "Invalid account number");
                }

                this.accountNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets accountOwner.
        /// Implements value validation.
        /// </summary>
        public string AccountOwner
        {
            get
            {
                return this.accountOwner;
            }

            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(message: "Invalid account owner");
                }

                this.accountOwner = value;
            }
        }

        /// <summary>
        /// Gets or sets accountSum field.
        /// Implements value validation.
        /// </summary>
        public decimal AccountSum
        {
            get
            {
                return this.accountSum;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(message: "Invalid account sum");
                }

                this.accountSum = value;
            }
        }

        /// <summary>
        /// Gets or sets bonusScore field.
        /// Implements value validation.
        /// </summary>
        public int BonusScore
        {
            get
            {
                return this.bonusScore;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(message: "Invalid bonus score");
                }

                this.bonusScore = value;
            }
        }

        /// <summary>
        /// Gets put cost for account.
        /// Used as inheritable constant (readonly) that can be overriden by predecessors.
        /// Participates in bonus score calculation strategy.
        /// </summary>
        protected abstract int PutCost { get; }

        /// <summary>
        /// Gets balance cost for account.
        /// Used as inheritable constant (readonly) that can be overriden by predecessors.
        /// Participates in bonus score calculation strategy.
        /// </summary>
        protected abstract int BalanceCost { get; }

        /// <summary>
        /// Gets withdraw cost for account.
        /// Used as inheritable constant (readonly) that can be overriden by predecessors.
        /// Participates in bonus score calculation strategy.
        /// </summary>
        protected abstract int WithdrawCostSubtraction { get; }

        /// <summary>
        /// Object.ToString() method override.
        /// </summary>
        /// <returns>
        /// String representation of an account.
        /// </returns>
        public override string ToString()
        {
            return $"{this.AccountNumber}: {this.AccountOwner} - {this.AccountSum}$";
        }

        /// <summary>
        /// Method increments accountSum for account.
        /// </summary>
        /// <param name="sum">
        /// Some to put.
        /// </param>
        /// <param name="bonusLogic">
        /// Bonus calculation strategy.
        /// </param>
        public abstract void Put(decimal sum, IBonusLogic bonusLogic);

        /// <summary>
        /// Method decrements accountSum for account.
        /// </summary>
        /// <param name="sum">
        /// Sum to withdraw.
        /// </param>
        /// <param name="bonusLogic">
        /// Bonus calculation strategy.
        /// </param>
        public abstract void WithDraw(decimal sum, IBonusLogic bonusLogic);

        public bool Equals(Account other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other), message: "Cannot equate to null");
            }

            return this.accountNumber == other.accountNumber && this.accountOwner == other.accountOwner && this.accountSum == other.accountSum && this.bonusScore == other.bonusScore;
        }
    }
}
