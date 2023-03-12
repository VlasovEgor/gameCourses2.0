using System;
using UnityEngine;
using Zenject;

public sealed class RealtimeSessionSaver: IInitializable , IDisposable
{
    [Inject] private RealtimeRepository _repository;
    [Inject] private RealtimeManager _realtimeManager;

    public void Initialize()
    {
        _realtimeManager.OnPaused += SaveSession;
        _realtimeManager.OnEnded += SaveSession;
    }

    public void Dispose()
    {
        _realtimeManager.OnPaused -= SaveSession;
        _realtimeManager.OnEnded -= SaveSession;
    }

    private void SaveSession()
    {
        var data = new RealtimeData
        {
            NowSeconds = _realtimeManager.RealtimeSeconds
        };
        _repository.SaveSession(data);
    }
}