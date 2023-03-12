
using UnityEngine;

public class DeathComponent : MonoBehaviour,IDeathComponent
{
    [SerializeField] private EventReceiver _deathReceiver;
    public void Death()
    {
        _deathReceiver.Call();
    }

   
}
