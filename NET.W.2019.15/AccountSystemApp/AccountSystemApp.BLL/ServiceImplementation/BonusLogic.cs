// <copyright file="BonusLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AccountSystemApp.BLL.ServiceImplementation
{
    using AccountSystemApp.BLL.Interface.Interfaces;

    /// <summary>
    /// Static class that contains logic for bonus score changes.
    /// </summary>
    public class BonusLogic : IBonusLogic
    {
        /// <summary>
        /// Defines bonus score increment on deposit.
        /// </summary>
        /// <param name="sum">
        /// Depends on sum being deposited.
        /// </param>
        /// <param name="balanceCost">
        /// Depends on "balance cost" that will be defined by account type.
        /// </param>
        /// <param name="putCost">
        /// Depends on "deposit cost" that will be defined by account type.
        /// </param>
        /// <returns>
        /// Bonus score increment value.
        /// </returns>
        public int PutBonus(decimal sum, int balanceCost, int putCost)
        {
            return (int)(((sum / 1000) * putCost) + balanceCost);
        }

        /// <summary>
        /// Defines bonus score decrement on withdraw.
        /// </summary>
        /// <param name="sum">
        /// Depends on sum being withdrawn.
        /// </param>
        /// <param name="withdrawCost">
        /// epends on "withdraw cost" that will be defined by account type.
        /// </param>
        /// <param name="balanceCost">
        /// Depends on "balance cost" that will be defined by account type.
        /// </param>
        /// <returns>
        /// Bonus score decrement value.
        /// </returns>
        public int WithdrawBonusSubtraction(decimal sum, int withdrawCost, int balanceCost)
        {
            return (int)((sum / 1000) * withdrawCost);
        }
    }
}
