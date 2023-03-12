using Elementary;
using UnityEngine;

public class TimeMultiplicationComponent : MonoBehaviour, ITimeMultiplicationComponent
{
    [SerializeField] private FloatBehaviour _timeMultiplication;

    public float GetMultiplier()
    {
        return _timeMultiplication.Value;
    }

    public void SetMultiplier(float multiplier)
    {
        _timeMultiplication.Assign(multiplier);
    }
}
