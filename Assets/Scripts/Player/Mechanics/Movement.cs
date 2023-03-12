using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private VectorEventReceiver _movingReceiver;
    [SerializeField] private IntBehaviour _speed;
    [SerializeField] private Rigidbody _rigidbody;

    private void OnEnable()
    {
        _movingReceiver.OnEvent += OnMoving;
    }

    private void OnDisable()
    {
        _movingReceiver.OnEvent -= OnMoving;
    }

    private void OnMoving(Vector3 inputVector)
    {
        _rigidbody.velocity = new Vector3(inputVector.x * _speed.Value, _rigidbody.velocity.y, inputVector.z * _speed.Value);
    }
}
