using Sirenix.OdinInspector;
using UnityEngine;

public class UpgradesSystemInstaller : MonoBehaviour, IConstructListener
{
    [SerializeField] private GameContext _gameContext;

    [SerializeField] private UpgradeCatalog _catalog;
    
    [ShowInInspector] private UpgradesManager _upgradesManager = new();

    private Upgrade[] _upgrades;

    private void Awake()
    {
        CreateUpgrades();
    }

    public void Construct(GameContext context)
    {
      //  var moneyStorage = context.GetService<MoneyStorage>();
      //  _upgradesManager.Construct(moneyStorage);
      //  _upgradesManager.Setup(_upgrades);
      //  context.AddService(_upgradesManager);
    }

    private void CreateUpgrades()
    {
        var configs = _catalog.GetAllUpgrades();
        var count = configs.Length;
        _upgrades = new Upgrade[count];

        for (var i = 0; i < count; i++)
        {
            var config = configs[i];
            _upgrades[i] = config.InstantiateUpgrade();
            _gameContext.AddListener(_upgrades[i]);
        }
    }
}
