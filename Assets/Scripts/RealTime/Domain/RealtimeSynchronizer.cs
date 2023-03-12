using System;
using UnityEngine;
using Zenject;

public sealed class RealtimeSynchronizer : IInitializable, IDisposable
{
    //[Inject] private SceneContext _gameSceneContext;

    [Inject] private RealtimeManager _realtimeManager;
    [Inject] private TimeShiftEmitter _timeShiftEmitter;

    public void Initialize()
    {
        //_realtimeManager = _gameSceneContext.Container.Resolve<RealtimeManager>();
        //_timeShiftEmitter = _gameSceneContext.Container.Resolve<TimeShiftEmitter>();

        _realtimeManager.OnStarted += OnSessionStarted;
        _realtimeManager.OnResumed += OnSessionResumed;
    }

    public void Dispose()
    {
        _realtimeManager.OnStarted -= OnSessionStarted;
        _realtimeManager.OnResumed -= OnSessionResumed;
    }

    private void OnSessionStarted(long pauseSeconds)
    {
        Debug.Log($"On Session Started {pauseSeconds}");
        if (pauseSeconds > 0)
        {
            _timeShiftEmitter.EmitEvent(TimeShiftReason.START_GAME, pauseSeconds);
        }
    }

    private void OnSessionResumed(long pauseSeconds)
    {
        if (pauseSeconds > 0)
        {
            _timeShiftEmitter.EmitEvent(TimeShiftReason.RESUME_GAME, pauseSeconds);
        }
    }
}
