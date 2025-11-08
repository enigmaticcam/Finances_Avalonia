using Finances_Avalonia.Services;
using Finances_Avalonia.Services.Entities;
using System;

namespace Finances_Avalonia.Data.DTOs;

public class DTO_BalanceWindowAccount : IEquatable<DTO_BalanceWindowAccount>, ICopy<DTO_BalanceWindowAccount>
{
    public DTO_BalanceWindowAccount(BalanceWindowAccountEntity source)
    {
        BalanceWindowAccountId = source.BalanceWindowAccountId;
        BalanceWindowId = source.BalanceWindowId;
        AccountId = source.AccountId;
        Balance = source.Balance;
    }

    public DTO_BalanceWindowAccount(int balanceWindowAccountId, int balanceWindowId, int accountId, decimal balance)
    {
        BalanceWindowAccountId = balanceWindowAccountId;
        BalanceWindowId = balanceWindowId;
        AccountId = accountId;
        Balance = balance;
    }

    public int BalanceWindowAccountId { get; set; }
    public int BalanceWindowId { get; set; }
    public int AccountId { get; set; }
    public decimal Balance { get; set; }

    public DTO_BalanceWindowAccount Copy()
    {
        return new DTO_BalanceWindowAccount(
            balanceWindowAccountId: BalanceWindowAccountId,
            balanceWindowId: BalanceWindowId,
            accountId: AccountId,
            balance: Balance);
    }

    public bool Equals(DTO_BalanceWindowAccount? other)
    {
        return other?.AccountId == AccountId;
    }

    public override int GetHashCode()
    {
        return AccountId;
    }
}
