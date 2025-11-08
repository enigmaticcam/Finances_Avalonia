using Finances_Avalonia.Data.DTOs;
using Finances_Avalonia.Services;
using Finances_Avalonia.Services.Entities.States;
using System.Linq;
using System.Threading.Tasks;

namespace Finances_Avalonia.Commands.BalanceWindowAccount;

public interface IBalanceWindowAccountGet
{
    Task<APIResult> Perform();
}

public class BalanceWindowAccountGet : IBalanceWindowAccountGet
{
    private IServiceWrapper _service;
    private IBalanceWindowAccountState _state;

    public BalanceWindowAccountGet(IServiceWrapper service, IBalanceWindowAccountState state)
    {
        _service = service;
        _state = state;
    }

    public async Task<APIResult> Perform()
    {
        var result = await _service.BalanceWindowCurrentaccountbalances();
        if (result.IsSuccess && result.Obj != null)
        {
            await _state.Set(result.Obj.Select(x => new DTO_BalanceWindowAccount(x)));
        }
        return result;
    }
}
