using Finances_Avalonia.Data;
using Finances_Avalonia.Data.DTOs;

namespace Finances_Avalonia.Services.Entities.States;

public interface IBalanceWindowAccountState : IEntityState<DTO_BalanceWindowAccount> { }

public class BalanceWindowAccountState : EntityState<DTO_BalanceWindowAccount>, IBalanceWindowAccountState
{
    public BalanceWindowAccountState(ICacheChange cacheChange, IClearCollection clear) : base(cacheChange, clear)
    {
    }

    public override enumCacheChangeDomain CacheChangeDomain => enumCacheChangeDomain.BalanceWindowAccount;
}
