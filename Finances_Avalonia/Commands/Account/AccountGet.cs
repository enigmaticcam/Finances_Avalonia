using Finances_Avalonia.Data.DTOs;
using Finances_Avalonia.Services;
using Finances_Avalonia.Services.Entities.States;
using System.Linq;
using System.Threading.Tasks;

namespace Finances_Avalonia.Commands.Account;

public interface IAccountGet
{
    Task<APIResult> Perform();
}

public class AccountGet : IAccountGet
{
    private IServiceWrapper _service;
    private IAccountState _state;
    private bool _showInactive;

    public AccountGet(IServiceWrapper service, IAccountState state, bool showInactive)
    {
        _service = service;
        _state = state;
        _showInactive = showInactive;
    }

    public async Task<APIResult> Perform()
    {
        var result = await _service.AccountsGet(_showInactive);
        if (result.IsSuccess && result.Obj != null)
        {
            await _state.Set(result.Obj.Select(x => new DTO_Account(x)));
        }
        return result;
    }
}
