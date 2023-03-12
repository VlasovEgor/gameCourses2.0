using UnityEngine;

[CreateAssetMenu(
       fileName = "PlatformsUpgradeConfig",
       menuName = "Upgrade/New LoadPlatformsUpgradeConfig"
   )]
public class LoadPlatformUpgradeConfig : UpgradeConfig
{
    [SerializeField] public PlatformUpgradeTable PlatformTable;

    public override Upgrade InstantiateUpgrade()
    {
        return new LoadPlatformUpgrade(this);
    }

    protected override void OnValidate()
    {
        base.OnValidate();
        PlatformTable.OnValidate(MaxLevel);
    }
}

