using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodBehaviour : MonoBehaviour
{
    public event Action OnEvent;

    public bool IsPlaying
    {
        get { return _coroutine != null; }
    }

    [SerializeField] private float _period = 1;

    private Coroutine _coroutine;

    public void Play()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(PeriodRoutine());
        }
    }

    public void Stop()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }


    private IEnumerator PeriodRoutine()
    {
        var period = new WaitForSeconds(_period);

        while(true)
        {
            yield return period;
            OnEvent?.Invoke();
        }
    }
}
