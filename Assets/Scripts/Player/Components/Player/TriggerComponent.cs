using System;
using UnityEngine;

public class TriggerComponent : MonoBehaviour, ITriggerComponent
{
    public event Action<Collider> OnTriggerEntered
    {
        add { _trigger.OnTriggerEntered += value; }
        remove { _trigger.OnTriggerEntered -= value; }
    }

    public event Action<Collider> OnTriggerExited
    {
        add { _trigger.OnTriggerExited += value; }
        remove { _trigger.OnTriggerExited -= value; }
    }

    [SerializeField] private EventReceiver_Trigger _trigger;
}
