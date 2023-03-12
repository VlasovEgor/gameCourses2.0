using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private EventReceiver _shotReceiver;
    [SerializeField] private TimerBehaviour _countdown;
    [SerializeField] private ShootEngine _engine;

    private void OnEnable()
    {
        _shotReceiver.OnEvent += Shoot;
    }

    private void OnDisable()
    {
        _shotReceiver.OnEvent -= Shoot;
    }

    private void Shoot()
    {
        if (_countdown.IsPlaying)
        {
            return;
        }

        _engine.Shoot();

        _countdown.ResetTime();
        _countdown.Play();
    }
}