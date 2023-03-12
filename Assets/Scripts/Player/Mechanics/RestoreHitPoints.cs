using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreHitPoints : MonoBehaviour
{
    [SerializeField] private IntEventReceiver _takeDamageReceiver;
    [SerializeField] private IntBehaviour _hitPoints;
    [SerializeField] private TimerBehaviour _delay;
    [SerializeField] private PeriodBehaviour _restorePeriod;

    private void OnEnable()
    {
        _takeDamageReceiver.OnEvent += OnDamageTaken;
        _delay.OnEnded += OnDelayEnded;
        _restorePeriod.OnEvent += OnRestoreHitPoints;
    }

    private void OnDisable()
    {
        _takeDamageReceiver.OnEvent -= OnDamageTaken;
        _delay.OnEnded -= OnDelayEnded;
        _restorePeriod.OnEvent -= OnRestoreHitPoints;
    }

    private void OnDamageTaken(int damage)
    {
        _delay.ResetTime();
        if (!_delay.IsPlaying)
        {
            _delay.Play();
        }
        _restorePeriod.Stop();
    }

    private void OnDelayEnded()
    {
        _restorePeriod.Play();
    }

    private void OnRestoreHitPoints()
    {
        _hitPoints.Value++;

        if (_hitPoints.Value >= 5)
        {
            _restorePeriod.Stop();
        }
    }
}
