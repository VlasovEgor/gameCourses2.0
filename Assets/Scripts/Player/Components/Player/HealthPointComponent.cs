using UnityEngine;

public class HealthPointComponent : MonoBehaviour,IHealthPointsComponent
{
    [SerializeField] private IntBehaviour _healtPointBehavior;
    public int Value()
    {
        return _healtPointBehavior.Value;
    }
}
