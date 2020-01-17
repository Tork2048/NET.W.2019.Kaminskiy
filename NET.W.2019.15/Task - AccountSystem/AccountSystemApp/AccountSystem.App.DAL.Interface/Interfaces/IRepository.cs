// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AccountSystemApp.DAL.Interface.Interfaces
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface that provide access to methods to work with repository.
    /// </summary>
    /// <typeparam name="T">
    /// Data type in storage.
    /// </typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Gets all accounts from storage in a form of list.
        /// </summary>
        /// <returns>
        /// List of T accounts.
        /// </returns>
        List<T> GetAll();

        /// <summary>
        /// Gets object from storage by account number.
        /// </summary>
        /// <param name="id">
        /// T id.
        /// </param>
        /// <returns>
        /// Found T instance.
        /// </returns>
        T Get(int id);

        /// <summary>
        /// Searches for matches in storage with given predicate.
        /// </summary>
        /// <param name="predicate">
        /// Predicate to search with.
        /// </param>
        /// <returns>
        /// List of matches.
        /// </returns>
        List<T> Find(Predicate<T> predicate);

        /// <summary>
        /// Adds instance of T to storage.
        /// </summary>
        /// <param name="item">
        /// T instance.
        /// </param>
        void Create(T item);

        /// <summary>
        /// Replaces T instance in storage with given object.
        /// </summary>
        /// <param name="item">
        /// Object to replace with.
        /// </param>
        void Update(T item);

        /// <summary>
        /// Removes T instance from storage.
        /// </summary>
        /// <param name="id">
        /// Used to determine account to remove.
        /// </param>
        void Delete(int id);
    }
}
