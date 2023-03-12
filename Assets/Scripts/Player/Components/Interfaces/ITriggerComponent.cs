using System;
using UnityEngine;

public interface ITriggerComponent
{
    event Action<Collider> OnTriggerEntered;

    event Action<Collider> OnTriggerExited;
}