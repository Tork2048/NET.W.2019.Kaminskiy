// <copyright file="IAccountNumberCreateService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AccountSystemApp.BLL.Interface.Interfaces
{
    /// <summary>
    /// Interface that provides access to Account number generator method.
    /// Part of stairway pattern implementation.
    /// </summary>
    public interface IAccountNumberCreateService
    {
        /// <summary>
        /// Description of Account number generator method.
        /// </summary>
        /// <param name="id">
        /// Unique account id.
        /// </param>
        /// <returns>
        /// Account number.
        /// </returns>
        public int GenerateAccountNumber(int id);
    }
}
