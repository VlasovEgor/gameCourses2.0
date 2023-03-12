using System;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections;

public sealed class TimerBehaviour : MonoBehaviour
{
    public event Action OnEnded;
    public event Action OnStarted;
    public event Action OnTimeChanged;
    public bool IsPlaying 
    { 
        get { return _timerCoroutine != null; }
    }

    public float Duration
    {
        get { return _duration; }
        set { _duration = value; }
    }

    [SerializeField] private float _duration ;
    [SerializeField] [ReadOnly] private float _currentTime;

    private Coroutine _timerCoroutine;

    public void Play()
    {
        if (_timerCoroutine == null)
        {
            _timerCoroutine = StartCoroutine(TimerRoutine());
        }
    }

    public void Stop()
    {
        if (_timerCoroutine != null)
        {
            StopCoroutine(_timerCoroutine);
            _timerCoroutine = null;
        }
    }

    public void ResetTime()
    {
        _currentTime = 0;
    }

    public float Progress
    {
        get { return _currentTime / _duration; }
    }

    private IEnumerator TimerRoutine()
    {
        while (_currentTime<_duration)
        {
            yield return null;
            _currentTime += Time.deltaTime;
            OnTimeChanged?.Invoke();
        }

        _currentTime = _duration;
        _timerCoroutine = null;
        OnEnded?.Invoke();
    }
}

