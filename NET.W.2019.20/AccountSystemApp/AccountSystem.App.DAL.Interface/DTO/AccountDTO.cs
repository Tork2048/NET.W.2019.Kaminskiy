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
        /// Gets or sets account Id.
        /// </summary>
        public int AccountDTOId { get; set; }

        /// <summary>
        /// Gets or sets account type.
        /// </summary>
        public int AccountType { get; set; }

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

        /// <summary>
        /// Clones current object into new instance.
        /// </summary>
        /// <returns>
        /// new instance of AccountDTO.
        /// </returns>
        public AccountDTO Clone()
        {
            return (AccountDTO)this.MemberwiseClone();
        }
    }
}
