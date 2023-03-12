using System;
using UnityEngine;


[DisallowMultipleComponent]
public sealed class EventReceiver_Trigger : MonoBehaviour
{
    public event Action<Collider> OnTriggerEntered;

    public event Action<Collider> OnTriggerStaying;

    public event Action<Collider> OnTriggerExited;

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEntered?.Invoke(other);
    }

    private void OnTriggerStay(Collider other)
    {
        OnTriggerStaying?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        OnTriggerExited?.Invoke(other);
    }
}

