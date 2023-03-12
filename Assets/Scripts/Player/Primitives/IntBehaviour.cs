using System;
using UnityEngine;

public sealed class IntBehaviour : MonoBehaviour
{
    public event Action<int> OnValueChanged;

    [SerializeField] private int _value;

    public int Value
    {
        get { return _value; }
        set
        {
            _value = value;
            OnValueChanged?.Invoke(value);
        }
    }

}

