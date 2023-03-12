using UnityEngine;

public class SetHealthPointComponent : MonoBehaviour,ISetHealthPoint
{
    [SerializeField] private IntBehaviour _healthPoint;
    public void SetHealthPoint(int healthPoint)
    {
        _healthPoint.Value = healthPoint;
    }

}
