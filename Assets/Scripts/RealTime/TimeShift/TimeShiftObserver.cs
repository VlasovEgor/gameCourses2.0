using UnityEngine;
using Zenject;

public abstract class TimeShiftObserver : MonoBehaviour,
    IStartGameListener,
    IFinishGameListener
{
    private TimeShiftEmitter _emitter;

    [Inject]
    public virtual void Construct(TimeShiftEmitter timeShiftEmitter)
    {
        _emitter = timeShiftEmitter;
    }

    public void OnStartGame()
    {
        _emitter.OnTimeShifted += OnTimeShifted;
    }

    public void OnFinishGame()
    {
        _emitter.OnTimeShifted -= OnTimeShifted;
    }

    protected abstract void OnTimeShifted(TimeShiftReason reason, float shiftSeconds);
}