using Elementary;
using UnityEngine;

public class WorkMechanics : MonoBehaviour
{
    [SerializeField] private TimerBehaviour _workTimer;
    [SerializeField] private LimitedIntBehavior _inputStorage;
    [SerializeField] private LimitedIntBehavior _outputStorage;

    private void OnEnable()
    {
        _workTimer.OnEnded += OnWorkFinished;
    }

    private void OnDisable()
    {
        _workTimer.OnEnded -= OnWorkFinished;
    }

    private void Update()
    {
        if (CanStartWork())
        {
            StartWork();
        }
    }

    private bool CanStartWork()
    {
        if (_inputStorage.Value<=0 || _outputStorage.IsLimit || _workTimer.IsPlaying)
        {
            return false;
        }

        return true;
    }
    private void StartWork()
    {
        _inputStorage.Value--;
        _workTimer.ResetTime();
        _workTimer.Play();
        
    }

    private void OnWorkFinished()
    {
        _outputStorage.Value++;
    }
}
