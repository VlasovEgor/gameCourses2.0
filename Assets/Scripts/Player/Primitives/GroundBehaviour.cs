using UnityEngine;

public class GroundBehaviour : MonoBehaviour
{
    [SerializeField] private EventReceiver_Collision _groundedCollision;

    private bool _grounded;

    public bool IsGrounded
    {
        get { return _grounded; }
    }

    private void OnEnable()
    {
        _groundedCollision.OnCollisionStaying += ObjectTouchesGround;
        _groundedCollision.OnCollisionExited += ObjectDoestTouchGround;
    }

    private void OnDisable()
    {
        _groundedCollision.OnCollisionStaying -= ObjectTouchesGround;
        _groundedCollision.OnCollisionExited -= ObjectDoestTouchGround;
    }

    private void ObjectTouchesGround(Collision obj)
    {
        _grounded = true;
    }

    private void ObjectDoestTouchGround(Collision obj)
    {
        _grounded = false;
    }


}
