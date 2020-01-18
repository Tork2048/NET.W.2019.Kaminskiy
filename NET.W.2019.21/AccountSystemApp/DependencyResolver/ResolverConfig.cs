// <copyright file="ResolverConfig.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DependencyResolver
{
    using AccountSystemApp.BLL.Interface.Interfaces;
    using AccountSystemApp.BLL.ServiceImplementation;
    using AccountSystemApp.DAL.Interface.DTO;
    using AccountSystemApp.DAL.Interface.Interfaces;
    using AccountSystemApp.DAL.Repositories;
    using Ninject;

    /// <summary>
    /// Class for ninject configuration.
    /// Binds interfaces with corresponding classes.
    /// </summary>
    public static class ResolverConfig
    {
        /// <summary>
        /// Ninject configuration.
        /// </summary>
        /// <param name="kernel">
        /// Ninject kernel.
        /// </param>
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<IBonusLogic>().To<BonusLogic>();
            kernel.Bind<IRepository<AccountDTO>>().To<AccountRepository>();
        }
    }
}
