// <copyright file="NLogger.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BookStore
{
    using System;

    public class Nlogger : Ilogger
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public void Error(Exception ex, string message)
        {
            Logger.Info(message);
        }

        public void Info(string message)
        {
            Logger.Error(message);
        }
    }
}
