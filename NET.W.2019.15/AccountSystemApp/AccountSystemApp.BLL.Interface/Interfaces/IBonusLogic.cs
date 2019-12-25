// <copyright file="IbonusLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AccountSystemApp.BLL.Interface.Interfaces
{
    public interface IBonusLogic
    {
        public int PutBonus(decimal sum, int balanceCost, int putCost);

        public int WithdrawBonusSubtraction(decimal sum, int withdrawCost, int balanceCost);
    }
}
