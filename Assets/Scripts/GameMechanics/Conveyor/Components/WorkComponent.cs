using System;
using UnityEngine;

public class WorkComponent : MonoBehaviour, IWorkComponent
{
    public event Action OnStartWork
    {
        add { _timer.OnStarted += value; }
        remove { _timer.OnStarted -= value; }
    }

    public event Action OnFinishWork
    {
        add { _timer.OnEnded += value; }
        remove { _timer.OnEnded -= value; }
    }

    public event Action<float> OnProgress;


    public bool IsWorking
    {
        get
        {
            return _timer.IsPlaying;
        }
    }

    public float Progress
    {
        get
        {
            return _timer.Progress;
        }
    }

    [SerializeField] private TimerBehaviour _timer;

    private void OnEnable()
    {
        _timer.OnTimeChanged += OnProgressChanged;
    }

    private void OnDisable()
    {
        _timer.OnTimeChanged -= OnProgressChanged;
    }

    private void OnProgressChanged()
    {
        OnProgress?.Invoke(Progress);
    }
}