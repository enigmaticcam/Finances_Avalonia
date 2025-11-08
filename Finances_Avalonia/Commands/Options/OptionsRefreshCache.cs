using Finances_Avalonia.Services;
using System.Threading.Tasks;

namespace Finances_Avalonia.Commands.Options;

public interface IOptionsRefreshCache
{
    Task<APIResult> Perform();
}

public class OptionsRefreshCache : IOptionsRefreshCache
{
    private IServiceWrapper _service;
    private IClearCollection _clear;

    public OptionsRefreshCache(IServiceWrapper service, IClearCollection clear)
    {
        _service = service;
        _clear = clear;
    }

    public async Task<APIResult> Perform()
    {
        var result = await _service.OptionsRefreshCache();
        if (result.IsSuccess)
        {
            await _clear.ClearAll();
        }
        return result;
    }
}
