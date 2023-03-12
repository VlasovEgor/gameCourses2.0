using UnityEngine;

public class MovingComponent : MonoBehaviour,IMovingComponent
{
    [SerializeField] private VectorEventReceiver _moveReceiver;

    public void Movement(Vector3 vector)
    {
       _moveReceiver.Offset(vector);
    }
}
