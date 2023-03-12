
using UnityEngine;

public class TakeDamageComponent : MonoBehaviour,ITakeDamageComponent
{
    [SerializeField] private IntEventReceiver _takeDamageReceiver;
    public void TakeDamage(int value)
    {
        _takeDamageReceiver.Call(value);
    }

   
}
