using System;

public abstract class Upgrade
{
    public event Action OnLevelUp;

    public string Id
    {
        get
        {
            return _upgradeConfig.Id;
        }
    }

    public int Level
    {
        get
        {
            return _currentLevel;
        }
        set
        {
            _currentLevel = value;
        }
    }

    public int MaxLevel
    {
        get
        {
            return _upgradeConfig.MaxLevel;
        }
    }


    public bool IsMaxLevel
    {
        get
        {
            return _currentLevel == MaxLevel;

        }
    }

    public UpgradeInfo UpgradeInfo
    {
        get
        {
            return _upgradeInfo;
        }
    }

    public int NextPrice
    {
        get { return _upgradeConfig.PriceTable.GetPrice(Level + 1); }
    }

    public abstract string NextImprovement { get; }

    public abstract string CurrentStats { get; }

    private int _currentLevel;
    private UpgradeInfo _upgradeInfo;
    private readonly UpgradeConfig _upgradeConfig;

    public Upgrade(UpgradeConfig config)
    {
        _currentLevel = 1;
        _upgradeConfig = config;
        _upgradeInfo = _upgradeConfig.UpgradeInfo;
    }

    public void LevelUp()
    {
        if (IsMaxLevel == true)
        {
            throw new Exception("Max level is reached!");
        }

        _currentLevel++;
        OnLevelUp?.Invoke();
        OnUpgrade(_currentLevel);
    }

    protected abstract void OnUpgrade(int level);
}