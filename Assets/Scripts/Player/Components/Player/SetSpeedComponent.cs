using UnityEngine;

public class SetSpeedComponent : MonoBehaviour, ISetSpeedComponent
{
    [SerializeField] private IntBehaviour _speed;

    public void SetSpedd(int speed)
    {
        _speed.Value = speed;    
    }
}