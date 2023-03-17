using System.Collections;
using System.Threading.Tasks;
using Asyncoroutine;
using Zenject;

public sealed class RealtimeSessionStarter
{
    [Inject] private RealtimeManager _realtimeManager;
    [Inject] private RealtimeRepository _repository;

    public async Task StartSessionAsync()
    {
        if (_repository.LoadSession(out RealtimeData previousSession))
        {
            await StartSessionByPrevious(previousSession.NowSeconds);
        }
        else
        {
            await StartSessionAsFirst();
        }
    }

    private IEnumerator StartSessionByPrevious(long previousSeconds)
    {
        yield return OnlineTime.RequestNowSeconds(nowSeconds =>
        {
            var pauseTime = nowSeconds - previousSeconds;
            _realtimeManager.Begin(nowSeconds, pauseTime);
        });
    }

    private IEnumerator StartSessionAsFirst()
    {
        yield return OnlineTime.RequestNowSeconds(nowSeconds =>
        {
            _realtimeManager.Begin(nowSeconds);
        });
    }
}