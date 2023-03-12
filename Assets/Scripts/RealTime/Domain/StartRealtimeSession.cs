using UnityEngine;
using Zenject;

public class StartRealtimeSession : MonoBehaviour
{
    [Inject] private RealtimeSessionStarter _sessionStarter;

    async void Start()
    {
        await _sessionStarter.StartSessionAsync();
    }
}
