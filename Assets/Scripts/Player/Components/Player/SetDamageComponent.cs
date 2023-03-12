using UnityEngine;

public class SetDamageComponent : MonoBehaviour,ISetDamageComponent
{
    [SerializeField] private IntBehaviour _damage;

    public void SetDamage(int damage)
    {
        _damage.Value = damage;
    }
}
