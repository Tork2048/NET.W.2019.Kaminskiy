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
            IAccountNumberCreateService creator = Resolver.Get<IAccountNumberCreateService>();

            service.OpenAccount("Account owner 1", AccountType.BaseAccount, creator);
            service.OpenAccount("Account owner 2", AccountType.BaseAccount, creator);
            service.OpenAccount("Account owner 3", AccountType.PlatinumAccount, creator);
            service.OpenAccount("Account owner 4", AccountType.GoldAccount, creator);

            var creditNumbers = service.GetAllAccounts().Select(acc => acc.AccountNumber).ToArray();

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
