using System;
using UnityEngine;
using Sirenix.OdinInspector;

public sealed class EventReceiver : MonoBehaviour
{
    public event Action OnEvent;

    [Button]
    public void Call()
    {
        OnEvent?.Invoke();
    }
}

