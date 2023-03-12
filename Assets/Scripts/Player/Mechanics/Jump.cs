using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private IntBehaviour _jumpPower;
    [SerializeField] private EventReceiver _jumpReceiver;
    [SerializeField] private GroundBehaviour _grounded;
    [SerializeField] private Rigidbody _rigidbody;

    private void OnEnable()
    {
        _jumpReceiver.OnEvent += OnJump;
    }

    private void OnDisable()
    {
        _jumpReceiver.OnEvent -= OnJump;
    }

    private void OnJump()
    {   
        if(_grounded.IsGrounded==true)
        {
            _rigidbody.velocity = new Vector3(0, _jumpPower.Value, 0);
        }
    }
}
