// <copyright file="AccountContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AccountSystemApp.DAL.Repositories
{
    using System.Data.Entity;
    using AccountSystemApp.DAL.Interface.DTO;

    /// <summary>
    /// DataBase context for entity framework.
    /// </summary>
    public class AccountContext : DbContext
    {
        /// <summary>
        /// Gets or sets data from/to Accounts table.
        /// </summary>
        public DbSet<AccountDTO> Accounts { get; set; }
    }
}
