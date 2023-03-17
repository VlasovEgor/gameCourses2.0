using UnityEngine;
using Zenject;

public class TimeShiftObserver_SyncChest : MonoBehaviour, 
    ISyncGameListener,
    IFinishGameListener
{
    private ChestManager _chestManager;
    private TimeShiftEmitter _emitter;

    [Inject]
    public void Construct(ChestManager  chestManager, TimeShiftEmitter timeShiftEmitter)
    {   
        _chestManager= chestManager;
        _emitter = timeShiftEmitter;
    }

    void ISyncGameListener.OnSyncGame()
    {
        _emitter.OnTimeShifted += OnTimeShifted;
    }

    void IFinishGameListener.OnFinishGame()
    {
        _emitter.OnTimeShifted -= OnTimeShifted;
    }

    protected void OnTimeShifted(TimeShiftReason reason, float shiftSeconds)
    {
        SyncChests(shiftSeconds);
    }

    private void SyncChests(float shiftSeconds)
    {
        var chests = _chestManager.GetActiveChests();
        for (int i = 0, count = chests.Count; i < count; i++)
        {
            var chest = chests[i];
            chest.RemainingSeconds -= shiftSeconds;
        }
    }
}
