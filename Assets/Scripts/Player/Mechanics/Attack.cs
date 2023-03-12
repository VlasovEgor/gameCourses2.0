using UnityEngine;

public class Attack : MonoBehaviour
{
   [SerializeField] private EventReceiver _attackReceiver;
   [SerializeField] private TimerBehaviour _countdown;
   [SerializeField] private IntBehaviour _damage;

  // [SerializeField] private Enemy _enemy;

    private void OnEnable()
    {
        _attackReceiver.OnEvent += OnRequiestAttack;
    }

    private void OnDisable()
    {
        _attackReceiver.OnEvent -= OnRequiestAttack;
    }

    private void OnRequiestAttack()
    {
        if (_countdown.IsPlaying)
        {
            return;
        }

       // _enemy.TakeDamage(_damage.Value);

        _countdown.ResetTime();
        _countdown.Play();
    }
}
