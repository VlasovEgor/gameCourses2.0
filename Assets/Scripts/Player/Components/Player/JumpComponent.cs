using UnityEngine;

public class JumpComponent : MonoBehaviour,IJumpComponent
{   
    [SerializeField] private EventReceiver _jumpReceiver;

    public void Jump()
    {
        _jumpReceiver.Call();
    }
}
