using UnityEngine;
using Zenject;

public class StartRealtimeSession : MonoBehaviour, IStartGameListener
{
    [Inject] private RealtimeSessionStarter _sessionStarter;

    async void IStartGameListener.OnStartGame()
    {
        await _sessionStarter.StartSessionAsync();
    }
}
