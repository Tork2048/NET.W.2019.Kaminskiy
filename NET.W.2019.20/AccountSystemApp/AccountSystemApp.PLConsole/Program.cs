// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ConsolePL
{
    using System;
    using System.Linq;
    using AccountSystemApp.BLL.Interface.Entities;
    using AccountSystemApp.BLL.Interface.Interfaces;
    using DependencyResolver;
    using Ninject;

    /// <summary>
    /// Class that contains entry point.
    /// </summary>
    public class Program
    {
        private static readonly IKernel Resolver;

        static Program()
        {
            Resolver = new StandardKernel();
            Resolver.ConfigurateResolver();
        }

        private static void Main(string[] args)
        {
            IAccountService service = Resolver.Get<IAccountService>();

            service.OpenAccount("Account owner 1", AccountType.BaseAccount);
            service.OpenAccount("Account owner 2", AccountType.BaseAccount);
            service.OpenAccount("Account owner 3", AccountType.PlatinumAccount);
            service.OpenAccount("Account owner 4", AccountType.GoldAccount);

            var creditNumbers = service.GetAllAccounts().Select(acc => acc.AccountNumber).ToArray();

            creditNumbers = service.GetAllAccounts().Select(acc => acc.AccountNumber).ToArray();

            foreach (var t in creditNumbers)
            {
                service.DepositAccount(t, 100);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
            }

            foreach (var t in creditNumbers)
            {
                service.WithdrawAccount(t, 10);
            }

            foreach (var item in service.GetAllAccounts())
            {
                Console.WriteLine(item);
            }
        }
    }
}
