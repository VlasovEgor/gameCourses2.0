using Elementary;
using System;
using UnityEngine;

public abstract class Booster 
{
    public event Action <Booster> OnStarted;
    public event Action<Booster,float> OnTimeChanged;
    public event Action <Booster> OnCompleted;

    public string Id
    {
        get 
        {
            return _config.Id;
        }
    }

    public bool IsActive
    {
        get 
        {
            return _countdown.IsPlaying;
        }
    }

    public float RemainingSeconds
    {
        get 
        {
            return _countdown.RemainingTime;
        }
    }

    public float DurationSeconds
    {
        get 
        {
            return _config.DurationSeconds;
        }
    }

    private readonly BoosterConfig _config;
    private readonly Countdown _countdown;

    public Booster(BoosterConfig boosterConfig, MonoBehaviour context)
    {
        _config = boosterConfig;
        _countdown = new Countdown(context, _config.DurationSeconds);
    }

    public void Start()
    {
        if(IsActive==true)
        {
            throw new Exception("Already playing!");
        }

        _countdown.OnEnded += OnEndTime;
        _countdown.OnTimeChanged += OnChangeTime;

        OnStart();
        OnStarted?.Invoke(this);

        _countdown.Reset();
        _countdown.Play();
    }

    protected abstract void OnStart();

    protected abstract void OnStop();

    private void OnChangeTime()
    {
        OnTimeChanged?.Invoke(this, RemainingSeconds);
    }

    private void OnEndTime()
    {
        _countdown.OnEnded -= OnEndTime;
        _countdown.OnTimeChanged -= OnChangeTime;

        OnStop();
        OnCompleted?.Invoke(this);
    }

}
