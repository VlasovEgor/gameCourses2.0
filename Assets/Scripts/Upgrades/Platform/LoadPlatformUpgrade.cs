using UnityEngine;

public class LoadPlatformUpgrade : Upgrade,IConstructListener
{   
    private Storages _factory;
    private readonly LoadPlatformUpgradeConfig _upgradeConfig;

    public override string CurrentStats
    {
        get {return _upgradeConfig.PlatformTable.GetAmount(Level).ToString(); }
    }

    public override string NextImprovement
    {
        get { return _upgradeConfig.PlatformTable.UpgradeStep.ToString(); }
    }

    public LoadPlatformUpgrade(LoadPlatformUpgradeConfig config) : base(config)
    {
        _upgradeConfig = config;
    }

    public void Construct(GameContext context)
    {
       // _factory=context.GetService<IEntity>().Get<Storages>();
        OnUpgrade(Level);
    }

    protected override void OnUpgrade(int level)
    {
        var amount = _upgradeConfig.PlatformTable.GetAmount(level);

        for (int i = 0; i < _factory.StorageComponents.Length; i++)
        {
            _factory.StorageComponents[i].MaxValue = amount;
        }
    }
}

