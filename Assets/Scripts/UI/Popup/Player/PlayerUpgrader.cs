using Sirenix.OdinInspector;
using System;
using UnityEngine;

public class PlayerUpgrader : MonoBehaviour, IConstructListener
{   
    public event Action OnPlayerUpgraded;

    private MoneyStorage _moneyStorage;

    void IConstructListener.Construct(GameContext context)
    {
       // _moneyStorage = context.GetService<MoneyStorage>();
    }

    [Button]
    public bool CanUpgrade(PlayerInfo player)
    {
        return _moneyStorage.Money >= player.Price;
    }

    [Button]
    public void Upgrade(PlayerInfo player)
    {
        if (CanUpgrade(player))
        {
            UpdateStats(player);
            _moneyStorage.SpendMoney(player.Price);
            OnPlayerUpgraded?.Invoke();

            Debug.Log($"<color=green>Player {player.Name} successfully upgraded!</color>");
        }
        else
        {
            Debug.LogWarning($"<color=red>Not enough money for upgrade {player.Name}!</color>");
        }
    }

    private void UpdateStats(PlayerInfo player)
    {
        player.Level++; 
        player.Damage++;
        player.HealthPoints++;
        player.Price++;
    }
}