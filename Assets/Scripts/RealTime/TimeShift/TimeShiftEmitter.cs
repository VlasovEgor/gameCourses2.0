using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public sealed class TimeShiftEmitter: MonoBehaviour
{
    public event TimeShiftDelegate OnTimeShifted;

    [SerializeField] private bool _isEnable = true;

    private readonly List<ITimeShiftListener> _listeners = new();

    [Button]
    [ShowIf("isEnable")]
    [GUIColor(0, 1, 0)]
    public void EmitEvent(TimeShiftReason reason, float shiftSeconds)
    {
        if (_isEnable == false)
        {
            return;
        }

        for (int i = 0, count = _listeners.Count; i < count; i++)
        {
            var listener = _listeners[i];
            listener.OnTimeShifted(reason, shiftSeconds);
        }

        OnTimeShifted?.Invoke(reason, shiftSeconds);
    }

    public void AddListener(ITimeShiftListener listener)
    {
        _listeners.Add(listener);
    }

    public void RemoveListener(ITimeShiftListener listener)
    {
        _listeners.Remove(listener);
    }
}
