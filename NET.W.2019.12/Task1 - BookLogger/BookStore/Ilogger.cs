// <copyright file="Ilogger.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BookStore
{
    using System;

    public interface Ilogger
    {
        void Info(string message);

        void Error(Exception ex, string message);
    }
}
