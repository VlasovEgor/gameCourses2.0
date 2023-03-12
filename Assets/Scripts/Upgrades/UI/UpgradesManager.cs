using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class UpgradesManager
{
    public event Action<Upgrade> OnLevelUp;

    [ReadOnly, ShowInInspector]
    private Dictionary<string, Upgrade> _upgrades = new();

    private MoneyStorage _moneyStorage;

    public void Construct(MoneyStorage moneyStorage)
    {
        _moneyStorage = moneyStorage;
    }

    public void Setup(Upgrade[] upgrades)
    {
        _upgrades = new Dictionary<string, Upgrade>();
        for (int i = 0, count = upgrades.Length; i < count; i++)
        {
            var upgrade = upgrades[i];
            _upgrades[upgrade.Id] = upgrade;
        }
    }

    public Upgrade GetUpgrade(string id)
    {
        return _upgrades[id];
    }

    public Upgrade[] GetAllUpgrades()
    {
        return _upgrades.Values.ToArray<Upgrade>();
    }

    public bool CanLevelUp(Upgrade upgrade)
    {
        if (upgrade.IsMaxLevel)
        {
            return false;
        }

        var price = upgrade.NextPrice;
        return _moneyStorage.CanSpendMoney(price);
    }

    public void LevelUp(Upgrade upgrade)
    {
        if (!CanLevelUp(upgrade))
        {
            throw new Exception($"Can not level up {upgrade.Id}");
        }

        var price = upgrade.NextPrice;
        _moneyStorage.SpendMoney(price);

        upgrade.LevelUp();
        OnLevelUp?.Invoke(upgrade);
    }
}
