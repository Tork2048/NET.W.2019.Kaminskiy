// <copyright file="AccountTypes.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AccountSystemApp.BLL.Interface.Entities
{
    using System;

    /// <summary>
    /// Enumeration of possible account type.
    /// BL Logic demands that account type names in enumeration should match existing type names precisely.
    /// </summary>
    public enum AccountType
    {
        /// <summary>
        /// Represents BaseAccount type.
        /// </summary>
        BaseAccount,

        /// <summary>
        /// Represents GoldAccount type.
        /// </summary>
        GoldAccount,

        /// <summary>
        /// Represents PlatinumAccount type.
        /// </summary>
        PlatinumAccount,
    }

    /// <summary>
    /// Supplementary class that provides exact information about existing account types.
    /// </summary>
    public static class AccountTypes
    {
        /// <summary>
        /// Gets array of existing account types.
        /// Required for mapper to convert account type in enumeration to existing account Type in order to construct proper object.
        /// </summary>
        public static Type[] AccountTypesArray
        {
            get
            {
                return new Type[]
                {
                    typeof(BaseAccount),
                    typeof(GoldAccount),
                    typeof(PlatinumAccount),
                };
            }
        }
    }
}
