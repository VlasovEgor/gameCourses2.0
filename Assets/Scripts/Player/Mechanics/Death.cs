using UnityEngine;


public class Death : MonoBehaviour
{
    [SerializeField] private EventReceiver _deathReceiver;
    [SerializeField] private IntBehaviour _hitPoints;

    private void OnEnable()
    {
        _hitPoints.OnValueChanged += OnHitPointsChanged;
    }

    private void OnDisable()
    {
        _hitPoints.OnValueChanged -= OnHitPointsChanged;
    }

    private void OnHitPointsChanged(int newHitPoints)
    {
        if (newHitPoints <= 0)
        {
            _deathReceiver.Call();
        }
    }
}

