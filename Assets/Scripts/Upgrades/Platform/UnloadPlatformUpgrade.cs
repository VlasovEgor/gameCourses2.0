using UnityEngine;

public class UnloadPlatformUpgrade : Upgrade, IConstructListener
{
    [SerializeField] private int _upgradeStep;

    private IEntity _conveyor;
    private readonly UnloadPlatformUpgradeConfig _upgradeConfig;

    public override string CurrentStats
    {
        get { return _upgradeConfig.PlatformTable.GetAmount(Level).ToString(); }
    }

    public override string NextImprovement
    {
        get { return _upgradeConfig.PlatformTable.UpgradeStep.ToString(); }
    }

    public UnloadPlatformUpgrade(UnloadPlatformUpgradeConfig config) : base(config)
    {
        _upgradeConfig = config;
    }

    public void Construct(GameContext context)
    {
       // _conveyor = context.GetService<IEntity>().Get<IEntity>();
        OnUpgrade(Level);
    }

    protected override void OnUpgrade(int level)
    {
        var amount = _upgradeConfig.PlatformTable.GetAmount(level);
        _conveyor.Get<UnloadZoneComponent>().MaxValue= amount;
    }
}

