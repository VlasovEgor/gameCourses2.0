using Elementary;
using System;
using UnityEngine;
using Sirenix.OdinInspector;
using Zenject;
using System.Collections.Generic;

public class Chest
{
    public event Action<Chest> OnStarted;
    public event Action<Chest, float> OnTimeChanged;
    public event Action<Chest> OnCompleted;

    [ShowInInspector, ReadOnly]
    public string Id
    {
        get { return _config.Id; }
    }

    [ShowInInspector, ReadOnly]
    public bool IsActive
    {
        get { return _countdown.IsPlaying; }
    }

    [ShowInInspector, ReadOnly]
    public float RemainingSeconds
    {
        get { return _countdown.RemainingTime; }
        set { _countdown.RemainingTime = value; }
    }

    public ChestConfig ChestConfig
    {
        get { return _config; }
    }

    private readonly ChestConfig _config;

    private readonly Countdown _countdown;


    public Chest(ChestConfig chest, MonoBehaviour context)
    {
        _config = chest;
        _countdown = new Countdown(context, _config.DurationSeconds);
    }

    public void Start()
    {
        if (IsActive == true)
        {
            throw new Exception("Already playing!");
        }

        _countdown.OnEnded += OnEndTime;
        _countdown.OnTimeChanged += OnChangeTime;

        OnStarted?.Invoke(this);

        _countdown.Reset();
        _countdown.Play();
    }

    public void Stop()
    {
        _countdown.OnEnded -= OnEndTime;
        _countdown.OnTimeChanged -= OnChangeTime;
    }

    private void OnChangeTime()
    {
        OnTimeChanged?.Invoke(this, RemainingSeconds);
    }

    private void OnEndTime()
    {
        _countdown.OnEnded -= OnEndTime;
        _countdown.OnTimeChanged -= OnChangeTime;

        OnCompleted?.Invoke(this);
    }

    public class Factory : PlaceholderFactory<ChestConfig, Chest>
    { }

}