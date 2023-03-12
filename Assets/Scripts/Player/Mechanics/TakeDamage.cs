using UnityEngine;


public sealed class TakeDamage : MonoBehaviour
{
    [SerializeField] private IntEventReceiver _takeDamageReceiver;
    [SerializeField] private IntBehaviour _hitPoints;

    private void OnEnable()
    {
        _takeDamageReceiver.OnEvent += OnDamageTaken;
    }

    private void OnDisable()
    {
        _takeDamageReceiver.OnEvent -= OnDamageTaken;
    }

    private void OnDamageTaken(int damage)
    {
        _hitPoints.Value -= damage;
    }
}

