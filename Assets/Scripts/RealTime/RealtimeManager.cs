using System;
using Sirenix.OdinInspector;
using UnityEngine;


public sealed class RealtimeManager : MonoBehaviour
{
    public delegate void SleepDelegate(long sleepSeconds);

    public event SleepDelegate OnStarted;

    public event Action OnPaused;

    public event SleepDelegate OnResumed;

    public event Action OnEnded;

    [PropertySpace]
    [ReadOnly]
    [ShowInInspector]
    public bool IsActive
    {
        get { return _isActive; }
    }

    [ReadOnly]
    [ShowInInspector]
    public bool IsPaused
    {
        get { return _isPaused; }
    }

    [ReadOnly]
    [ShowInInspector]
    public long RealtimeSeconds
    {
        get { return _realtimeSeconds; }
    }

    private bool _isActive;

    private bool _isPaused;

    private long _realtimeSeconds;

    private float _realtimeSinceStartupCache;

    private float _secondAcc;

    [Title("Methods")]
    [Button]
    public void Begin(long realtimeSeconds, long sleepSeconds = 0)
    {
        if (_isActive == true)
        {
            throw new Exception("Realtime manager is already active!");
        }

        _isActive = true;
        _isPaused = false;
        _realtimeSeconds = realtimeSeconds;

        sleepSeconds = Math.Max(sleepSeconds, 0);
        OnStarted?.Invoke(sleepSeconds);
    }

    [Button]
    public void End()
    {
        if (_isActive == false)
        {
            return;
        }

        _isActive = false;
        _isPaused = false;
        OnEnded?.Invoke();
    }

    private void Update()
    {
        if (_isActive == true && _isPaused == false)
        {
            UpdateTime(Time.deltaTime);
        }
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (_isActive == false)
        {
            return;
        }

        if (pauseStatus == true)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    private void OnApplicationQuit()
    {
        End();
    }

    private void UpdateTime(float deltaTime)
    {
        _secondAcc += deltaTime;
        if (_secondAcc < 1)
        {
            return;
        }

        var seconds = (int)_secondAcc;
        _secondAcc -= seconds;
        _realtimeSeconds += seconds;
    }

    [Button]
    private void Pause()
    {
        if (_isPaused == true)
        {
            return;
        }

        _realtimeSinceStartupCache = Time.realtimeSinceStartup;
        _isPaused = true;
        OnPaused?.Invoke();
    }

    [Button]
    private void Resume()
    {
        if (_isPaused == false)
        {
            return;
        }

        var sleepSeconds = (long)(Time.realtimeSinceStartup - _realtimeSinceStartupCache);
        _realtimeSeconds += sleepSeconds;
        _isPaused = false;
        OnResumed?.Invoke(sleepSeconds);
    }
}
