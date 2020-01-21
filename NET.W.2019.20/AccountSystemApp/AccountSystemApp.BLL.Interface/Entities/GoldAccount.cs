// <copyright file="GoldAccount.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AccountSystemApp.BLL.Interface.Entities
{
    using System;
    using AccountSystemApp.BLL.Interface.Interfaces;

    /// <summary>
    /// Gold account class.
    /// </summary>
    public class GoldAccount : Account
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoldAccount"/> class.
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
        public GoldAccount(string accountOwner, decimal accountSum, int bonusScore)
            : base(accountOwner, accountSum, bonusScore)
        {
        }

        /// <summary>
        /// Gets deposit cost value.
        /// </summary>
        protected override int PutCost
        {
            get
            {
                return 5;
            }
        }

        /// <summary>
        /// Gets balance cost value.
        /// </summary>
        protected override int BalanceCost
        {
            get
            {
                return 10;
            }
        }

        /// <summary>
        /// Gets withdraw cost value.
        /// </summary>
        protected override int WithdrawCostSubtraction
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// Increments account sum and calculates bonus with injected strategy.
        /// </summary>
        /// <param name="sum">
        /// Sum to put.
        /// </param>
        /// <param name="bonusLogic">
        /// Bonus calculation strategy.
        /// </param>
        public override void Put(decimal sum, IBonusLogic bonusLogic)
        {
            if (bonusLogic == null)
            {
                throw new ArgumentException(message: "Bonus score logic is null");
            }

            if (sum <= 0)
            {
                throw new ArgumentException(message: "Sum to put cannot be less or equil zero");
            }

            this.AccountSum += sum;
            this.BonusScore += bonusLogic.PutBonus(sum, this.PutCost, this.BalanceCost);
        }

        /// <summary>
        /// Decrements account sum and calculates bonus with injected strategy.
        /// </summary>
        /// <param name="sum">
        /// Sum to withdraw.
        /// </param>
        /// <param name="bonusLogic">
        /// Bonus calculation strategy.
        /// </param>
        public override void WithDraw(decimal sum, IBonusLogic bonusLogic)
        {
            if (bonusLogic == null)
            {
                throw new ArgumentException(message: "Bonus score logic is null");
            }

            if (sum <= 0)
            {
                throw new ArgumentException(message: "Sum to withdraw cannot be less or equil zero");
            }

            if (this.AccountSum - sum < -10000)
            {
                throw new InvalidOperationException(message: $"This type of account does not support such credit {this.AccountSum - sum}$");
            }

            this.AccountSum -= sum;
            int bonusSubtraction = bonusLogic.WithdrawBonusSubtraction(sum, this.WithdrawCostSubtraction, this.BalanceCost);
            if (this.BonusScore > bonusSubtraction)
            {
                this.BonusScore -= bonusSubtraction;
            }
            else
            {
                this.BonusScore = 0;
            }
        }
    }
}
