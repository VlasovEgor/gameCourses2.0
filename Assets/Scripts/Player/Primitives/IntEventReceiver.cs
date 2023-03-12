using System;
using UnityEngine;
using Sirenix.OdinInspector;


public class IntEventReceiver : MonoBehaviour
{
    public event Action<int> OnEvent;

    [Button]
    public void Call(int value)
    {
        OnEvent?.Invoke(value);
    }
}

