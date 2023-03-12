using UnityEngine;

public class ConveyorWidgetAdapter : MonoBehaviour
{
    [SerializeField] private ConveyorWidget _view;
    [SerializeField] private TimerBehaviour _timer;

    private void OnEnable()
    {
        _timer.OnStarted += OnWorkStarted;
        _timer.OnEnded += OnWorkFinished;
    }

    private void OnDisable()
    {
        _timer.OnStarted -= OnWorkStarted;
        _timer.OnEnded -= OnWorkFinished;
    }

    private void OnWorkStarted()
    {
        _timer.OnTimeChanged += OnWorkProgress;
        _view.SetVisible(true);
    }

    private void OnWorkProgress()
    {
        _view.SetProgress(_timer.Progress);
    }

    private void OnWorkFinished()
    {
        _timer.OnTimeChanged -= OnWorkProgress;
        _view.SetVisible(false);
    }

}