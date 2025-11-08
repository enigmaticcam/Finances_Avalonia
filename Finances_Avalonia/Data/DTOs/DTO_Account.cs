using Finances_Avalonia.Services;
using Finances_Avalonia.Services.Entities;
using System;

namespace Finances_Avalonia.Data.DTOs;

public class DTO_Account : IEquatable<DTO_Account>, ICopy<DTO_Account>
{
    public DTO_Account(AccountEntity source)
    {
        AccountId = source.AccountId;
        AccountName = source.AccountName ?? "";
        AccountLimit = source.AccountLimit;
        IsActive = source.IsActive;
        NeedsAdjust = source.NeedsAdjust;
    }

    public DTO_Account(int accountId, string accountName, decimal accountLimit, bool isActive, bool needsAdjust)
    {
        AccountId = accountId;
        AccountName = accountName;
        AccountLimit = accountLimit;
        IsActive = isActive;
        NeedsAdjust = needsAdjust;
    }

    public int AccountId { get; set; }
    public string AccountName { get; set; }
    public decimal AccountLimit { get; set; }
    public bool IsActive { get; set; }
    public bool NeedsAdjust { get; set; }

    public DTO_Account Copy()
    {
        return new DTO_Account(
            accountId: AccountId,
            accountName: AccountName,
            accountLimit: AccountLimit,
            isActive: IsActive,
            needsAdjust: NeedsAdjust);
    }

    public bool Equals(DTO_Account? other)
    {
        return other?.AccountId == AccountId;
    }

    public override int GetHashCode()
    {
        return AccountId;
    }
}
