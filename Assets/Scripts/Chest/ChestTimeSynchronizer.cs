using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ChestTimeSynchronizer : MonoBehaviour,ITimeShiftListener,IStartGameListener,IFinishGameListener
{
    
    [Inject] private ChestManager _chestManager;


    [Inject] private TimeShiftEmitter _timeShifter;

    public void OnStartGame()
    {
        _timeShifter.AddListener(this);
    }

    public void OnFinishGame()
    {
        _timeShifter.RemoveListener(this);
    }

    public void OnTimeShifted(TimeShiftReason reason, float shiftSeconds)
    {
        foreach (var chest in _chestManager.GetActiveChests())
        {
            chest.RemainingSeconds -= shiftSeconds;
        }

        Debug.Log("On Chest Shifted!");
    }
}
