using System;
using UnityEngine;
using Sirenix.OdinInspector;

public class VectorEventReceiver : MonoBehaviour
{
    public event Action<Vector3> OnEvent;

    [Button]
    public void Offset(Vector3 offset)
    {
        OnEvent?.Invoke(offset);
    }
}
