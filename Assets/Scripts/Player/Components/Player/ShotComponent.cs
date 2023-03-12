using UnityEngine;

public class ShotComponent : MonoBehaviour,IShotComponent
{
    [SerializeField] private EventReceiver _shotReceiver;

    public void Shoot()
    {
        _shotReceiver.Call();
    }
}
