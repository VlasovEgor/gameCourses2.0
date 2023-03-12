using System;
using Zenject;

public class LoadingTask_StartApplicationServices : ILoadingTask
{
    private readonly IAppStartListener[] _services;

    [Inject]
    public LoadingTask_StartApplicationServices(IAppStartListener[] services)
    {
        _services = services;
    }

    public void Do(Action<LoadingResult> callback)
    {
        for (int i = 0, count = _services.Length; i < count; i++)
        {
            var service = _services[i];
            service.Start();
        }

        callback?.Invoke(LoadingResult.Success());
    }
}
