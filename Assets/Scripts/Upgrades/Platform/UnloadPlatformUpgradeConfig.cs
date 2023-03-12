
using UnityEngine;

[CreateAssetMenu(
       fileName = "PlatformUpgradeConfig",
       menuName = "Upgrade/New UnloadPlatformUpgradeConfig"
   )]
public class UnloadPlatformUpgradeConfig: UpgradeConfig
{
    [SerializeField] public PlatformUpgradeTable PlatformTable;

    public override Upgrade InstantiateUpgrade()
    {
        return new UnloadPlatformUpgrade(this);
    }

    protected override void OnValidate()
    {
        base.OnValidate();
        PlatformTable.OnValidate(MaxLevel);
    }
}
