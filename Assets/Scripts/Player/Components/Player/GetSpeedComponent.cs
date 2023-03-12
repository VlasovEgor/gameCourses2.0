using UnityEngine;

public class GetSpeedComponent : MonoBehaviour,IGetSpeedComponent
{
    [SerializeField] private IntBehaviour _speed;
    public int Value()
    {
        return _speed.Value;
    }
}
