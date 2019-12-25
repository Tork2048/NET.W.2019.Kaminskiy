// <copyright file="AccountNumberCreator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AccountSystemApp.BLL.ServiceImplementation
{
    using AccountSystemApp.BLL.Interface.Interfaces;

    /// <summary>
    /// Class that contains account number generator.
    /// Will be used as a strategy for account number generation.
    /// </summary>
    public class AccountNumberCreator : IAccountNumberCreateService
    {
        /// <summary>
        /// Simple Account number generator.
        /// Based on unique id value of AccountDTO.
        /// </summary>
        /// <param name="id">
        /// Meant to be unique AccountDTO id.
        /// </param>
        /// <returns>
        /// Account number.
        /// </returns>
        public int GenerateAccountNumber(int id)
        {
            return ++id;
        }
    }
}
