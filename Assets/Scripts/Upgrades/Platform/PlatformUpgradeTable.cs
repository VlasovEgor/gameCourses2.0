using Sirenix.OdinInspector;
using System;
using UnityEngine;


[Serializable]
public class PlatformUpgradeTable
{
    public int UpgradeStep
    {
        get { return _upgradeStep; }
    }

    public int CurrentStats
    { 
        get { return _currentStats; } 
    }

    [SerializeField] private int _startAmount = 1;
    [SerializeField] private int _upgradeStep = 2;

    private int[] _levels;
    private int _currentStats;

    public int GetAmount(int level)
    {
        var index = level - 1;
        return _levels[index];
    }

    public void OnValidate(int maxLevel)
    {
        _levels = new int[maxLevel];

        var currentAmount = _startAmount;
        for (var i = 0; i < maxLevel; i++)
        {
            _levels[i] = currentAmount;
            currentAmount += _upgradeStep;
        }
        _currentStats = currentAmount;
    }
}

