using UnityEngine;

[CreateAssetMenu(
       fileName = "CreationSpeedConfig",
       menuName = "Upgrade/New LoadCreationSpeedConfig"
   )]
public class CreationSpeedUpgradeConfig :  UpgradeConfig
{
    [SerializeField] public CreationSpeedTable CreationSpeedTable;

    public override Upgrade InstantiateUpgrade()
    {
        return new CreationSpeedUpgrade(this);
    }

    protected override void OnValidate()
    {
        base.OnValidate();
        CreationSpeedTable.OnValidate(MaxLevel);
    }
}
