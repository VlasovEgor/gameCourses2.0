using UnityEngine;

public class PlayerDamageComponent : MonoBehaviour,IPLayerDamageComponent
{
    [SerializeField] private IntBehaviour _damageBehavior;

    public int Value()
    {
        return _damageBehavior.Value;
    }
}
