using Finances_Avalonia.Data;
using Finances_Avalonia.Data.DTOs;

namespace Finances_Avalonia.Services.Entities.States;

public interface IAccountState : IEntityState<DTO_Account> { }

public class AccountState : EntityState<DTO_Account>, IAccountState
{
    public AccountState(ICacheChange cacheChange, IClearCollection clear) : base(cacheChange, clear)
    {
    }

    public override enumCacheChangeDomain CacheChangeDomain => enumCacheChangeDomain.Account;
}
