using UnityEngine;

public class AttackComponent : MonoBehaviour, IAttackComponent
{
    [SerializeField] private EventReceiver _attackReceiver;
    public void Attack()
    {
        _attackReceiver.Call();
    }
}
